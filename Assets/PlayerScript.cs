using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript Instance;
    public PlayerControls playerCont;

    public WeaponScript weaponCont;

    public int moveSpeed;
    public int jumpHeight;

    public float gravity;
    public float rayCastJumpHight = 0.01f;
    public float rayCastDistFromOrigin = -0.5f;
    private float velX;
    private float velY;

    private InputAction movement;
    private InputAction jump;
    private InputAction aim;

    private bool isJumping = false;

    private Vector2 moveVector;
    private Vector3 playerMove;
    private Vector2 lerpVel;
    public Vector2 weaponPos;


    private Rigidbody2D rb;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        weaponCont = GetComponentInChildren<WeaponScript>();
    }

    private void Awake()
    {
        Instance = this;
        playerCont = new PlayerControls();
    }

    private void OnEnable()
    {
        movement = playerCont.Player.Move;
        movement.Enable();
        jump = playerCont.Player.Jump;
        jump.Enable();
        jump.performed += Jump;
        aim = playerCont.Player.Look;
        aim.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
        jump.Disable();
        aim.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = movement.ReadValue<Vector2>();

        Vector2 lookVector = aim.ReadValue<Vector2>();
        Vector2 mouseWorldVector = Camera.main.ScreenToWorldPoint(lookVector);
        weaponPos = new Vector2(mouseWorldVector.x - transform.position.x, mouseWorldVector.y - transform.position.y);
        weaponPos.Normalize();


        playerMove = new Vector3(moveVector.x, 0, 0);
        velX = rb.velocity.x;
        velY = rb.velocity.y;

        if (isJumping)
        {
            velY = jumpHeight;
            isJumping = false;
        }
        else
        {
            velY -= gravity;
        }

        if (moveVector.magnitude == 0)
        {
            lerpVel = new Vector2(Mathf.Lerp(velX, 0, Time.deltaTime * 7), velY);
        }
        else
        {
            velX = Mathf.Lerp(velX, moveVector.x * moveSpeed, .5f);
            playerMove.x = Mathf.Clamp(velX, -10, 10);
            playerMove.y = velY;
        }

        Debug.Log(weaponCont.isFire); // remember to delete

        if (weaponCont.isFire)
        {
            Vector2 pushVector = new Vector2(weaponPos.x*-1, weaponPos.y*-1)*10;
            playerMove = pushVector;
            lerpVel = pushVector;
            weaponCont.isFire = false;
        }
    }

    private void FixedUpdate()
    {
        if (moveVector.magnitude == 0)
        {
            rb.velocity = lerpVel;
        }
        else
        {
            rb.velocity = playerMove;
        }
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (CheckOnGround())
        {
            isJumping = true;
        }
    }

    private Boolean CheckOnGround()
    {
        Vector3 temp = new Vector3(0, rayCastDistFromOrigin, 0);
        RaycastHit2D hit = Physics2D.Raycast(transform.position + temp, Vector2.down, rayCastJumpHight);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag == "Ground" || hit.collider.gameObject.tag == "FallThrough")
            {
                return true;
            }
        }
        return false;
    }
}

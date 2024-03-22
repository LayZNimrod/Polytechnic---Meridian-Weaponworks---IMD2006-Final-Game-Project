using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript Instance;
    public PlayerControls playerCont;

    public WeaponScript weaponCont;

    public float moveSpeed;
    public int jumpHeight;

    public float gravity;
    public float rayCastLenth = 0.01f;
    public float rayCastXDistFromOrigin = -0.4f;
    public float rayCastYDistFromOrigin = -0.51f;
    public float weaponPushBack = -100f;

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
    public float maxSpeed = 100;


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
        moveVector = movement.ReadValue<Vector2>().normalized;

        Vector2 lookVector = aim.ReadValue<Vector2>();
        Vector2 mouseWorldVector = Camera.main.ScreenToWorldPoint(lookVector);
        weaponPos = new Vector2(mouseWorldVector.x - transform.position.x, mouseWorldVector.y - transform.position.y);
        weaponPos.Normalize();


        playerMove = new Vector3(moveVector.x, 0, 0);
        velX = rb.velocity.x;
        velY = rb.velocity.y;


        //if (isJumping)
        
        //{
            velY = jumpHeight;
        //    isJumping = false;
       // }


        velX = moveVector.x * moveSpeed;
        playerMove.x = Mathf.Clamp(velX, -maxSpeed, maxSpeed);

        playerMove.y = velY;

        
    }

    private void FixedUpdate()
    {
        if (jump.IsInProgress())
        {
            rb.AddForce(Vector2.up * playerMove.y * Time.deltaTime);
        }
        rb.AddForce(Vector2.right * playerMove.x * Time.deltaTime);
        //rb.AddForce(new Vector2(0, -gravity) * Time.deltaTime);
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
        Vector3 temp = new Vector3(0, rayCastYDistFromOrigin, 0);
        RaycastHit2D hit = Physics2D.Raycast(transform.position + temp, Vector2.right, rayCastLenth);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag == "Ground" || hit.collider.gameObject.tag == "FallThrough")
            {
                return true;
            }
        }
        return false;
    }

    private void StunPlayer()
    {
        movement.Disable();
        jump.Disable();
        aim.Disable();
    }
    private void UnStunPlayer()
    {
        movement.Enable();
        jump.Enable();
        aim.Enable();
    }
}
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponScript : MonoBehaviour
{
    public static WeaponScript Instance;
    [SerializeField] PlayerScript player;
    private Rigidbody2D playerPos;
    private InputAction fire;

    public bool isFireOnGround;
    public bool isWeaponTouchGround;
    public bool isWeaponTouchEnemy;
    public bool isFireOnEnemy;

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerScript.Instance;
        playerPos = GetComponentInParent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        Instance = this;
        // fire = player.playerCont.Player.Fire; 
        fire = PlayerScript.Instance.playerCont.Player.Fire;
        fire.Enable();
        fire.performed += Fire;
    }

    private void OnDisable()
    {
        fire.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 weaponPos = player.weaponPos;
        transform.position = weaponPos + (Vector2)playerPos.transform.position;

        float rotate = Mathf.Atan2(weaponPos.y, weaponPos.x) * Mathf.Rad2Deg;
        Vector3 multVector = new Vector3(0f, 0f, rotate);
        transform.eulerAngles = multVector;

        isWeaponTouchGround = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            isWeaponTouchGround = true;
        }
        if (collision.tag == "Enemy")
        {
            isWeaponTouchEnemy = true;
        }
        
    }

    private void Fire(InputAction.CallbackContext context)
    {
        if (isWeaponTouchGround)
        {
            isFireOnGround = true;
        }
        if (isWeaponTouchEnemy)
        {
            isFireOnEnemy = true;
        }
    }
}
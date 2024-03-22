using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponScript : MonoBehaviour
{
    public static WeaponScript Instance;
    [SerializeField] protected PlayerScript playerScrip;
    protected Rigidbody2D playerRB;
    private InputAction fire;
    private EnemyHealth touchedEnemy;

    public bool isFireOnGround;
    public bool isWeaponTouchGround;
    public bool isWeaponTouchEnemy;
    public bool isFireOnEnemy;


    // Start is called before the first frame update
    void Start()
    {
        playerScrip = PlayerScript.Instance;
        playerRB = GetComponentInParent<Rigidbody2D>();
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

    }
    private void FixedUpdate()
    {
        Vector2 weaponPos = playerScrip.weaponPos;
        transform.position = weaponPos + (Vector2)playerRB.transform.position;

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
            touchedEnemy = collision.gameObject.GetComponent<EnemyHealth>();
            isWeaponTouchEnemy = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            isWeaponTouchGround = false;
        }
        if (collision.tag == "Enemy")
        {
            isWeaponTouchEnemy = false;
        }
    }

    protected void Fire(InputAction.CallbackContext context)
    {
        if (isWeaponTouchGround)
        {
            Attack();
        }
        if (isWeaponTouchEnemy)
        {
            touchedEnemy.TakeDamage();
            Attack();
        }
    }
    protected virtual void Attack()
    {
        
    }
}
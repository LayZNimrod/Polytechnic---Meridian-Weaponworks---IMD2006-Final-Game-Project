using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponScript : MonoBehaviour
{
    public static WeaponScript Instance;
    [SerializeField] protected PlayerScript playerScrip;
    protected Rigidbody2D playerRB;
    protected InputAction fire;
    protected EnemyHealth touchedEnemy;
    protected float rotate;
    public Vector2 weaponPos;

    public float weaponTimer = 0;
    public float weaponHitSpeed = 0;


    // Start is called before the first frame update
    protected virtual void Start()
    {
        playerScrip = PlayerScript.Instance;
        playerRB = GetComponentInParent<Rigidbody2D>();
        AttackCooldownBar.Instance.WeaponScript = this;
    }

    private void OnEnable()
    {
        Instance = this;
        // fire = player.playerCont.Player.Fire; 
        fire = PlayerScript.Instance.playerCont.Player.Fire;
        fire.Enable();
        fire.performed += Fire;
        fire.canceled += FireCancel;
    }



    private void OnDisable()
    {
        fire.Disable();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (weaponTimer > 0)
        {
            weaponTimer += Time.deltaTime;
        }
        if (weaponTimer > weaponHitSpeed)
        {
            weaponTimer = 0;
        }
    }

    protected virtual void FixedUpdate()
    {
        weaponPos = playerScrip.weaponPos;
        transform.position = weaponPos + (Vector2)playerRB.transform.position;

        rotate = Mathf.Atan2(weaponPos.y, weaponPos.x) * Mathf.Rad2Deg;
        Vector3 multVector = new Vector3(0f, 0f, rotate);
        transform.eulerAngles = multVector;
    }

    protected virtual void Fire(InputAction.CallbackContext context)
    {
        if (weaponTimer == 0)
        {
            Attack();
            weaponTimer += Time.deltaTime;
        }
    }

    protected virtual void FireCancel(InputAction.CallbackContext context)
    {

    }

    protected virtual void Attack()
    {

    }
}
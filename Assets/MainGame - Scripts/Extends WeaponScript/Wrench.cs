using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Wrench : WeaponScript
{
    private float attackHeld = 0;
    private float spinTime = 0;
    private bool isWeaponTouchEnemy;
    

    protected override void Update()
    {
        if (weaponTimer > 0)
        {
            weaponTimer += Time.deltaTime;
        }
        if (weaponTimer > weaponHitSpeed)
        {
            weaponTimer = 0;
        }

        if (fire.IsInProgress())
        {
            Attack();
        }
    }
    protected override void FixedUpdate()
    {
        weaponPos = playerScrip.weaponPos;
        transform.position = weaponPos + (Vector2)playerRB.transform.position;

        rotate = Mathf.Atan2(weaponPos.y, weaponPos.x) * Mathf.Rad2Deg + attackHeld;
        Vector3 multVector = new Vector3(0f, 0f, rotate);
        transform.eulerAngles = multVector;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            touchedEnemy = collision.gameObject.GetComponent<EnemyHealth>();
            isWeaponTouchEnemy = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            isWeaponTouchEnemy = false;
        }
    }

    protected override void FireCancel(InputAction.CallbackContext context)
    {
        attackHeld = 0;
    }

    protected override void Attack()
    {
        attackHeld += Time.deltaTime;
        if (isWeaponTouchEnemy)
        {
            touchedEnemy.TakeDamage();
        }
        if (attackHeld > spinTime)
        {

        }
    }
}
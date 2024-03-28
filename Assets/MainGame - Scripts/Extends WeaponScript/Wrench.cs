using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Wrench : WeaponScript
{
    private float attackHeld = 0;

    private bool isWeaponTouchEnemy;
    private float attackLerp = 0;
    private float attackTime = 0;
    [SerializeField] private float hitTick;
    [SerializeField] private int flightThrust;

    // weaponTimer for wrench works completly differently


    protected override void Update()
    {


        if (attackTime > 0)
        {
            attackTime += Time.deltaTime;
        }
        if (attackTime > hitTick)
        {
            attackTime = 0;
        }

        attackLerp = Mathf.Lerp(0, 360, attackHeld * 2);
        if (attackLerp >= 360)
        {
            attackHeld = 0;
        }

        if (fire.IsInProgress() && weaponTimer > 0)
        {
            Attack();
        }
        if (!fire.IsInProgress())
        {
            weaponTimer += Time.deltaTime * 2;
        }

        if (weaponTimer > weaponHitSpeed)
        {
            weaponTimer = weaponHitSpeed;
        }
        if (weaponTimer <= 0)
        {
            attackHeld = 0;
            weaponTimer = 0;
        }
    }

    protected override void FixedUpdate()
    {
        weaponPos = playerScrip.weaponPos;
        transform.position = weaponPos + (Vector2)playerRB.transform.position;

        rotate = Mathf.Atan2(weaponPos.y, weaponPos.x) * Mathf.Rad2Deg + attackLerp;
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

    protected override void Fire(InputAction.CallbackContext context)
    {

    }

    protected override void FireCancel(InputAction.CallbackContext context)
    {
        attackHeld = 0;
    }

    protected override void Attack()
    {
        weaponTimer -= Time.deltaTime;
        attackHeld += Time.deltaTime;
        if (isWeaponTouchEnemy && attackTime == 0)
        {
            touchedEnemy.TakeDamage();
            attackTime += Time.deltaTime;
        }
        playerRB.AddForce(new Vector2(playerScrip.weaponPos.x * 1.5f, playerScrip.weaponPos.y) * flightThrust * Time.deltaTime);
    }
}
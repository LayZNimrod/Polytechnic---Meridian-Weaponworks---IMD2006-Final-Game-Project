using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Spear : WeaponScript
{
    [SerializeField] public int spearPushback = 10;
    public bool isWeaponTouchGround;
    public bool isWeaponTouchEnemy;
    public AudioSource attackSoundSource;
    public AudioClip attackSound;
    public float volume;


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

    protected override void Fire(InputAction.CallbackContext context)
    {
        if (weaponTimer == 0)
        {
            attackSoundSource.PlayOneShot(attackSound, volume);
            if (isWeaponTouchGround)
            {
            Attack();
            }
            if (isWeaponTouchEnemy)
            {
                touchedEnemy.TakeDamage();
            }

            weaponTimer = Time.deltaTime;
        }
    }
    protected override void Attack()// remember to add player stun and 
    {
        if (isWeaponTouchGround)
        {
            Vector2 pushVector = new Vector2(-PlayerScript.Instance.weaponPos.x, -PlayerScript.Instance.weaponPos.y) * spearPushback;
            playerRB.velocity = new Vector2(playerRB.velocity.x,0);
            playerRB.AddForce(pushVector,ForceMode2D.Force);
        }
    }
}
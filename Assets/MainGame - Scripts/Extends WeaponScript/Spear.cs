using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : WeaponScript
{
    [SerializeField] int spearPushback = 10;
    protected override void Attack()// remember to add player stun and 
    {
        if (isWeaponTouchGround)
        {
            Vector2 pushVector = new Vector2(-PlayerScript.Instance.weaponPos.x, -PlayerScript.Instance.weaponPos.y) * spearPushback;
            playerRB.velocity = new Vector2(playerRB.velocity.x,0);
            playerRB.AddForce(pushVector);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : WeaponScript
{
    protected override void Attack()// remember to add player stun and 
    {
        if (PlayerScript.Instance.weaponCont.isFireOnGround)
        {
            Vector2 pushVector = new Vector2(PlayerScript.Instance.weaponPos.x * -1, PlayerScript.Instance.weaponPos.y * -1) * PlayerScript.Instance.weaponPushBack;
            playerRB.velocity = new Vector2(0,0);
            playerRB.velocity = pushVector;
            PlayerScript.Instance.weaponCont.isFireOnGround = false;
        }
    }
}
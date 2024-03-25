using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : WeaponScript
{
    public CannonProj proj;
    [SerializeField] int cannonPushback = 0;


    protected override void Attack()// remember to add player stun and 
    {
        if (weaponTimer == 0)
        {
            Vector3 SpawnerPos = new Vector3(transform.position.x, transform.position.y, 0f);
            var projNew = Instantiate(proj, SpawnerPos, Quaternion.identity);
            projNew.OnSpawn(weaponPos, rotate +90);

            Vector2 pushVector = new Vector2(-PlayerScript.Instance.weaponPos.x, -PlayerScript.Instance.weaponPos.y) * cannonPushback;
            playerRB.velocity = new Vector2(playerRB.velocity.x,0);
            playerRB.AddForce(pushVector, ForceMode2D.Force);
        }
    }
}
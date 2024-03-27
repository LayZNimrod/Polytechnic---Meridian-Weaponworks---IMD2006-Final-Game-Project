using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Wrench : WeaponScript
{
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

    protected override void Fire(InputAction.CallbackContext context)
    {

    }
    protected override void Attack()
    {
        
    }
}

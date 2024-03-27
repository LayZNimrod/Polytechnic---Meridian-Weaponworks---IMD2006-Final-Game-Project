using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackCooldownBar : MonoBehaviour
{
    [SerializeField] private Slider Slider;
    public WeaponScript WeaponScript;
    public void updateStamina(float STCurrent, float STMax)
    {
        Slider.value = STCurrent / STMax;
    }

    public void Update()
    {
        Debug.Log(WeaponScript);
        updateStamina(WeaponScript.weaponTimer, WeaponScript.weaponHitSpeed);
    }
}

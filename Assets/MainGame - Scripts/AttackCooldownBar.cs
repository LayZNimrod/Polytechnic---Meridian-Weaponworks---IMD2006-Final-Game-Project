using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackCooldownBar : MonoBehaviour
{
    public static AttackCooldownBar Instance;
    [SerializeField] private Slider Slider;
    public WeaponScript WeaponScript;

    private void OnEnable()
    {
        Instance = this;
    }
    public void updateStamina(float STCurrent, float STMax)
    {
        Slider.value = STCurrent / STMax;
    }

    public void Update()
    {
        updateStamina(WeaponScript.weaponTimer, WeaponScript.weaponHitSpeed);
    }
}

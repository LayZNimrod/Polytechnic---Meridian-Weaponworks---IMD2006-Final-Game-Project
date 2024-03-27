using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class WeaponSpawner : MonoBehaviour
{
    public GameObject cannon;
    public GameObject wrench;
    public StatHandler stat;
    
    // Start is called before the first frame update
    private void OnEnable()
    {
        if (ChoiceCarrier.ChosenWeapon == MenuScript.Weapon.Wrench)
        {
            GameObject weaponClone = Instantiate(wrench);
            weaponClone.transform.SetParent(GameObject.Find("Player").transform, false);
            stat.weapon = weaponClone.GetComponent<WeaponScript>();
        }
        else if (ChoiceCarrier.ChosenWeapon == MenuScript.Weapon.Cannon)
        {
            GameObject weaponClone = Instantiate(cannon);
            weaponClone.transform.SetParent(GameObject.Find("Player").transform, false);
            stat.weapon = weaponClone.GetComponent<WeaponScript>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

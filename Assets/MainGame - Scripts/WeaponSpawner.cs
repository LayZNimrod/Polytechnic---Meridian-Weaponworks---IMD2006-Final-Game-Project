using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class WeaponSpawner : MonoBehaviour
{
    public GameObject wrench;
    public GameObject cannon;
    // Start is called before the first frame update
    private void Awake()
    {

    }

    void Start()
    {
        if (ChoiceCarrier.ChosenWeapon == MenuScript.Weapon.Wrench)
        {
            GameObject weaponClone = Instantiate(wrench);
            weaponClone.transform.SetParent(GameObject.Find("Player").transform, false);
        }
        else if (ChoiceCarrier.ChosenWeapon == MenuScript.Weapon.Cannon)
        {
            GameObject weaponClone = Instantiate(cannon);
            weaponClone.transform.SetParent(GameObject.Find("Player").transform, false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

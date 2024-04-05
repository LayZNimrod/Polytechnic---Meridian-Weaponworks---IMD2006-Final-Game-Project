using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class WeaponSpawner : MonoBehaviour
{
    public GameObject cannon;
    public GameObject wrench;
    public GameObject spear;
    public StatHandler stat;

        
    private void OnEnable()
    {
        switch (ChoiceCarrier.ChosenWeapon)
        {
            case (MenuScript.Weapon.Wrench):
                GameObject weaponCloneW = Instantiate(wrench);
                weaponCloneW.transform.SetParent(GameObject.Find("Player").transform, false);
                stat.weapon = weaponCloneW.GetComponent<WeaponScript>();
                break;

            case (MenuScript.Weapon.Cannon):
                GameObject weaponCloneC = Instantiate(cannon);
                weaponCloneC.transform.SetParent(GameObject.Find("Player").transform, false);
                stat.weapon = weaponCloneC.GetComponent<WeaponScript>();
                break;
            case (MenuScript.Weapon.Spear):
                GameObject weaponCloneS = Instantiate(spear);
                weaponCloneS.transform.SetParent(GameObject.Find("Player").transform, false);
                stat.weapon = weaponCloneS.GetComponent<WeaponScript>();
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

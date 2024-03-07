using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class WeaponSpawner : MonoBehaviour
{
    public GameObject weapon;
    // Start is called before the first frame update
    private void Awake()
    {
        if (ChoiceCarrier.ChosenWeapon == MenuScript.Weapon.Wrench)
        {
            GameObject wrench = Instantiate(weapon);
            wrench.transform.SetParent(GameObject.Find("Player").transform, false);
        }
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

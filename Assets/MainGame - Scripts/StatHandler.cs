using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class StatHandler : MonoBehaviour
{
    public int WeaponDamage;
    public int ElementDamage;
    public int TotalDamage;
    public PlayerScript PlayerScript;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CheckChoices());
        TotalDamage = WeaponDamage + ElementDamage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CheckChoices()
    {
        //Choice for weapon set to text
        switch (ChoiceCarrier.ChosenWeapon)
        {
            case (MenuScript.Weapon.Cannon):
                WeaponDamage = 4;
                break;
            case (MenuScript.Weapon.Wrench):
                WeaponDamage = 2;
                break;
        }

        //Choice for element set to text
        switch (ChoiceCarrier.ChosenElement)
        {
            case (MenuScript.Element.Fire):
                ElementDamage = 2;
                PlayerScript.jumpHeight = 17;
                PlayerScript.maxSpeed = 8;
                break;
            case (MenuScript.Element.Lightning):
                ElementDamage = -1;
                PlayerScript.jumpHeight = 12;
                PlayerScript.maxSpeed = 17;
                break;
        }
        yield return new WaitForSeconds(0.001f); // Change this later, its there so this function returns something for now
    }
}

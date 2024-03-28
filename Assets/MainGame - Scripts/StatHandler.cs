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
    public WeaponScript weapon;


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
                WeaponDamage = 3;
                break;
            case (MenuScript.Weapon.Spear):
                WeaponDamage = 3;
                break;
        }

        //Choice for element set to text
        switch (ChoiceCarrier.ChosenElement)
        {
            case (MenuScript.Element.Fire):
                ElementDamage = 2;
                PlayerScript.jumpForce = 5;
                PlayerScript.moveSpeed = 15;
                PlayerScript.maxSpeed = 9;
                PlayerScript.dragX = 5;
                PlayerScript.airDragX = 0.8f;
                PlayerScript.GetComponent<Rigidbody2D>().gravityScale = 2;
                HPSystem.Instance.HPCount = 4;
                break;
            case (MenuScript.Element.Lightning):
                ElementDamage = 0;
                PlayerScript.jumpForce = 7;
                PlayerScript.moveSpeed = 30;
                PlayerScript.maxSpeed = 16;
                PlayerScript.dragX = 5f;
                PlayerScript.airDragX = 1f;
                PlayerScript.GetComponent<Rigidbody2D>().gravityScale = 4;
                HPSystem.Instance.HPCount = 3;
                break;
            case (MenuScript.Element.Reinforced):
                ElementDamage = 4;
                PlayerScript.moveSpeed = 10;
                PlayerScript.maxSpeed = 7;
                PlayerScript.dragX = 3f;
                PlayerScript.airDragX = 1f;
                PlayerScript.GetComponent<Rigidbody2D>().gravityScale = 4;
                HPSystem.Instance.HPCount = 5;
                if (weapon as Cannon != null) // https://forum.unity.com/threads/check-if-a-gameobject-has-a-certain-script.88484/
                {
                    (weapon as Cannon).cannonPushback = 20;
                }
                if (weapon as Spear != null) // https://forum.unity.com/threads/check-if-a-gameobject-has-a-certain-script.88484/
                {
                    (weapon as Spear).spearPushback = 10;
                }
                if (weapon as Wrench != null) // https://forum.unity.com/threads/check-if-a-gameobject-has-a-certain-script.88484/
                {
                    (weapon as Wrench).flightThrust = 20;
                }
                break;
        }

        yield return new WaitForSeconds(0.001f); // Change this later, its there so this function returns something for now
    }
}
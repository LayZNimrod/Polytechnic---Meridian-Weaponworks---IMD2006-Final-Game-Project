using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerTEMP : MonoBehaviour
{
    //public TextMeshProUGUI SWeapText;
    //public TextMeshProUGUI SElemText;
    public TextMeshProUGUI ComboText;
    private string WeaponText;
    private string ElementText;

    // Start is called before the first frame update
    void Start()
    {
        //Choice for weapon set to text
        switch (ChoiceCarrier.ChosenWeapon){
            case (MenuScript.Weapon.Cannon):
                //SWeapText.text = "Cannon";
                WeaponText = "Cannon";
                break;
            case (MenuScript.Weapon.Wrench):
                //SWeapText.text = "Wrench";
                WeaponText = "Wrench";
                break;
            case (MenuScript.Weapon.Spear):
                //SWeapText.text = "Spear";
                WeaponText = "Spear";
                break;
        }

        //Choice for element set to text
        switch (ChoiceCarrier.ChosenElement)
        {
            case (MenuScript.Element.Fire):
                //SElemText.text = "Overheated";
                ElementText = "Overheated";
                break;
            case (MenuScript.Element.Lightning):
                //SElemText.text = "Electrified";
                ElementText = "Electrified";
                break;
            case (MenuScript.Element.Reinforced):
                //SElemText.text = "Reinforced";
                ElementText = "Reinforced";
                break;
        }

        ComboText.text = ElementText + " " + WeaponText;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

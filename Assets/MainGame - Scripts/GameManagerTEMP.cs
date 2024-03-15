using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerTEMP : MonoBehaviour
{
    public TextMeshProUGUI SWeapText;
    public TextMeshProUGUI SElemText;

    // Start is called before the first frame update
    void Start()
    {
        //Choice for weapon set to text
        switch (ChoiceCarrier.ChosenWeapon){
            case (MenuScript.Weapon.Cannon):
                SWeapText.text = "Cannon";
                break;
            case (MenuScript.Weapon.Wrench):
                SWeapText.text = "Wrench";
                break;
            case (MenuScript.Weapon.Spear):
                SWeapText.text = "Spear";
                break;
            case (MenuScript.Weapon.Pizzacutter):
                SWeapText.text = "Sawblade";
                break;
        }

        //Choice for element set to text
        switch (ChoiceCarrier.ChosenElement)
        {
            case (MenuScript.Element.Fire):
                SElemText.text = "Overheated";
                break;
            case (MenuScript.Element.Lightning):
                SElemText.text = "Electrified";
                break;
            case (MenuScript.Element.Steam):
                SElemText.text = "Steam-Powered";
                break;
            case (MenuScript.Element.Reinforced):
                SElemText.text = "Reinforced";
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

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
        switch (ChoiceCarrier.ChosenWeapon){
            case (MenuScript.Weapon.Cannon):
                SWeapText.text = "Cannon";
                break;
            case (MenuScript.Weapon.Wrench):
                SWeapText.text = "Wrench";
                break;
        }
        switch (ChoiceCarrier.ChosenElement)
        {
            case (MenuScript.Element.Fire):
                SElemText.text = "Fire";
                break;
            case (MenuScript.Element.Lightning):
                SElemText.text = "Lightning";
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

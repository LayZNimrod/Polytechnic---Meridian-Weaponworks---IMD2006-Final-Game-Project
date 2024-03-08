using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public TextMeshProUGUI SelectedWeapon = null;
    public TextMeshProUGUI SelectedElement = null;

    public enum Weapon
    {
        Wrench,
        Cannon
    }
    public Weapon chosenWeapon;
    public enum Element
    {
        Fire,
        Lightning
    }
    public Element chosenElement;

    // Choose weapon
    public void SwitchWeapon()
    {
        switch (chosenWeapon)
        {
            case Weapon.Wrench:
                {
                    chosenWeapon = Weapon.Cannon;
                    SelectedWeapon.text = "Cannon";

                    break;
                }
            case Weapon.Cannon:
                {
                    chosenWeapon = Weapon.Wrench;
                    SelectedWeapon.text = "Wrench";
                    break;
                }
        }
    }

    // Choose element
    public void SwitchElement()
    {
        switch (chosenElement)
        {
            case Element.Fire:
                {
                    chosenElement = Element.Lightning;
                    SelectedElement.text = "Lightning";

                    break;
                }
            case Element.Lightning:
                {
                    chosenElement = Element.Fire;
                    SelectedElement.text = "Fire";
                    break;
                }
        }
    }

    public void CompleteWeapon()
    {
        SceneManager.LoadScene("Level1");
        //carry choices to main scene
        ChoiceCarrier.ChosenWeapon = chosenWeapon;
        ChoiceCarrier.ChosenElement = chosenElement;
    }
    // Update is called once per frame
}

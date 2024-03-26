using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public TextMeshProUGUI SelectedWeapon = null;
    public TextMeshProUGUI SelectedElement = null;
    public TextMeshProUGUI SelectedWeaponDesc = null;
    public TextMeshProUGUI SelectedElementDesc = null;
    public enum Weapon
    {
        Wrench,
        Cannon
    }
    public Weapon chosenWeapon;
    public enum Element
    {
        Fire,
        Lightning,
        //Steam,
        Reinforced
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
                    SelectedWeaponDesc.text = "Projectile, higher damage, slower attack speed. Use the knockback to your advantage!";

                    break;
                }
            case Weapon.Cannon:
                {
                    chosenWeapon = Weapon.Wrench;
                    SelectedWeapon.text = "Wrench";
                    SelectedWeaponDesc.text = "Melee, average damage, faster attack speed. Attack the ground to increase velocity!";
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
                    SelectedElement.text = "Electified";
                    SelectedElementDesc.text = "3HP, lower damage, Faster attack and movement speed, lower jump height";

                    break;
                }
            case Element.Lightning:
                {
                    chosenElement = Element.Reinforced;
                    SelectedElement.text = "Reinforced";
                    SelectedElementDesc.text = "5HP, highest damage, lower movement and attack speed, lower jump height";

                    break;
                }
            case Element.Reinforced:
                {
                    chosenElement = Element.Fire;
                    SelectedElement.text = "Overheated";
                    SelectedElementDesc.text = "4HP, higher damage, normal movement and attack speed, higher jump height";

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

    public void EnterTutorial()
    {
        SceneManager.LoadScene("TutorialScene");
        //carry choices to main scene
        ChoiceCarrier.ChosenWeapon = chosenWeapon;
        ChoiceCarrier.ChosenElement = chosenElement;
    }
    // Update is called once per frame
}

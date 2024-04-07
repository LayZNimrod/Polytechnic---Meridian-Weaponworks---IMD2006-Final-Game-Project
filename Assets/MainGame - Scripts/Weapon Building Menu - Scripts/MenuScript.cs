using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
        Spear,
        Cannon,
        Wrench
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

    public LevelSelect.LevelChoice ChosenLevel;
    private void Start()
    {
        chosenElement = ChoiceCarrier.ChosenElement;
        switch (chosenElement)
        {
            case Element.Lightning:
                {
                    chosenElement = Element.Lightning;
                    SelectedElement.text = "Electified";
                    SelectedElementDesc.text = "3HP, lower damage, Faster movement and attack speed, lower jump height";

                    break;
                }
            case Element.Reinforced:
                {
                    chosenElement = Element.Reinforced;
                    SelectedElement.text = "Reinforced";
                    SelectedElementDesc.text = "5HP, highest damage and atack power, lower movement / attack speed, lower jump height";

                    break;
                }
            case Element.Fire:
                {
                    chosenElement = Element.Fire;
                    SelectedElement.text = "Overheated";
                    SelectedElementDesc.text = "4HP, higher damage, normal movement and attack speed, higher jump height";

                    break;
                }
        }
        chosenWeapon = ChoiceCarrier.ChosenWeapon;
        switch (chosenWeapon)
        {
            case Weapon.Cannon:
                {
                    chosenWeapon = Weapon.Cannon;
                    SelectedWeapon.text = "Cannon";
                    SelectedWeaponDesc.text = "Projectile, higher damage, slower attack speed. Use the knockback to your advantage!";

                    break;
                }
            case Weapon.Wrench:
                {
                    chosenWeapon = Weapon.Wrench;
                    SelectedWeapon.text = "Wrench";
                    SelectedWeaponDesc.text = "Melee, average damage, faster attack speed. Hold Attack to spin it and glide!";
                    break;
                }
            case Weapon.Spear:
                {
                    chosenWeapon = Weapon.Spear;
                    SelectedWeapon.text = "Spear";
                    SelectedWeaponDesc.text = "Melee, lower damage, faster attack speed. Attack the ground to increase velocity!";
                    break;
                }
        }
                ChosenLevel = LevelChoiceCarrier.Chosen;
    }
    // Choose weapon
    public void SwitchWeapon()
    {
        switch (chosenWeapon)
        {
            case Weapon.Spear:
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
                    SelectedWeaponDesc.text = "Melee, average damage, faster attack speed. Hold Attack to spin it and glide!";
                    break;
                }
            case Weapon.Wrench:
                {
                    chosenWeapon = Weapon.Spear;
                    SelectedWeapon.text = "Spear";
                    SelectedWeaponDesc.text = "Melee, lower damage, faster attack speed. Attack the ground to increase velocity!";
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
                    SelectedElementDesc.text = "3HP, lower damage, Faster movement and attack speed, lower jump height";

                    break;
                }
            case Element.Lightning:
                {
                    chosenElement = Element.Reinforced;
                    SelectedElement.text = "Reinforced";
                    SelectedElementDesc.text = "5HP, highest damage and atack power, lower movement / attack speed, lower jump height";

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
        ChoiceCarrier.ChosenWeapon = chosenWeapon;
        ChoiceCarrier.ChosenElement = chosenElement;
        //carry choices to main scene

        SceneManager.LoadScene((int)LevelChoiceCarrier.Chosen + 1);
        switch (ChosenLevel)
        {
            case LevelSelect.LevelChoice.TutorialScene:
                {
                    SceneManager.LoadScene("TutorialScene");
                    break;
                }
            case LevelSelect.LevelChoice.Level1:
                {
                    SceneManager.LoadScene("Level1");
                    break;
                }
            case LevelSelect.LevelChoice.Level2:
                {
                    SceneManager.LoadScene("Level2");
                    break;
                }
        }
    }

    //public void EnterTutorial()
    //{
    //    SceneManager.LoadScene("TutorialScene");
    //    //carry choices to main scene
    //    ChoiceCarrier.ChosenWeapon = chosenWeapon;
    //    ChoiceCarrier.ChosenElement = chosenElement;
    //}

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        //carry choices to main scene
        ChoiceCarrier.ChosenWeapon = chosenWeapon;
        ChoiceCarrier.ChosenElement = chosenElement;
    }

    public void LoadLevelSelect()
    {
        SceneManager.LoadScene("LevelSelectMenu");
        //carry choices to main scene
        ChoiceCarrier.ChosenWeapon = chosenWeapon;
        ChoiceCarrier.ChosenElement = chosenElement;
    }
}

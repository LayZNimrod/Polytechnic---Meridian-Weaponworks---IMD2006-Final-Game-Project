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
    public TextMeshProUGUI HPNum = null;
    public TextMeshProUGUI JPNum = null;
    public TextMeshProUGUI DGNum = null;
    public TextMeshProUGUI SPNum = null;
    public TextMeshProUGUI DMGType = null;
    public TextMeshProUGUI DGNum2 = null;

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
                    SelectedElementDesc.text = "Electrify your gear, significantly boosting your movement speed, at the cost of weapon power and hp";
                    HPNum.text = "3";
                    JPNum.text = "4";
                    DGNum.text = "1";
                    SPNum.text = "5";
                    break;
                }
            case Element.Reinforced:
                {
                    chosenElement = Element.Reinforced;
                    SelectedElement.text = "Reinforced";
                    SelectedElementDesc.text = "Heavier metal plating, sacrificing movement prowess for much stronger weapon power, and higher hp";
                    HPNum.text = "5";
                    JPNum.text = "2";
                    DGNum.text = "5";
                    SPNum.text = "1";
                    break;
                }
            case Element.Fire:
                {
                    chosenElement = Element.Fire;
                    SelectedElement.text = "Overheated";
                    SelectedElementDesc.text = "Overheat your weapon's engine, providing well rounded stats and increased jump height";
                    HPNum.text = "4";
                    JPNum.text = "5";
                    DGNum.text = "3";
                    SPNum.text = "3";
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
                    SelectedWeaponDesc.text = "Use the high knockback to your advantage when moving!";
                    DGNum2.text = "3";
                    DMGType.text = "RANGED";
                    break;
                }
            case Weapon.Wrench:
                {
                    chosenWeapon = Weapon.Wrench;
                    SelectedWeapon.text = "Wrench";
                    SelectedWeaponDesc.text = "Hold Attack to spin it and expend stamina to glide!";
                    DGNum2.text = "2";
                    DMGType.text = "MELEE";
                    break;
                }
            case Weapon.Spear:
                {
                    chosenWeapon = Weapon.Spear;
                    SelectedWeapon.text = "Spear";
                    SelectedWeaponDesc.text = "Attack the ground to increase velocity / bounce around!";
                    DGNum2.text = "2";
                    DMGType.text = "MELEE";
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
                    SelectedWeaponDesc.text = "Use the high knockback to your advantage when moving!";
                    DGNum2.text = "3";
                    DMGType.text = "RANGED";
                    break;
                }
            case Weapon.Cannon:
                {
                    chosenWeapon = Weapon.Wrench;
                    SelectedWeapon.text = "Wrench";
                    SelectedWeaponDesc.text = "Hold Attack to spin it and expend stamina to glide!";
                    DGNum2.text = "2";
                    DMGType.text = "MELEE";
                    break;
                }
            case Weapon.Wrench:
                {
                    chosenWeapon = Weapon.Spear;
                    SelectedWeapon.text = "Spear";
                    SelectedWeaponDesc.text = "Attack the ground to increase velocity / bounce around!";
                    DGNum2.text = "2";
                    DMGType.text = "MELEE";
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
                    SelectedElementDesc.text = "Electrify your gear, significantly boosting your movement speed, at the cost of weapon power and hp";
                    HPNum.text = "3";
                    JPNum.text = "4";
                    DGNum.text = "1";
                    SPNum.text = "5";

                    break;
                }
            case Element.Lightning:
                {
                    chosenElement = Element.Reinforced;
                    SelectedElement.text = "Reinforced";
                    SelectedElementDesc.text = "Heavier metal plating, sacrificing movement prowess for much stronger weapon power, and higher hp";
                    HPNum.text = "5";
                    JPNum.text = "2";
                    DGNum.text = "5";
                    SPNum.text = "1";

                    break;
                }
            case Element.Reinforced:
                {
                    chosenElement = Element.Fire;
                    SelectedElement.text = "Overheated";
                    SelectedElementDesc.text = "Overheat your weapon's engine, providing well rounded stats and increased jump height";
                    HPNum.text = "4";
                    JPNum.text = "5";
                    DGNum.text = "3";
                    SPNum.text = "3";

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

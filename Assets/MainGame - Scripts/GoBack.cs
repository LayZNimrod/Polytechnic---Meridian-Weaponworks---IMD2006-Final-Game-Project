using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBack : MonoBehaviour
{
    public void BuildNewWeapon()
    {
        SceneManager.LoadScene("WeaponBuildingUI");
        MenuScript.Weapon ChosenWeapon = ChoiceCarrier.ChosenWeapon;
        MenuScript.Element ChosenElement = ChoiceCarrier.ChosenElement;
    }
}

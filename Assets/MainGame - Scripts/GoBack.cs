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
    }
    // Update is called once per frame
}

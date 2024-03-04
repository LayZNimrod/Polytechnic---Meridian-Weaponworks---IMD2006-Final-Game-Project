using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public TextMeshProUGUI SelectedWeapon = null;
    public TextMeshProUGUI SelectedElement = null;
    enum Weapon
    {
        Wrench,
        Cannon
    }
    Weapon chosenWeapon;
    enum Element
    {
        Fire,
        Lightning
    }
    Element chosenElement;

    // Start is called before the first frame update
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
        SceneManager.LoadScene("SampleScene");
    }
    // Update is called once per frame
}

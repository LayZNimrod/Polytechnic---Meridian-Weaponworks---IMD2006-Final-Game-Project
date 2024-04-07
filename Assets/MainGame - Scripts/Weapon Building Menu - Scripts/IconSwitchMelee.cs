using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconSwitchMelee : MonoBehaviour
{
    public MenuScript MenuScript;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (MenuScript.chosenWeapon)
        {
            case (MenuScript.Weapon.Cannon):
                {
                    GetComponent<SpriteRenderer>().enabled = false;
                    break;
                }
            default:
                {
                    GetComponent<SpriteRenderer>().enabled = true;
                    break;
                }
        }
    }
}

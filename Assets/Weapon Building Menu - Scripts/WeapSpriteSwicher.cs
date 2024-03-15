using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeapSpriteSwicher : MonoBehaviour
{
    public Sprite WrenchSprite;
    public Sprite CannonSprite;
    public Sprite SpearSprite;
    public Sprite PizzaSprite;
    //public Sprite SpearSprite;

    public MenuScript script;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (script.chosenWeapon)
        {
            case MenuScript.Weapon.Wrench:
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = WrenchSprite;
                    break;
                }
            case MenuScript.Weapon.Cannon:
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = CannonSprite;
                    break;
                }
            case MenuScript.Weapon.Spear:
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = SpearSprite;
                    break;
                }
            case MenuScript.Weapon.Pizzacutter:
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = PizzaSprite;
                    break;
                }
        }
    }
}

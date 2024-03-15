using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElemSpriteSwitcher : MonoBehaviour
{
    public Sprite FireSprite;
    public Sprite LightningSprite;
    public Sprite SteamSprite;
    public Sprite ReinforcedSprite;

    public MenuScript script;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            switch (script.chosenElement)
            {
                case MenuScript.Element.Fire:
                    {
                        this.gameObject.GetComponent<SpriteRenderer>().sprite = FireSprite;
                        break;
                    }
                case MenuScript.Element.Lightning:
                    {
                        this.gameObject.GetComponent<SpriteRenderer>().sprite = LightningSprite;
                        break;
                    }
            case MenuScript.Element.Steam:
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = SteamSprite;
                    break;
                }
            case MenuScript.Element.Reinforced:
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = ReinforcedSprite;
                    break;
                }
        }
    }
}

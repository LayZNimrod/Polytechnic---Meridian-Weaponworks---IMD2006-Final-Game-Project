using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBalance : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        switch (ChoiceCarrier.ChosenElement)
        {
            case (MenuScript.Element.Lightning):
                {
                    GetComponent<BoxCollider2D>().enabled = true;
                    GetComponent<SpriteRenderer>().enabled = true;
                    break;
                }
            default:
                {
                    GetComponent<BoxCollider2D>().enabled = false;
                    GetComponent<SpriteRenderer>().enabled = false;
                    break;
                }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

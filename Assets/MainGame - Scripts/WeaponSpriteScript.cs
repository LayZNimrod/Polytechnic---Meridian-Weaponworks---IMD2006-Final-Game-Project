using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private SpriteRenderer sprite;
    private WeaponScript script;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        script = GetComponentInParent<WeaponScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (script.weaponPos.x > 0.1)
        {
            sprite.flipY = false;
        }else if (script.weaponPos.x < -0.1)
        {
            sprite.flipY = true;
        }
    }
}

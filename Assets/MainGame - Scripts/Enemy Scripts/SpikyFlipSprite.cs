using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikyFlipSprite : MonoBehaviour
{
    [SerializeField] SpriteRenderer sprite;
    public void flipAnimSpriteX(bool x)
    {
        sprite.flipX = x;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpiky : MonoBehaviour
{
    private Rigidbody2D  rb;
    public GameObject Spiky;
    public SpikyRayCast raycast1;
    public SpikyRayCast raycast2;
    public bool isFacingRight = true;
    [SerializeField] private float speed;
    [SerializeField] private bool enclosedSpace;
    [SerializeField] private SpikyFlipSprite spikyFlipSprite;

    // Start is called before the first frame update
    void Start()
    {
        Spiky = this.gameObject;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enclosedSpace)
        {
            if(raycast1.hit.collider != null)
            {
                if ( raycast1.hit.collider.tag == "Ground")
                {
                    //Debug.Log("egg");
                    spikyFlipSprite.flipAnimSpriteX(true);
                    isFacingRight = true;
                }
            } 
            if (raycast2.hit.collider != null)
            {
                if ( raycast2.hit.collider.tag == "Ground")
                {
                    //Debug.Log("wscfughsaiurg");
                    spikyFlipSprite.flipAnimSpriteX(false);
                    isFacingRight = false;
                }
            }
        }
        else
        {
            if (raycast1.hit.collider == null || raycast1.hit.collider.tag != "Ground"){
                spikyFlipSprite.flipAnimSpriteX(true);
                isFacingRight = true;
            }
            if (raycast2.hit.collider == null || raycast2.hit.collider.tag != "Ground"){
                spikyFlipSprite.flipAnimSpriteX(false);
                isFacingRight = false;
            }
        }

        if (isFacingRight){
            rb.velocity = new Vector2(speed*Time.deltaTime, rb.velocity.y);

        }
        else{
            rb.velocity = new Vector2(-speed*Time.deltaTime, rb.velocity.y);
        }

    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatFallThrough : MonoBehaviour
{
    private GameObject dropThroughPlat;
    [SerializeField] private BoxCollider2D playerCollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)/* || PlayerScript.Instance.velX>1*/)
        {
            if (dropThroughPlat != null)
            {
                StartCoroutine(DisableCollide());
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("FallThrough"))
        {
            dropThroughPlat = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("FallThrough"))
        {
            dropThroughPlat = null;
        }
    }

    private IEnumerator DisableCollide()
    {
        BoxCollider2D platCollider = dropThroughPlat.GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(playerCollider, platCollider);
        yield return new WaitForSeconds(0.4f);
        Physics2D.IgnoreCollision(playerCollider, platCollider, false);
    }
}

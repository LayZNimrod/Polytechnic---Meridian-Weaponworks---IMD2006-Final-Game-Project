using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HPSystem : MonoBehaviour
{
    public TextMeshProUGUI HPText = null;
    public int HPCount = 0;
    public PlayerScript PlayerScript;
    private double invulnTimer;
    // Start is called before the first frame update
    void Start()
    {
        HPText.text = "HP: " + HPCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (invulnTimer > 0) 
        {
            invulnTimer += Time.deltaTime;
        }
        if (invulnTimer > 3)
        {
            invulnTimer = 0;
        } else if (invulnTimer > 0.3)
        {
            PlayerScript.Instance.UnStunPlayer();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Danger" && invulnTimer == 0)
        {
            invulnTimer = Time.deltaTime;
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            
            if (rb.velocity.x>0.1)
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(new Vector2(-3, 2));
            }
            if(rb.velocity.x<-0.1) 
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(new Vector2(3, 2));
            }
            PlayerScript.StunPlayer();

            HPCount--;
            HPText.text = "HP: " + HPCount;
            if (HPCount <= 0)
            {
                HPCount = 0;
                HPText.text = "YOU DIED";
                StartCoroutine(BackToBuild());
            }
        }
        if (collision.tag == "End")
        {
            HPText.text = "YOU WIN!";
            StartCoroutine(BackToBuild());
        }
    }

    IEnumerator BackToBuild()
    {
        PlayerScript.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("WeaponBuildingUI");
    }
}

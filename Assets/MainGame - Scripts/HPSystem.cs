using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HPSystem : MonoBehaviour
{
    public static HPSystem Instance;
    public TextMeshProUGUI HPText = null;
    public TextMeshProUGUI GameEndText = null;
    public int HPCount = 0;
    public int HPMax = 0;
    public PlayerScript PlayerScript;
    public double invulnTimer;
    [SerializeField] FloatingHPBar hPBar;
    public AudioSource hurtSoundSource;
    public AudioClip hurtSound;
    public float volume;
    public double maxInvulnTimer;

    private void OnEnable()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        HPMax = HPCount;
        HPText.text = "HP: " + HPCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (invulnTimer > 0) 
        {
            invulnTimer += Time.deltaTime;
            //hPBar.switchGrey();
        }
        if (invulnTimer > maxInvulnTimer)
        {
            invulnTimer = 0;
            PlayerAnimate.Instance.spriteBlinkToggle();
        } else if (invulnTimer > 0.3)
        {
            PlayerScript.Instance.UnStunPlayer();
            //hPBar.switchRed();
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
            hPBar.updateHP(HPCount, HPMax);
            hurtSoundSource.PlayOneShot(hurtSound, volume);
            HPText.text = "HP: " + HPCount;
            if (HPCount <= 0)
            {
                HPCount = 0;
                GameEndText.text = "YOU DIED";
                StartCoroutine(BackToBuild());
            }
        }
        if (collision.tag == "End")
        {
            GameEndText.text = "ROOM COMPLETE!";
            StartCoroutine(BackToLevelSelect());
        }
    }

    IEnumerator BackToLevelSelect()
    {
        PlayerScript.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("LevelSelectMenu");
    }

    IEnumerator BackToBuild()
    {
        PlayerScript.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("WeaponBuildingUI");
    }
}

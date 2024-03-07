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
    // Start is called before the first frame update
    void Start()
    {
        HPText.text = "HP: " + HPCount;
    }

    // Update is called once per frame
    void Update()
    {
        HPText.text = "HP: " + HPCount;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Danger")
        {
            HPCount--;
            HPText.text = "HP: " + HPCount;
            if (HPCount <= 0)
            {
                StartCoroutine(BackToBuild());
            }
        }
    }

    IEnumerator BackToBuild()
    {
        PlayerScript.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        HPCount = 0;
        HPText.text = "YOU DIED";
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("WeaponBuildingUI");
    }
}

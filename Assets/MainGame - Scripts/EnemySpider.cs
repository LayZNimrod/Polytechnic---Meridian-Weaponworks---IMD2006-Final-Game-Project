using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemySpider : MonoBehaviour
{
    public GameObject spider;
    public GameObject SpiderProj;
    public GameObject EnemyTell1;
    public GameObject EnemyTell2;
    public GameObject EnemyTell3;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ProjFire());
        //EnemyTell.GetComponent<SpriteRenderer>().enabled = false;
        spider = this.gameObject;
    }

    IEnumerator ProjFire()
    {
        while (true) 
        {
            yield return new WaitForSeconds(2);
            EnemyTell1.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(1);
            EnemyTell2.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(1);
            EnemyTell3.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(1);
            Vector3 EnemyPos = new Vector3(transform.position.x, transform.position.y, 0f);
            Instantiate(SpiderProj, EnemyPos, Quaternion.identity);
            EnemyTell1.GetComponent<SpriteRenderer>().enabled = false;
            EnemyTell2.GetComponent<SpriteRenderer>().enabled = false;
            EnemyTell3.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}

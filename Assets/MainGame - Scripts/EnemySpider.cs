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
    public int SpiderHP;
    public GameObject SpiderProj;
    public StatHandler StatHandler;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ProjFire());
        spider = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator ProjFire()
    {
        while (true) 
        {
            yield return new WaitForSeconds(5);
            Vector3 EnemyPos = new Vector3(transform.position.x, transform.position.y, 0f);
            Instantiate(SpiderProj, EnemyPos, Quaternion.identity);
        }
    }

    public void TakeDamage()
    {

        SpiderHP = SpiderHP - StatHandler.TotalDamage;
        if (SpiderHP <= 0)
        {
        Destroy(gameObject);
        }

    }
}

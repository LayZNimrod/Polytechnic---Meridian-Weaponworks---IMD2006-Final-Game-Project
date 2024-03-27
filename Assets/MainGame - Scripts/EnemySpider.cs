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
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ProjFire());
        spider = this.gameObject;
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
}

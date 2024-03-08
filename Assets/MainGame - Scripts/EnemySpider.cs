using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemySpider : MonoBehaviour
{
    private GameObject spider;
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
        if (WeaponScript.Instance.isFireOnEnemy)
        {
            SpiderHP = SpiderHP - StatHandler.TotalDamage;
            if(SpiderHP <= 0)
            {
                Destroy(spider);
            }
        }
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

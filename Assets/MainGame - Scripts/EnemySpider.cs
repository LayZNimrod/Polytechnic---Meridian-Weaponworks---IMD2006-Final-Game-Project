using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemySpider : MonoBehaviour
{
    public int SpiderHP;
    public GameObject SpiderProj;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ProjFire());
    }

    // Update is called once per frame
    void Update()
    {
        if (WeaponScript.Instance.isFireOnEnemy)
        {

        }
    }

    IEnumerator ProjFire()
    {
        yield return new WaitForSeconds(5);
        Vector3 EnemyPos = new Vector3(transform.position.x,transform.position.y, 0f);
        Instantiate(SpiderProj, EnemyPos, Quaternion.identity);
    }
}

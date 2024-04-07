using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrone : MonoBehaviour
{
    public GameObject drone;
    public GameObject droneProj;
    public GameObject EnemyTell1;
    public GameObject EnemyTell2;
    public GameObject EnemyTell3;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ProjFire());
        drone = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator ProjFire()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.4f);
            EnemyTell1.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(0.2f);
            EnemyTell2.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(0.2f);
            EnemyTell3.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(0.2f);            
            Vector3 EnemyPos = new Vector3(transform.position.x, transform.position.y, 0f);
            Instantiate(droneProj, EnemyPos, Quaternion.identity);
            EnemyTell1.GetComponent<SpriteRenderer>().enabled = false;
            EnemyTell2.GetComponent<SpriteRenderer>().enabled = false;
            EnemyTell3.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}

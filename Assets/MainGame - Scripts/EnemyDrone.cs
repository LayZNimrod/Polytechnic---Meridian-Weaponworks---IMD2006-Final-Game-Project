using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrone : MonoBehaviour
{
    public GameObject drone;
    public GameObject droneProj;
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
            yield return new WaitForSeconds(2);
            Vector3 EnemyPos = new Vector3(transform.position.x, transform.position.y, 0f);
            Instantiate(droneProj, EnemyPos, Quaternion.identity);
        }
    }
}

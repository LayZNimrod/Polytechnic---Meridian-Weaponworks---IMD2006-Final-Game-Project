using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject spawned;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 SpawnerPos = new Vector3(transform.position.x, transform.position.y, 0f);
        spawned = Instantiate(spawned, SpawnerPos, Quaternion.identity);
        spawned.GetComponent<EnemySpider>().StatHandler = GameObject.Find("GameManagerTEMP").GetComponent<StatHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

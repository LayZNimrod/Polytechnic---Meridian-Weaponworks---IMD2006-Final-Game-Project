using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject spawned;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 SpawnerPos = new Vector3(transform.position.x, transform.position.y, 0f);
        spawned = Instantiate(spawned, SpawnerPos, Quaternion.identity);
        spawned.GetComponent<EnemyHealth>().StatHandler = GameObject.Find("GameManager").GetComponent<StatHandler>();
        spawned.GetComponent<EnemyHealth>().KillCount = GameObject.Find("CameraUICanvas").GetComponent<KillCount>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

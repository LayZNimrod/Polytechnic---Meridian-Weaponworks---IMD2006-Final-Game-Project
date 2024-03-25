using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public StatHandler StatHandler;
    public int EnemyHP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage()
    {
        EnemyHP = EnemyHP - StatHandler.TotalDamage;
        if (EnemyHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public StatHandler StatHandler;
    public float EnemyHP;
    public float EnemyMaxHP;
    public EnemyHitSFX EnemyHitSFX;
    [SerializeField] FloatingHPBar hPBar;
    public KillCount KillCount;
    // Start is called before the first frame update
    void Start()
    {
        hPBar = GetComponentInChildren<FloatingHPBar>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage()
    {
        EnemyHP = EnemyHP - StatHandler.TotalDamage;
        hPBar.updateHP(EnemyHP, EnemyMaxHP);
        if (EnemyHP <= 0)
        {
            KillCount.IncreaseKillCount();
            Destroy(gameObject);
        }
        //EnemyHitSFX.playenemySFX();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyHealth : MonoBehaviour
{
    public StatHandler StatHandler;
    public float EnemyHP;
    public float EnemyMaxHP;
    [SerializeField] FloatingHPBar hPBar;
    public KillCount KillCount;
    public AudioClip sound;
    public GameObject AudLocation;

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
        AudioSource.PlayClipAtPoint(sound, transform.position);
        EnemyHP = EnemyHP - StatHandler.TotalDamage;
        hPBar.updateHP(EnemyHP, EnemyMaxHP);
        if (EnemyHP <= 0)
        {
            KillCount.IncreaseKillCount(); 
            Destroy(gameObject);
        }
    }
}

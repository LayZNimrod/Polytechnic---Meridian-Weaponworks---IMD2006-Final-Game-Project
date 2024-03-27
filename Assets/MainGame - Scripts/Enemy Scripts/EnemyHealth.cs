using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public AudioSource hitSoundSource;
    public AudioClip hitSound;
    public float volume;
    public StatHandler StatHandler;
    public float EnemyHP;
    public float EnemyMaxHP;
    [SerializeField] FloatingHPBar hPBar;
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
        hitSoundSource.PlayOneShot(hitSound, volume);
        EnemyHP = EnemyHP - StatHandler.TotalDamage;
        hPBar.updateHP(EnemyHP, EnemyMaxHP);
        if (EnemyHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyHitSFX : MonoBehaviour
{
    public AudioSource hitSoundSource;
    public AudioClip hitSound;
    public float volume;
    public void playenemySFX()
    {
        hitSoundSource.PlayOneShot(hitSound, volume);
    }
}

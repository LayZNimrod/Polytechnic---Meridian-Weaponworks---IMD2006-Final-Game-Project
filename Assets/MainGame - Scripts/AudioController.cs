using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] MusicPlayerSciript musicPlayer;
    [SerializeField] AudioClip musicClip;
    // Start is called before the first frame update
    void Start()
    {
        
        musicPlayer.GetComponent<AudioSource>().clip = musicClip;
        musicPlayer.GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
}

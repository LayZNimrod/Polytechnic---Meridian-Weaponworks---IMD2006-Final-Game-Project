using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayerSciript : MonoBehaviour
{
    [SerializeField] AudioClip MenuMusic;
    [SerializeField] AudioClip LevelMusic;
    [SerializeField] AudioSource audioSourse;

    // Start is called before the first frame update
    void Awake()
    {
        audioSourse = GetComponent<AudioSource>();
        DontDestroyOnLoad(transform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName == "Level1" || sceneName == "Level2") 
        {
            audioSourse.clip = LevelMusic;
        } else
        {
            audioSourse.clip = MenuMusic;
        }
    }
}

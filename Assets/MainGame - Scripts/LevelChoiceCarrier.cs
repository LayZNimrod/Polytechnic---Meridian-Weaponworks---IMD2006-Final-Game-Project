using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChoiceCarrier : MonoBehaviour
{
    public static LevelChoiceCarrier Instance;
    public static LevelSelect.LevelChoice Chosen;

    //Carry level choice over scenes
    private void Awake()
    {
        Instance = this;
    }
}

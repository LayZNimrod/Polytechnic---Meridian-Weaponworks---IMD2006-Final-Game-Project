using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCount : MonoBehaviour
{
    public int KillCountTracker;
    public static KillCount Instance;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseKillCount()
    {
        KillCountTracker++;
    }
}

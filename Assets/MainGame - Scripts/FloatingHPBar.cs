using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//More info (on things like rotation) found here; https://www.youtube.com/watch?v=_lREXfAMUcE
public class FloatingHPBar : MonoBehaviour
{

    [SerializeField] private Slider Slider;
    //public Color Grey = Color.gray;
    //public Color Red = Color.red;
    //public Image rend;
    // Start is called before the first frame update
    public void updateHP(float HPCurrent, float HPMax)
    {
        Slider.value = HPCurrent / HPMax;
        //rend = GetComponent<Image>();
    }

    //public void switchGrey()
    //{
    //    rend.color = Grey;
    //}
    //public void switchRed()
    //{
    //    rend.color = Red;
    //}

    // Update is called once per frame
    void Update()
    {
     
    }
}

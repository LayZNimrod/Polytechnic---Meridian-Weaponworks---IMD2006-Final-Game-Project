using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceCarrier : MonoBehaviour
{
    //Carry weapon and element choice over scenes
    public static MenuScript.Weapon ChosenWeapon;
    public static MenuScript.Element ChosenElement;
    //public static LevelSelect

    public static bool didWin = false;
    public static double timeInLevel = 0;
    public static int killCount = 0;
}

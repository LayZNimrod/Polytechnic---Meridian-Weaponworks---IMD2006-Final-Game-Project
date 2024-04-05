using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{   
    public enum LevelChoice
    {
        TutorialScene,
        Level1,
        Level2
    }
    public LevelChoice chosenLevel;
    public void PickTutorial()
    {
        chosenLevel = LevelChoice.TutorialScene;
        LevelChoiceCarrier.Chosen = chosenLevel;
        SceneManager.LoadScene("WeaponBuildingUI");
        //carry choices to weapon build scene
    }

    public void PickLevel1()
    {
        chosenLevel = LevelChoice.Level1;
        LevelChoiceCarrier.Chosen = chosenLevel;
        SceneManager.LoadScene("WeaponBuildingUI");
        //carry choices to weapon build scene
    }

    public void PickLevel2()
    {
        chosenLevel = LevelChoice.Level2;
        LevelChoiceCarrier.Chosen = chosenLevel;
        SceneManager.LoadScene("WeaponBuildingUI");
        //carry choices to weapon build scene
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    // Update is called once per frame
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI IsGameOver = null;
    public TextMeshProUGUI KillCount = null;
    public TextMeshProUGUI CompleteTime = null;
    // Start is called before the first frame update
    void Start()
    {
        if (ChoiceCarrier.didWin == true)
        {
            IsGameOver.text = "ROOM COMPLETE!";
        }
        else
        {
            IsGameOver.text = "GAME OVER!";
        }

        CompleteTime.text = ChoiceCarrier.timeInLevel.ToString();
        KillCount.text = ChoiceCarrier.killCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        //carry choices to main scene
    }

    public void LoadLevelSelect()
    {
        SceneManager.LoadScene("LevelSelectMenu");
        //carry choices to main scene
    }

    public void BuildNewWeapon()
    {
        SceneManager.LoadScene("WeaponBuildingUI");
        MenuScript.Weapon ChosenWeapon = ChoiceCarrier.ChosenWeapon;
        MenuScript.Element ChosenElement = ChoiceCarrier.ChosenElement;
    }
}

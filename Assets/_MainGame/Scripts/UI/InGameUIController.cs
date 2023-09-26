using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGameUIController : MonoBehaviour
{
    public GameObject inGameUI;
    public GameObject inGameMenu;
    public GameObject resumeBtn;

    public TextMeshProUGUI monsterKilled;
    const string monsterKilledText = "Killed : ";
    public TextMeshProUGUI totalMonsterOnScreen;
    const string totalMonsterOnScreenText = "MonsterOnScreen : ";
    public Slider hpFill;

    // Start is called before the first frame update
    void Start()
    {
        ResumeGame();
        UpdateMonsterKilled(0);
        UpdateTotalMonsterOnScreen(0);
        hpFill.value = 1.0f;
    }

    // // Update is called once per frame
    // void Update()
    // {

    // }
    public void UpdateMonsterKilled(int val)
    {
        monsterKilled.text = monsterKilledText + val;
    }
    public void UpdateTotalMonsterOnScreen(long val)
    {
        totalMonsterOnScreen.text = totalMonsterOnScreenText + val;
    }

    // public void ShowInGameUI(bool isShowInGameUI, bool isPlayerDead = false)
    // {
    //     inGameUI.SetActive(isShowInGameUI);
    //     inGameMenu.SetActive(!isShowInGameUI);
    //     if (isShowInGameUI == false)
    //     {
    //         PauseGameUI(isPlayerDead);
    //     }
    //     else
    //     {
    //         ResumeGameUI();
    //     }
    // }

    public void ExitToMainMenu()
    {
        GameManager.GetInstance().LoadMainMenuScene();
    }
    public void PauseGame(bool isPlayerDead = false)
    {
        inGameUI.SetActive(false);
        inGameMenu.SetActive(true);
        Time.timeScale = 0;
        if (isPlayerDead == true)
            resumeBtn.GetComponent<Button>().interactable = false;
    }
    public void ResumeGame()
    {
        inGameUI.SetActive(true);
        inGameMenu.SetActive(false);
        Time.timeScale = 1;
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGameUIController : MonoBehaviour
{
    public GameObject inGameUI;
    public GameObject inGameMenu;

    public TextMeshProUGUI monsterKilled;
    const string monsterKilledText = "Killed : ";
    int amountMonsterKilled = 0;
    public Slider hpFill;

    // Start is called before the first frame update
    void Start()
    {
        ShowInGameUI(true);
        amountMonsterKilled = 0;
        monsterKilled.text = monsterKilledText + amountMonsterKilled;
        hpFill.value = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowInGameUI(bool val)
    {
        inGameUI.SetActive(val);
        inGameMenu.SetActive(!val);
        if (val == false)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    public void ExitToMainMenu()
    {

    }
    void PauseGame()
    {
        Time.timeScale = 0;
    }
    void ResumeGame()
    {
        Time.timeScale = 1;
    }
}

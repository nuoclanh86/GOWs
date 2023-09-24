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
    public Image hpFill;

    // Start is called before the first frame update
    void Start()
    {
        ShowInGameUI(true);
        amountMonsterKilled = 0;
        monsterKilled.text = monsterKilledText + amountMonsterKilled;
        hpFill.fillAmount = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        hpFill.fillAmount = Mathf.Clamp01(0.5f / 0.9f);
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

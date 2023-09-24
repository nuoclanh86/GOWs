using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUIController : MonoBehaviour
{
    public GameObject inGameUI;
    public GameObject inGameMenu;

    // Start is called before the first frame update
    void Start()
    {
        ShowInGameUI(true);
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

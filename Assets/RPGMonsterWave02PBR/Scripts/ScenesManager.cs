using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    public void LoadScene(MAPSCENE scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    public void LoadNewGame()
    {
        LoadScene(MAPSCENE._Level01);
    }

    public void LoadNextGame()
    {

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

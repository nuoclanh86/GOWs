using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;


    public static GameManager GetInstance()
    {
        return _instance;
    }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void LoadScene(MAPSCENE scene)
    {
        SceneManager.LoadSceneAsync(scene.ToString());
    }

    public void LoadMainMenuScene()
    {
        LoadScene(MAPSCENE._MainMenu);
    }
}

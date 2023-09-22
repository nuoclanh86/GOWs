using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject loadingScene;
    public Image loadingBarFill;

    void Start()
    {
        mainMenu.SetActive(true);
        loadingScene.SetActive(true);
    }

    public void LoadScene(MAPSCENE scene)
    {
        StartCoroutine(LoadSceneAsync(scene));
    }

    IEnumerator LoadSceneAsync(MAPSCENE scene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene.ToString());
        loadingScene.SetActive(true);
        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
            loadingBarFill.fillAmount = progressValue;
            yield return null;
        }
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

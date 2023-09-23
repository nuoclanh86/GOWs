using UnityEngine;
using UnityEditor;
using System.Collections;

class EditorScrips : EditorWindow
{
    static string mainMenuPath = "Assets/_MainGame/Scenes/_MainMenu.unity";
    static string level01Path = "Assets/_MainGame/Scenes/_Level01.unity";

    [MenuItem("Play/PlayMe _%h")]
    [System.Obsolete]
    public static void PlayFromPrelaunchScene()
    {
        if (EditorApplication.isPlaying == true)
        {
            EditorApplication.isPlaying = false;
            return;
        }
        EditorApplication.SaveCurrentSceneIfUserWantsTo();
        EditorApplication.OpenScene(mainMenuPath);
        EditorApplication.isPlaying = true;
    }

    [MenuItem("Play/OpenSceneLevel01 _%j")]
    [System.Obsolete]
    public static void OpenSceneLevel01()
    {
        if (EditorApplication.isPlaying == true)
        {
            return;
        }
        EditorApplication.SaveCurrentSceneIfUserWantsTo();
        EditorApplication.OpenScene(level01Path);
    }
}

using UnityEngine;
using UnityEditor;
using System.Collections;
 
class EditorScrips : EditorWindow
{
 
    [MenuItem("Play/PlayMe _%h")]
    [System.Obsolete]
    public static void RunMainScene()
    {
        EditorApplication.OpenScene("Assets/RPGMonsterWave02PBR/Scenes/_MainMenu.unity");
        EditorApplication.isPlaying = true;
    }
}
 
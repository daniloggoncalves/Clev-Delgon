using UnityEngine;
using System.Collections;

public class SceneManeger : MonoBehaviour {

    public static float Score;


    void start()
    {

    }

    void update()
    {

    }

    static public void ChangeToScene(int scene)
    {
            Application.LoadLevel(scene);
    }

    public void ChangeToSceneLocal(int scene)
    {
        Application.LoadLevel(scene);
    }

    static public void LevelControl()
    {
        if (Application.loadedLevel == 1)
        {
            if (ScoreScript.score > 50)
            {
                SceneManeger.ChangeToScene(0);
            }
        }
    }

    public void LeaveGame()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            Application.Quit();
        }
    }
}

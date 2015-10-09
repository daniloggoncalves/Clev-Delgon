using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreScript : MonoBehaviour {

    public static int score = 0;
    static int highscore = 0;
    Text text;

    static public void AddPoint()
    {
        score++;
        if(score > highscore)
        {
            highscore = score;
        }
    }
	void Start () {
        text = GetComponent<Text>();
        score = 0;
        highscore = PlayerPrefs.GetInt("highscore", 0);
	}
	
    void OnDestroy()
    {
        PlayerPrefs.SetInt("highscore", highscore);
    }

	void Update () {

        SceneManeger.LevelControl();

        text.text = "score :" + score + "\nhighscore :" + highscore;

    }
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreScript : MonoBehaviour {

    public static int WerewolfScore;
    public static int PlayerScore;
    Text text;

	void Start ()
    {
        text = GetComponent<Text>();
        PlayerScore = 0;
        WerewolfScore = 0;
	}
	
	void Update ()
    {
        text.text = "Player Score :" + PlayerScore + "\nWerewolf Score :" + WerewolfScore;
        if (PlayerScore >= 10)
        {
            text.text = "Player Wins!!!";
            Time.timeScale = 0;
        }
        if (WerewolfScore >= 10)
        {
            text.text = "Werewolf Wins!!!";
            Time.timeScale = 0;
        }
    }
}

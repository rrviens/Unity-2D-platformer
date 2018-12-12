using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterGame : MonoBehaviour {

	public int points;
	public int highscore = 0;

	public Text score;
	public Text InputNext;
	public Text yourHighScore;

	void Start(){
		if(PlayerPrefs.HasKey("score"))
		{
			if(Application.loadedLevel == 1)
			{
					PlayerPrefs.DeleteKey("score");
					points = 0;
			}
			else
			{
					points = PlayerPrefs.GetInt("score");
			}
		}
		if(PlayerPrefs.HasKey("highscore"))
		{
			highscore = PlayerPrefs.GetInt("score");
		}
	}

	void Update()
	{
		score.text = ("Score: " + (points) * 100);
	}

}
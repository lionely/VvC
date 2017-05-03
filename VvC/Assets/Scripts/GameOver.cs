using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

	//The highscore is calculated here.

	Text ScoreText;
	int score;
	public static int highScore; 

	public GameObject levelLoader;

	void Awake()
	{	score = GameController.score;
		ScoreText = GameObject.Find("Score").GetComponent<Text>(); //UI Text Object
	}

	// Use this for initialization
	void Start () {
		DisplayScore ();
	}

	public void TryAgain(){
		SceneManager.LoadScene ("GamePlay",LoadSceneMode.Single);//loads scenes
	}

	public void BackToMenu(){
		Instantiate (levelLoader, levelLoader.transform.position, levelLoader.transform.rotation);
		Loading.levelToLoad = "MainMenu";
	}

	/*
	 *Sets the Highest Score and displays it.
	 */
	public void DisplayScore()
	{	
		if (score > highScore) 
		{
			highScore = score;
			PlayerPrefs.SetInt ("HighScore", highScore);
		}

		ScoreText.text = "BEST:" + " "  + highScore + '\n' + " " + '\n'
			+ "SCORE:" + " " + score;
	}


}

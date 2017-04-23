using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
	Text ScoreText;
	int score;
	public static int highScore; //highscore is calculated here.

	void Awake()
	{	score = GameController.score;
		ScoreText = GameObject.Find("Score").GetComponent<Text>(); //UI Text Object
	}

	// Use this for initialization
	void Start () {
		DisplayScore ();
	}

	// Update is called once per frame
	void Update () {

	}

	public void TryAgain(){
		SceneManager.LoadScene ("GamePlay",LoadSceneMode.Single);//loads scenes
	}

	public void BackToMenu(){
		SceneManager.LoadScene ("MainMenu",LoadSceneMode.Single);//loads scenes
	}

	/**
	 *Set the Highest Score and displays
	 */
	public void DisplayScore()
	{	
		if (score > highScore) 
		{
			highScore = score;
			PlayerPrefs.SetInt ("HighScore", highScore);
		}

//		print (highScore);
//		print (score);
		ScoreText.text = "Best:" + " "  + highScore + '\n' + " " + '\n'
			+ "Score:" + " " + score;
	}


}

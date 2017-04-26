using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {


	/*This script is attached the GUIText object, HighScore.
	 *
	 */

	Text highScoreText;

	void Awake()
	{
		highScoreText = GameObject.Find("highScore").GetComponent<Text>(); 
	}

	// Use this for initialization
	void Start () 
	{
		setHighScore ();//Initial score is set.
	}
	
	// Update is called once per frame
	void Update () 
		{
		setHighScore ();// Score is updated.
		}

	/*
	 * Sets the High Score on the MainMenu.
	 * Default  is 0.
	 * 
	 */

	private void setHighScore()
	{
		if (!GameOver.highScore.Equals (null)) {
			highScoreText.text = "Best Score:" + " " + PlayerPrefs.GetInt ("HighScore");
		} else 
		{
			highScoreText.text = "Best Score:" + " " + '0';
		}
	}


	public void backToMenu()
	{
		SceneManager.LoadScene ("MainMenu", LoadSceneMode.Single);
	}



}



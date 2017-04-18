using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {




	Text highScoreText;

	void Awake()
	{
		highScoreText = GameObject.Find("highScore").GetComponent<Text>(); 

	}

	// Use this for initialization
	void Start () 
	{
		setHighScore ();
	}
	
	// Update is called once per frame
	void Update () 
		{
		setHighScore ();
		}


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



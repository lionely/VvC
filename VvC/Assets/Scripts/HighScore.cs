using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

	Scene scene;


	Text highScoreText;

	void Awake()
	{
		highScoreText = GameObject.Find("highScore").GetComponent<Text>(); 
	}

	// Use this for initialization
	void Start () 
	{
		setHighScore ();

		scene = SceneManager.GetActiveScene ();// used to go back to MainMenu

	}
	
	// Update is called once per frame
	void Update () 
		{
		setHighScore ();
		}


	private void setHighScore()
	{
		if (!GameOver.highScore.Equals (null)) 
		{
			highScoreText.text = "Best Score:" + " "  + PlayerPrefs.GetInt ("HighScore");
		}
	}

	public void backToMenu()
	{
		SceneManager.LoadScene ("MainMenu", LoadSceneMode.Single);
	}


}



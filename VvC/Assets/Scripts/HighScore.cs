using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

	Scene scene;
	string PreviousScene = "";

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
		PreviousScene = scene.name;
	}
	
	// Update is called once per frame
	void Update () 
		{
		keyLogic ();
		setHighScore ();
		}



	/**
	 * This method has button logic for phones, for home and back button.
	 */
	private void keyLogic()
	{
		if (Input.GetKey (KeyCode.Home)) {
			//Home button pressed! write every thing you want to do
			Application.Quit ();
		}

		if (Input.GetKey (KeyCode.Escape)) {// load previous scene
			SceneManager.LoadScene ("MainMenu", LoadSceneMode.Single);
		}
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



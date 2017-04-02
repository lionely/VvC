using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;

public class mainmenu : MonoBehaviour {

	GameObject music;
	public GameObject levelLoader;


	void Start()
	{
		PlayerPrefs.GetInt ("HighScore");// loads the highscore from memory
	}

	/*
	 * This method is called by the Quit Button. It quits the game.
	 */
	public void QuitGame()
	{
		Application.Quit();
	}

	/*
	 * Displays HighScores
	 */
	public void HighScore()
	{
		SceneManager.LoadScene ("HighScore",LoadSceneMode.Single);//loads scenes
	}

	public void ChooseCarnivore()
	{
		Player.Vegan = false;
		SceneManager.LoadScene ("comp225",LoadSceneMode.Single);//loads scenes
	}

	public void ChooseVegan()
	{
		Player.Vegan = true;
		SceneManager.LoadScene ("comp225",LoadSceneMode.Single);//loads scenes
	}

}








using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

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
		
		Instantiate(levelLoader, levelLoader.transform.position, levelLoader.transform.rotation);
		Loading.levelToLoad = "HighScore";
		//SceneManager.LoadScene ("HighScore",LoadSceneMode.Single);//loads scenes
	}

	public void ChooseCarnivore()
	{
		Player.Vegan = false;
		Instantiate(levelLoader, levelLoader.transform.position, levelLoader.transform.rotation);
		Loading.levelToLoad = "GamePlay";
		//SceneManager.LoadScene ("GamePlay",LoadSceneMode.Single);//loads scenes
	}

	public void ChooseVegan()
	{
		Player.Vegan = true;
		Instantiate(levelLoader, levelLoader.transform.position, levelLoader.transform.rotation);
		Loading.levelToLoad = "GamePlay";
		//SceneManager.LoadScene ("GamePlay",LoadSceneMode.Single);//loads scenes
	}


}








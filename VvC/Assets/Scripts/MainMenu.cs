using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	GameObject music;
	public GameObject levelLoader;
	Button carn;
	Button vegan;
	float amplitudeX = 10.0f;
	float amplitudeY = 5.0f;
	float omegaX = 1.0f;
	float omegaY = 5.0f;
	float t;


	void Start()
	{
		carn = GameObject.Find ("Carn").GetComponent<Button> ();
		vegan = GameObject.Find ("Vegan").GetComponent<Button> ();

		PlayerPrefs.GetInt ("HighScore");// loads the highscore from memory

	}


	void Update()
	{
		buttonJiggle ();
		//StartCoroutine("buttonJiggle");
	}

	public void QuitGame()
	{
		Application.Quit();
	}


	public void ChooseCarnivore()
	{
		Player.Vegan = false;
		Instantiate(levelLoader, levelLoader.transform.position, levelLoader.transform.rotation);
		Loading.levelToLoad = "Info";
		//SceneManager.LoadScene ("GamePlay",LoadSceneMode.Single);//loads scenes
	}

	public void ChooseVegan()
	{
		Player.Vegan = true;
		Instantiate(levelLoader, levelLoader.transform.position, levelLoader.transform.rotation);
		Loading.levelToLoad = "Info";
		//SceneManager.LoadScene ("GamePlay",LoadSceneMode.Single);//loads scenes
	}

	void buttonJiggle()
	{

		float cX = carn.transform.localPosition.x;
		float cY = carn.transform.localPosition.y;

		float vX = vegan.transform.localPosition.x;
		//float vY = vegan.transform.localPosition.y;

		t += Time.deltaTime; 
		//float x = amplitudeX*Mathf.Cos (omegaX*t);
		float y = Mathf.Abs (0.039f*amplitudeY*Mathf.Sin (omegaY*t) + cY);

		carn.transform.localPosition = new Vector3(cX,y,0);
		vegan.transform.localPosition = new Vector3 (vX, -y, 0);


	}


}





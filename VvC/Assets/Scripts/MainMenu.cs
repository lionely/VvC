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
	Image vs; 

	float amplitudeY = 5.0f;
	float omegaY = 5.0f;
	float t;

	IEnumerator fader;

	void Start()
	{
		carn = GameObject.Find ("Carn").GetComponent<Button> ();
		vegan = GameObject.Find ("Vegan").GetComponent<Button> ();
		vs = GameObject.Find ("Vs Logo").GetComponent<Image> ();

		PlayerPrefs.GetInt ("HighScore");// loads the highscore from memory
	}


	void Update()
	{
		buttonJiggle ();
		fade ();
	}

	public void QuitGame()
	{
		Application.Quit();
	}


	public void ChooseCarnivore()
	{
		Player.Vegan = false;
		Instantiate(levelLoader, levelLoader.transform.position, levelLoader.transform.rotation);
		Loading.levelToLoad = "GamePlay";
	}

	public void ChooseVegan()
	{
		Player.Vegan = true;
		Instantiate(levelLoader, levelLoader.transform.position, levelLoader.transform.rotation);
		Loading.levelToLoad = "GamePlay";
	}

	public void HowToPlay()
	{
		Instantiate(levelLoader, levelLoader.transform.position, levelLoader.transform.rotation);
		Loading.levelToLoad = "HowToPlay";
	}

	/*
	 * Allows the button to move up and down
	 */
	void buttonJiggle()
	{

		float cX = carn.transform.localPosition.x;
		float cY = carn.transform.localPosition.y;

		float vX = vegan.transform.localPosition.x;


		t += Time.deltaTime; 
		float y = Mathf.Abs (0.039f*amplitudeY*Mathf.Sin (omegaY*t) + cY);

		carn.transform.localPosition = new Vector3(cX,y,0);
		vegan.transform.localPosition = new Vector3 (vX, -y, 0);
	}


	/*
	 * Fades vs image in and out by using two helper methods.
	 */
	private void fade()
	{
		Color c = vs.color;
		if (c.a >0) 
		{
			StartCoroutine ("vsOut");
			StopCoroutine ("vsOut");
		} else 
		{
			StartCoroutine ("vsIn");
			}
	}


	/*
	 * Fades vs image out
	 */
	IEnumerator vsOut()
	{	
		Color c = vs.color;
		while(c.a > 0) //fade out
		{
			c.a -= Time.deltaTime / 1;
			vs.color = c;
			yield return null;
		}
	}

	/*
	 * Fades vs image in
	 */
	IEnumerator vsIn()
	{
		Color c = vs.color;
		while (c.a < 1) //fade in
		{
			c.a += Time.deltaTime / 1;
			vs.color = c;
			yield return null;
		}
	}
		
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour {

	public GameObject levelLoader;
	Text touch;

	private string firstLoad ;

	void Awake()
	{
		if (PlayerPrefs.GetString ("Loaded").Equals (null)) 
		{
			PlayerPrefs.SetString ("Loaded", "true");
		}

		touch = GameObject.Find ("Text").GetComponent<Text> ();

	}

	public void goMainMenu()
	{
		firstLoad = PlayerPrefs.GetString ("Loaded");

		if (firstLoad.Equals("true")) 
		{
			PlayerPrefs.SetString ("Loaded", "false");
			Instantiate (levelLoader, levelLoader.transform.position, levelLoader.transform.rotation);
			Loading.levelToLoad = "Info";
		} 
		else 
		{
			Instantiate (levelLoader, levelLoader.transform.position, levelLoader.transform.rotation);
			Loading.levelToLoad = "MainMenu";
		}

	}



	
	// Update is called once per frame
	void Update () {
		fade ();
	}

	/*
	 * Fades Text on title screen.
	 */
	private void fade()
	{
		Color c = touch.color;
		if (c.a >0) 
		{
			StartCoroutine ("Out");
			StopCoroutine ("Out");

		} else 
		{
			StartCoroutine ("In");
		}
	}

	IEnumerator Out()
	{	
		Color c = touch.color;
		while(c.a > 0) //fade out
		{
			c.a -= Time.deltaTime / 1;
			touch.color = c;
			yield return null;
		}
	}

	IEnumerator In()
	{
		Color c = touch.color;
		while (c.a < 1) //fade in
		{
			c.a += Time.deltaTime / 1;
			touch.color = c;
			yield return null;
		}
	}
}

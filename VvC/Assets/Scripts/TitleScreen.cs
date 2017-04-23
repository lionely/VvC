using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour {

	public GameObject levelLoader;
	//TODO test this
	private string firstLoad ;//assuming first time loading game need to save to player prefs


	void Awake()
	{
//		PlayerPrefs.SetString ("Loaded", "true");
//		print((PlayerPrefs.GetString ("Loaded")));

		if (PlayerPrefs.GetString ("Loaded").Equals (null)) 
		{
			PlayerPrefs.SetString ("Loaded", "true");
		}

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


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

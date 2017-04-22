﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour {

	public GameObject levelLoader;
	private bool firstLoad = true;//assuming first time loading game

	public void goMainMenu()
	{
		if (firstLoad) 
		{
			firstLoad = false;
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
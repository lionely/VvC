using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlay : MonoBehaviour {

	public GameObject levelLoader;

	public void BackToMain()
	{
		Instantiate (levelLoader, levelLoader.transform.position, levelLoader.transform.rotation);
		Loading.levelToLoad = "MainMenu";
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

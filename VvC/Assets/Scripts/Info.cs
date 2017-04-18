using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info : MonoBehaviour {

	public GameObject levelLoader;


	public void loadGame()
	{
		Instantiate(levelLoader, levelLoader.transform.position, levelLoader.transform.rotation);
		Loading.levelToLoad = "GamePlay";
	}
}

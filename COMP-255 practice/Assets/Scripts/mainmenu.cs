using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class mainmenu : MonoBehaviour {

	GameObject music;
	public GameObject levelLoader;


	
	void Start()
	{
		
	}

	public void StartGame(){
//		Instantiate(levelLoader, levelLoader.transform.position, levelLoader.transform.rotation);
//		loading.levelToLoad = "comp225";
		SceneManager.LoadScene ("comp225");//loads scenes

	}
	

		
	}



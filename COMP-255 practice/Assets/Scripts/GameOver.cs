using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}


	public void TryAgain(){
		SceneManager.LoadScene ("comp225");//loads scenes
	}
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Text scoreText;
	public Text buttonText;
	private int score;
	public bool paused;

	// Use this for initialization
	void Awake () {
		scoreText = GameObject.Find("ScoreText").GetComponent<Text> (); //UI Text Object
		buttonText = GameObject.Find("ButtonText").GetComponent<Text> ();
		paused = false;
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void AddScore () {
		score += 1;
		scoreText.text = "Score: " + score;
	}

	public void Pause () {

		Touch t = Input.GetTouch (0);

		if (t.phase == TouchPhase.Ended) {	//At end of touch
			paused = !paused;
		}

		if (paused) {
			Time.timeScale = 0;
			buttonText.text = "Resume";
		}

		else if (!paused) {
			Time.timeScale = 1;
			buttonText.text = "Pause";
		}
	}
}

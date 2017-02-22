using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GUIText scoreText;
	private int score;
	public bool paused;

	// Use this for initialization
	void Start () {
		paused = false;
		score = 0;
		UpdateScore ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void AddScore () {
		score += 1;
		UpdateScore ();
	}

	void UpdateScore() {
		scoreText.text = "Score: " + score;
	}

	public void Pause () {

		Touch t = Input.GetTouch (0);

		if (t.phase == TouchPhase.Ended) {	//At beginning of touch
			paused = !paused;
		}

		if (paused) {
			Time.timeScale = 0;
		}

		else if (!paused) {
			Time.timeScale = 1;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {

	public bool paused;

	// Use this for initialization
	void Start () {
		paused = false;
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void Pause () {

		Touch t = Input.GetTouch (0);

		if (t.phase == TouchPhase.Ended) {	//At end of touch
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

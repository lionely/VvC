using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public Player player;
	public Text scoreText;
	public Text lifeText;
	public Text buttonText;
	public float speed;
	private float acceleration;
	private int score;
	private int life;
	public bool paused;
	private static float INITIAL_SPEED = -4.0f;
	private static float INITIAL_ACCELERATION = 0.01f;
	private static float ACCELERATION_DECAY = 0.9999f;

	// Use this for initialization
	void Awake () {
		scoreText = GameObject.Find("ScoreText").GetComponent<Text> (); //UI Text Object
		lifeText = GameObject.Find("LifeText").GetComponent<Text> ();
		buttonText = GameObject.Find("ButtonText").GetComponent<Text> ();
		paused = false;
		score = 0;
		life = 3;
		speed = INITIAL_SPEED;
		acceleration = INITIAL_ACCELERATION;
	}
	
	// Update is called once per frame
	void Update () {
		speed = speed - acceleration;
		acceleration = acceleration * ACCELERATION_DECAY;
		print (acceleration);
		print (speed);
	}

	public void AddScore () {
		score += 1;
		scoreText.text = "Score: " + score;
	}

	public void LoseLife () {
		life -= 1;
		lifeText.text = "Life: " + life;

		if (life <= 0) {
			player.DestroyPlayer();
			SceneManager.LoadScene ("GameOver",LoadSceneMode.Single);
		}
	}

	public void Pause () {

		Touch t = Input.GetTouch (0);

		if (t.phase == TouchPhase.Ended) {	//At end of touch
			paused = !paused;
		}

		if (paused) {
			Time.timeScale = 0;
			buttonText.text = "Resume";
			player.enabled = false;
		}

		else if (!paused) {
			Time.timeScale = 1;
			buttonText.text = "Pause";
			player.enabled = true;
		}
	}
}

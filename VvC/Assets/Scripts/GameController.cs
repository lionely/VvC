using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	Player player;
	ShakeCamera camShake;
	Text scoreText;
	Text lifeText;
	Text buttonText;

	public float speed;
	private float acceleration;
	public static int score;
	private static int scoreSinceHit;
	private int life;
	public bool paused;

	private static float SPEED_FACTOR = -2.0f;
	private static float BASE_SPEED = -4.0f;

	// Use this for initialization
	void Awake () {
		player = GameObject.Find("Player").GetComponent<Player> ();
		camShake = GameObject.Find("MainCamera").GetComponent<ShakeCamera> ();
		scoreText = GameObject.Find("ScoreText").GetComponent<Text> ();
		lifeText = GameObject.Find("LifeText").GetComponent<Text> ();
		buttonText = GameObject.Find("PauseButtonText").GetComponent<Text> ();

		paused = false;
		score = 0;
		scoreSinceHit = 0;
		life = 3;

		speed = BASE_SPEED;
	}
	
	// Update is called once per frame
	void Update () {
		speed = BASE_SPEED + Mathf.Log (scoreSinceHit + 1) * SPEED_FACTOR;
	}

	public void AddScore () {
		score += 1;
		scoreSinceHit += 1;
		scoreText.text = "Score: " + score;
	}

	public void LoseLife () {
		life -= 1;
		lifeText.text = "Life: " + life;

		scoreSinceHit = 0;

		// Shakes camera
		camShake.Shake(0.2f,0.5f);

		// Slow Down by 20%
		speed = speed * 0.8f;

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

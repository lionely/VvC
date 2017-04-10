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
	Rigidbody2D rb;

	public static int score;
	private int scoreSinceHit;
	private int life;

	public bool paused;
	private bool died;

	public float speed;

	private static float BASE_SPEED = -4.0f;
	private static float SPEED_FACTOR = -2.0f;

	public GameObject deathExplosion;

	// Use this for initialization
	void Awake () {
		player = GameObject.Find("Player").GetComponent<Player> ();
		rb = player.GetComponent<Rigidbody2D> ();
		camShake = GameObject.Find("MainCamera").GetComponent<ShakeCamera> ();
		scoreText = GameObject.Find("ScoreText").GetComponent<Text> ();
		lifeText = GameObject.Find("LifeText").GetComponent<Text> ();
		buttonText = GameObject.Find("PauseButtonText").GetComponent<Text> ();

		paused = false;
		died = false;
		score = 0;
		life = 3;
		speed = BASE_SPEED;
		scoreSinceHit = 0;
	}

	// Update is called once per frame
	void Update () {
		if (!paused) {
			speed = BASE_SPEED + Mathf.Log (scoreSinceHit + 1) * SPEED_FACTOR;
		}
		if (died) {
			paused = true;
			speed = 0;
			StartCoroutine(explode());
		}
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

		// Juice Effects
		LoseLifeEffects();

		if (life <= 0) {
			died = true;
		}
	}

	public void LoseLifeEffects () {
		// Pauses objects and decorations for 1 sec
		StartCoroutine(FreezeAndResume(1.0f));

		// Shakes camera (magnitude, duration)
		camShake.Shake(0.1f, 0.5f);
	}

	IEnumerator FreezeAndResume (float waitTime) {
		paused = true;
		player.GetComponent<TouchMovement>().enabled = false;

		float previousSpeed = speed;
		speed = 0; // pauses scrolling
		yield return new WaitForSeconds (waitTime);
		speed = previousSpeed;

		paused = false;
		player.GetComponent<TouchMovement>().enabled = true;
	}

	public void Pause () {

		paused = !paused;

		if (paused) {
			Time.timeScale = 0;
			buttonText.text = "Resume";
			player.GetComponent<TouchMovement>().enabled = false;
		}

		else if (!paused) {
			Time.timeScale = 1;
			buttonText.text = "Pause";
			player.GetComponent<TouchMovement>().enabled = true;
		}
	}

	IEnumerator explode(){
		yield return new WaitForSeconds (1.0f);

		player.GetComponent<TouchMovement>().enabled = false;
		Destroy(player.gameObject);	

		Instantiate (deathExplosion, new Vector3(rb.position.x, rb.position.y, 0), Quaternion.Euler(0, 0, 0));
		Invoke("LoadGameOver", 2);
	}

	public void LoadGameOver(){
		SceneManager.LoadScene ("GameOver",LoadSceneMode.Single);
	}
}
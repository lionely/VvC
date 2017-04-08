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

	public float speed;
	private float acceleration;
	public static int score;
	private int life;
	public bool paused;
	private bool exploded = false;

	private static float INITIAL_SPEED = -4.0f;
	private static float INITIAL_ACCELERATION = 0.01f;
	private static float ACCELERATION_DECAY = 0.9999f;

	public GameObject deathExplosion;
//	public AudioClip explosionSound;

	// Use this for initialization
	void Awake () {
		player = GameObject.Find("Player").GetComponent<Player> ();
		rb = player.GetComponent<Rigidbody2D> ();
		camShake = GameObject.Find("MainCamera").GetComponent<ShakeCamera> ();
		scoreText = GameObject.Find("ScoreText").GetComponent<Text> ();
		lifeText = GameObject.Find("LifeText").GetComponent<Text> ();
		buttonText = GameObject.Find("PauseButtonText").GetComponent<Text> ();

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

		if (exploded == false) {
			explode ();
		}
	}

	public void AddScore () {
		score += 1;
		scoreText.text = "Score: " + score;
	}

	public void LoseLife () {
		life -= 1;
		lifeText.text = "Life: " + life;

		// Shakes camera
		camShake.Shake(0.2f,0.5f);

		// Slow Down by 20%
		speed = speed * 0.8f;

		if (life <= 0) {
			//player.DestroyPlayer();
			//SceneManager.LoadScene ("GameOver",LoadSceneMode.Single);
			death();
		}
	}

	public void Pause () {

		paused = !paused;

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

	public void death(){
		rb.velocity = new Vector2(0.0f, 3.0f);
		Destroy(player.GetComponent<BoxCollider2D> ());
	}

	public void explode(){
		if (life <= 0 && rb.position.y >= 0.0f) {
			rb.velocity = new Vector2 (0.0f, 0.0f);
			Destroy (player.GetComponent<TouchMovement> ());
			Destroy (GameObject.Find ("FoodItems").GetComponent<Generate> ());
			Destroy (player.gameObject);	
			Instantiate (deathExplosion, new Vector3(rb.position.x, rb.position.y, 0), Quaternion.Euler(0, 0, 0));
			exploded = true;
			Invoke("LoadGameOver", 4);
		}
	}

	public void LoadGameOver(){
		SceneManager.LoadScene ("GameOver",LoadSceneMode.Single);
	}
}
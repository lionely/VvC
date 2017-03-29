using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	private Vector2 moveRight = new Vector2(100,0);

	private Rigidbody2D player;
	public GameController gameController;
	public Animator animator;

	private bool Vegan;

	//Do not forget for Addforce to work the rigidbody must be dynamic and simulated
	private void Awake(){
		player = GetComponent<Rigidbody2D>();
	}
		
	// Use this for initialization
	void Start () {
		Vegan = false;
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Moves Red right
		if(Input.GetKeyUp(KeyCode.RightArrow)){
			
			player.velocity = Vector2.zero;
			player.AddForce(moveRight);
			player.velocity = Vector2.zero;
		}
		//Moves Red left
		if(Input.GetKeyUp(KeyCode.LeftArrow)){
			player.velocity = Vector2.zero;
			player.AddForce(-1*moveRight);
			//player.velocity += Vector2.left*speed;
			player.velocity = Vector2.zero;
		}

		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
			// Get movement of the finger since last frame
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
			player.velocity = Vector2.zero;
			player.AddForce(moveRight);
			player.velocity = Vector2.zero;

			// Move object across XY plane
			//transform.Translate(-touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed, 0);
		}
	}

	void OnCollisionEnter2D(Collision2D col) {

		// Vegan Mode
		if (Vegan) {
			if (col.gameObject.tag == "Veggie") {
				Destroy(col.gameObject,.1f);
				gameController.AddScore();
			}
			else if (col.gameObject.tag == "Meat") {
				Destroy(col.gameObject,.1f);
				gameController.LoseLife();
			}
			else { // Mushroom 
				Destroy(col.gameObject,.1f);
				Vegan = !Vegan;
				animator.SetTrigger ("toCarnivore");
			}
		}
		// Canivore Mode
		else {
			if (col.gameObject.tag == "Veggie") {
				Destroy(col.gameObject,.1f);
				gameController.LoseLife();
			}
			else if (col.gameObject.tag == "Meat") {
				Destroy(col.gameObject,.1f);
				gameController.AddScore();
			}
			else { // Mushroom
				Destroy(col.gameObject,.1f);
				Vegan = !Vegan;
				animator.SetTrigger ("toVegan");
			}
		}
	}

	public void DestroyPlayer() {
		Destroy(this.gameObject);
	}
}

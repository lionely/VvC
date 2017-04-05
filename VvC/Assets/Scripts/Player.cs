using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public GameController gameController;
	public Animator animator;

	public GameObject veganBackground;
	public GameObject meatBackground;

	public static bool Vegan;

	private void Awake(){
		
	}
		
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		setVegan (); //Sets Initial Mode
		if (!Vegan) {
			switchBackground ();
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	// Sets Initial Mode
	void setVegan(){
		if (Vegan) {
			animator.SetTrigger ("toVegan");
		} 
		else 
		{
			animator.SetTrigger ("toCarnivore");
		}
	}

	// Ditects Collision
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
				switchBackground() ;
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
				switchBackground ();
				Vegan = !Vegan;
				animator.SetTrigger ("toVegan");
			}
		}
	}

	public void DestroyPlayer() {
		Destroy(this.gameObject);
	}

	public void switchBackground(){
		if (veganBackground.transform.position.x == 0.0f) {
			meatBackground.transform.position = new Vector3 (0.0f, -1.17f, 0.0f);
			veganBackground.transform.position = new Vector3 (-15.0f, -1.17f, 0.0f);
		} else {
			veganBackground.transform.position = new Vector3 (0.0f, -1.17f, 0.0f);
			meatBackground.transform.position = new Vector3 (-15.0f, -1.17f, 0.0f);;
		}
	}
}

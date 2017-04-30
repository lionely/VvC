using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public GameController gameController;
	public Animator animator;

	public GameObject veganBackground;
	public GameObject meatBackground;

	public static bool Vegan; // Type of player

	// Use this for initialization
	void Start () 
	{
		animator = GetComponent<Animator> ();
		setVegan (); //Sets Initial Mode
			}
	
	// Sets Initial  bg, and player animation.
	void setVegan(){
		if (Vegan) {
			animator.SetTrigger ("toVegan");
			veganBackground.SetActive (true);
			meatBackground.SetActive (false);
		} 
		else 
		{
			animator.SetTrigger ("toCarnivore");
			veganBackground.SetActive (false);
			meatBackground.SetActive (true);
		}
	}

	// Detects Collision
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
			else if (col.gameObject.tag == "Mushroom") {
				Destroy(col.gameObject,.1f);
				StartCoroutine(mushroom ());
				gameController.mushroomFreeze ();
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
			else if (col.gameObject.tag == "Mushroom") {
				Destroy(col.gameObject,.1f);
				StartCoroutine(mushroom ());
				gameController.mushroomFreeze();
				animator.SetTrigger ("toVegan");
			}
		}
	}
		
	IEnumerator mushroom(){
		Vegan = !Vegan;
		for (float f = 1; f <= 7; f++) {
			meatBackground.SetActive (!meatBackground.activeSelf);
			veganBackground.SetActive (!veganBackground.activeSelf);
			if (meatBackground.activeSelf) {
				animator.SetTrigger ("toCarnivore");
			} else {animator.SetTrigger ("toVegan");}
			yield return new WaitForSeconds (1.0f / (f + 5.0f));
		}
	}

}
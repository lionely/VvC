using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public GameController gameController;
	public Animator animator;

	public GameObject veganBackground;
	public GameObject meatBackground;

	public GameObject fader;

	public static bool Vegan;

	// Use this for initialization
	void Start () 
	{
		animator = GetComponent<Animator> ();
		setVegan (); //Sets Initial Mode
			}
	
	// Update is called once per frame
	void Update () {

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
//				Vegan = !Vegan;
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
				StartCoroutine(mushroom ());
				gameController.mushroomFreeze();
//				Vegan = !Vegan;
				animator.SetTrigger ("toVegan");
			}
		}
	}

	public void DestroyPlayer() {
		Destroy(this.gameObject);
	}

	public void switchBackground(){
		
		if (veganBackground.activeSelf) {
			meatBackground.SetActive (true);
			veganBackground.SetActive (false);
			Vegan = !Vegan;
		} else {
			veganBackground.SetActive (true);
			meatBackground.SetActive (false);
			Vegan = !Vegan;
			}
	}

	IEnumerator mushroom(){
		for (float f = 1; f <= 7; f++) {
			Invoke ("switchBackground", 1.0f / (f + 5.0f));
			if (Vegan) {
				animator.SetTrigger ("toCarnivore");
			} else {
				animator.SetTrigger ("toVegan");
			}
			yield return new WaitForSeconds (1.0f / (f + 5.0f));
		}
	}

	private void clearObstacle()
	{
		Instantiate(fader, fader.transform.position, fader.transform.rotation);

		//Bug not all items clear , not sure why at the moment.
		GameObject[] meatArray = GameObject.FindGameObjectsWithTag ("Meat"); 
		GameObject[] vegArray  = GameObject.FindGameObjectsWithTag("Veggie");
		GameObject[] mushArray = GameObject.FindGameObjectsWithTag("Mushroom");

		foreach(GameObject go in meatArray)
			Destroy(go);
		foreach (GameObject go in vegArray)
			Destroy (go);
		foreach (GameObject go in mushArray)
			Destroy (go);
	}


}
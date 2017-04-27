using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
	/**
	 * Causes the Obstacles (i.e. the veggies and the meat) to scroll down
	 */

	private float START_Y = 7.0f; // Below the navigation bar
	private float LEFTLANE_X = -2.5f;
	private float MIDLANE_X = 0.0f;
	private float RIGHTLANE_X = 2.5f;
	private Rigidbody2D rigi;
	private GameController gc;
	private float downward_speed;
	public float[] foodPosX;
	private int index;

	// Called when the obstacle is generated
	private void Awake(){
		rigi = GetComponent<Rigidbody2D>();
		// Retrieve the active instance of GameController, which has information on the game state (e.g. speed)
		gc = GameController.FindObjectOfType<GameController> ();
		rigi.velocity = new Vector2(0.0f, gc.speed);
		foodPosX = new float[3];
		foodPosX [0] = LEFTLANE_X;
		foodPosX [1] =  MIDLANE_X;
		foodPosX [2] = RIGHTLANE_X;
	}

	// Use this for initialization of an Obstacle
	void Start () {
		index = Random.Range (0, 3);
		transform.position = new Vector2 (foodPosX [index], START_Y);
	}

	// Called once per frame
	void Update () {
		// Set the speed of this object to the speed of the scene
		rigi.velocity = new Vector2 (0.0f, gc.speed);
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decoration : MonoBehaviour {

	private float START_Y = 7.0f; // Below the navigation bar
	private float LEFTLANE_X = -4.5f;
	private float RIGHTLANE_X = 4.5f;
	private Rigidbody2D rigi;
	private GameController gc;
	private float downward_speed;
	public float[] decorationPosX;
	private int index;



	// Called when the obstacle is generated
	private void Awake(){
		rigi = GetComponent<Rigidbody2D>();
		// Retrieve the active instance of GameController, which has information on the game state (e.g. speed)
		gc = GameController.FindObjectOfType<GameController> ();
		rigi.velocity = new Vector2(0.0f, gc.speed);
		decorationPosX     = new float[2];
		decorationPosX [0] = LEFTLANE_X;
		decorationPosX [1] = RIGHTLANE_X;
	}

	// Use this for initialization of an Obstacle
	void Start () {
		index = Random.Range (0, 2);
		transform.position = new Vector2 (decorationPosX [index], START_Y);
	}

	// Called once per frame
	void Update () {
		// Set the speed of this decoration to the speed of the scene
		rigi.velocity = new Vector2 (0.0f, gc.speed);
	}
}
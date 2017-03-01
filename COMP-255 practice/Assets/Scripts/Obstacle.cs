using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
	private Rigidbody2D rigi;
	private GameController gc;
	private float downward_speed;
	public float[] foodPosX;
	private int index;



	// Called when the obstacle is generated
	private void Awake(){
		rigi = GetComponent<Rigidbody2D>();
		gc = GameController.FindObjectOfType<GameController> ();
		rigi.velocity = new Vector2(0.0f, gc.speed);
		foodPosX     = new float[3];
		foodPosX [0] = -2.25f;
		foodPosX [1] =  0f;
		foodPosX [2] = 2.25f;

		
	}

	// Use this for initialization of an Obstacle
	void Start () {
		index = Random.Range (0, 3);
		transform.position = new Vector2 (foodPosX [index], 9); // Decided to put foods at y = 9.


	}

	// Called once per frame
	void Update () {
		rigi.velocity = new Vector2 (0.0f, gc.speed);
	}

}

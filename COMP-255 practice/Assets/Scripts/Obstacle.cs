using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
	private Rigidbody2D rigi;
	public Vector2 velocity = new Vector2 (0, -4);

	public float[] foodPosX;
	private int index;
	//public Transform obstaclePos = new Transform (0, 0, 0);




	//All at y=9

	private void Awake(){
		rigi = GetComponent<Rigidbody2D>();
		foodPosX     = new float[3];
		foodPosX [0] = -2.25f;
		foodPosX [1] =  0f;
		foodPosX [2] = 2.25f;

		
	}

	// Use this for initialization of an Obstacle
	void Start () {
		index = Random.Range (0, 3);
		transform.position = new Vector2 (foodPosX [index], 9); // Decided to put foods at y = 9.
		rigi.velocity = velocity; // sets velocity to the one above.


	}
	
	// Update is called once per frame
	void Update () {
		
		}


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenFood : MonoBehaviour {

	private float spawnPosition;
	private Rigidbody2D rigi;

	// Use this for initialization of an Obstacle
	void Start () {
		rigi = GetComponent<Rigidbody2D>();
		spawnPosition = Random.Range (-2, 3);
		transform.position = new Vector2 ((float) spawnPosition, 7.0f);
		rigi.velocity = new Vector2 (0.0f, -2.0f);
	}
}

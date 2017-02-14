using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
	private Rigidbody2D rigi;
	public Vector2 velocity = new Vector2 (0, -4);
	public float range = 4; // Range of random variation

	private void Awake(){
		rigi = GetComponent<Rigidbody2D>();
	}

	// Use this for initialization
	void Start () {
		rigi.velocity = velocity; // sets velocity to the one above.
		//transform.position = new Vector3 (transform.position.x - range * Random.value, 
			//transform.position.y , transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}

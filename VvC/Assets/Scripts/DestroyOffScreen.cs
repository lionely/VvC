using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOffScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Vege"  || col.gameObject.tag == "Meat") {
			//print ("Should be destroyed.");
			Destroy(col.gameObject,.5f);
		}
	}
}

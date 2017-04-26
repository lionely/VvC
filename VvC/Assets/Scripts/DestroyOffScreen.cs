using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOffScreen : MonoBehaviour {
	 
	//This script destroys all objects off screen.

	/*
	 * When an object offscreen collides with the
	 * block off-screen it is destroyed.
	 */
	void OnCollisionEnter2D(Collision2D col) {
			Destroy(col.gameObject,.5f);

	}
}

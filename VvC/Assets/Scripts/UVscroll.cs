using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVscroll : MonoBehaviour {
	/*
	 * Scrolls the background
	 */

	public Vector2 uvSpeed = new Vector2 (0.0f, 1.0f);
	Renderer renderer;
	Vector2 uvOffset = Vector2.zero;

	// The ratio of the "speed" variable in the GameController to the y-movement
	// in this script (to make it look equal to the user)
	private float SPEED_FACTOR = 0.04f;

	GameController gc;
	// Use this for initialization
	void Start () {
		renderer = GetComponent<Renderer>();
		gc = GameController.FindObjectOfType<GameController> ();
	}

	// Called once per frame, after all other update methods have been called
	void Update () {
		uvOffset += (new Vector2(0.0f, -gc.speed*SPEED_FACTOR) * Time.deltaTime);
		renderer.materials[0].SetTextureOffset ("_MainTex", uvOffset);
	}
}

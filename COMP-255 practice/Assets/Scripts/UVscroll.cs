using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVscroll : MonoBehaviour {


	public Vector2 uvSpeed = new Vector2 (0.0f, 1.0f);
	Renderer renderer;
	Vector2 uvOffset = Vector2.zero;
	// Use this for initialization
	void Start () {
		renderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame *Check
	void LateUpdate () {
		uvOffset += (uvSpeed * Time.deltaTime);
		renderer.materials[0].SetTextureOffset ("_MainTex", uvOffset);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour {
	public GameObject veggie1;
	public GameObject veggie2;

	public GameObject meat1;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("CreateObstacle", 1f, 1.5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void CreateObstacle(){
		Instantiate (veggie1);
		Instantiate (veggie2);
		Instantiate (meat1);
	}
}

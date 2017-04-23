using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodFall : MonoBehaviour {

	public GameObject[] food = new GameObject[6];
	private int foodIndex;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		foodIndex = Random.Range (0, 5);
		Instantiate (food [foodIndex]);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodFall : MonoBehaviour {

	public GameObject[] food = new GameObject[5];
	private int foodIndex;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("spawnItem", .5f, 2.0f);
	}
		

	void spawnItem(){
		foodIndex = Random.Range (0, 4);
		Instantiate (food [foodIndex]);
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodFall : MonoBehaviour {

	public GameObject[] food = new GameObject[4];
	private int foodIndex;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("spawnItem", .5f, .2f);
	}
		

	void spawnItem(){
		foodIndex = Random.Range (0, 3);
		Instantiate (food [foodIndex]);
	}

}

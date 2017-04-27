using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodFall : MonoBehaviour {

	public GameObject[] food = new GameObject[4];
	public float startTime;
	public float repeatRate;
	private int foodIndex;


	// Use this for initialization
	void Start () {
		InvokeRepeating ("spawnItem", startTime, repeatRate);
	}
		

	void spawnItem(){
		foodIndex = Random.Range (0, 3); //0-2
		Instantiate (food[foodIndex]);
	}

}

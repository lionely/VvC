using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour {
	
	public GameObject[] veggie = new GameObject[2];

	public GameObject[] meat = new GameObject[2];

	private int index;
	private int chanceVM; // if 0 make meat, else veggie


	// Use this for initialization
	void Start () {
		//print (chanceVM);
		InvokeRepeating ("CreateObstacle", 1f, 1.5f);
	}
	
	// Update is called once per frame
	void Update () {
		chanceVM = Random.Range (0, 2);
		index = Random.Range (0, 2);
	}
	void CreateObstacle(){
		print (chanceVM);
		if (chanceVM == 1) {
			Instantiate (veggie [index]);
		} else {
			Instantiate (meat [index]);
		}

	}
}

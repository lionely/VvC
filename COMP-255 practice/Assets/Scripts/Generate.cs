using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour {

	public GameObject[] veggie = new GameObject[2];
	public GameObject[] meat = new GameObject[2];
	public GameObject[] mushroom = new GameObject[1];

	public GameObject decoration;

	private int index;
	private int chanceVM; // if 0 make meat, else veggie

	// Use this for initialization
	void Start () {
		//print (chanceVM);
		InvokeRepeating ("CreateObstacle", 1f, .5f);
		InvokeRepeating ("CreateDecoration", 1f, 3f);
	}

	// Update is called once per frame
	void Update () {
		chanceVM = Random.Range (0, 11); // 0-10 
		index = Random.Range (0, 2); // 0 or 1
	}
	void CreateObstacle(){
		//print (chanceVM);
		// 45.5% Veggie
		if (chanceVM >= 0 && chanceVM <= 4) {
			Instantiate (veggie [index]);
			// 45.5% Meat
		}  else if (chanceVM >= 5 && chanceVM <= 9) {
			Instantiate (meat [index]);
			// 9% Mushroom
		}  else {
			Instantiate (mushroom [0]);
		}
	}

	//Creates different decorations randomly.
	void CreateDecoration(){
		if (chanceVM == 1) {
			Instantiate (decoration);
		}  else {
			Instantiate (decoration);
		}

	}

}

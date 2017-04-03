using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour {

	public GameObject[] veggie = new GameObject[2];
	public GameObject[] meat = new GameObject[2];
	public GameObject[] mushroom = new GameObject[1];

	public GameObject decoration;

	private GameController gc;

	private int index;
	private int chanceVM; // if 0 make meat, else veggie

	// Determines the relationship of GameController speed to Obstacle generation rate; higher = faster
	private float OBSTACLE_GENERATION_CONSTANT = 0.01f;

	// Same as above, for Decorations
	private float DECORATION_GENERATION_CONSTANT = 0.005f;

	// Stores the amount of time to go (unitless, sorry) until another Obstacle or Decoration is generated
	private float timeTillObstacle;
	private float timeTillDecoration;

	// Use this for initialization
	void Start () {
		gc = FindObjectOfType<GameController> ();

	}

	// Update is called once per frame
	void Update () {
		chanceVM = Random.Range (0, 11); // 0-10 
		index = Random.Range (0, 2); // 0 or 1

		timeTillObstacle -= OBSTACLE_GENERATION_CONSTANT;
		timeTillDecoration -= DECORATION_GENERATION_CONSTANT;
		if (timeTillObstacle <= 0.0f) {
			CreateObstacle ();
			timeTillObstacle = 1.0f / (-gc.speed);
		}
		if (timeTillDecoration <= 0.0f) {
			CreateDecoration ();
			timeTillDecoration = 1.0f / (-gc.speed);
		}
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

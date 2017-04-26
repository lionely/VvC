using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour {

	Player player;
	public GameObject[] veggie = new GameObject[3];
	public GameObject[] meat = new GameObject[3];
	public GameObject[] mushroom = new GameObject[1];

	public GameObject[] decorationMeat = new GameObject[3];
	public GameObject[] decorationVeggie = new GameObject[3];

	private GameController gc;

	private int index;
	private int decorationIndex; //Number corresponds to a decoration type
	private int chanceVM; // if 0 make meat, else veggie
	private int foodInARow = 0; //Keeps track of multiple types of food spawning in a row

	// Determines the relationship of GameController speed to Obstacle generation rate; higher = faster
	private float OBSTACLE_GENERATION_CONSTANT = 0.006f;

	// Same as above, for Decorations
	private float DECORATION_GENERATION_CONSTANT = 0.005f;

	// Stores the amount of time to go (unitless, sorry) until another Obstacle or Decoration is generated
	private float timeTillObstacle;
	private float timeTillDecoration;

	// Use this for initialization
	void Start () {
		gc = FindObjectOfType<GameController> ();
		//player = GameObject.Find("Player").GetComponent<Player> ();

	}

	// Update is called once per frame
	void Update () {
		chanceVM = Random.Range (0, 11); // 0-10 
		index = Random.Range (0, 2); // 0 or 1
		decorationIndex = Random.Range(0, 3); // 0-2

		// Only generate objects if game not paused
		if (!gc.paused) {

			// Decrement the time until the next Obstacle or
			// Decoration is generated
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
	}


	void CreateObstacle(){
		// 45.5% Veggie
		if (chanceVM >= 0 && chanceVM <= 4) {
			//Checks if two veggies have been spawned in a row to avoid impossible situations.
			if (foodInARow == -2) {
				Instantiate (meat [index]);
				foodInARow = 1;
			} else {
				Instantiate (veggie [index]);
				if (foodInARow > 0) {
					foodInARow = -1;
				}
				else{
					foodInARow -= 1;
				}
			}
			// 45.5% Meat
		}  else if (chanceVM >= 5 && chanceVM <= 9) {
			//Checks if two meat have been spawned in a row to avoid impossible situations.
			if (foodInARow == 2) {
				Instantiate (veggie [index]);
				foodInARow = -1;
			} else {
				Instantiate (meat [index]);
				if (foodInARow < 0) {
					foodInARow = 1;
				}
				else{
					foodInARow += 1;
				}
			}
			// 9% Mushroom
		}  else {
			Instantiate(mushroom[0]);
			foodInARow = 0;

		}
	}

	//Creates different decorations randomly.
	void CreateDecoration(){
		
		if (Player.Vegan) {
			Instantiate (decorationVeggie [decorationIndex]);
		}  else {
			Instantiate (decorationMeat [decorationIndex]);
		}

	}


}

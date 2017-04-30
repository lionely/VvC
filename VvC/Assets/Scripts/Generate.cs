using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour {

	Player player;
	public GameObject[] veggie = new GameObject[3]; //Veggie types
	public GameObject[] meat = new GameObject[3];
	public GameObject[] mushroom = new GameObject[1];

	public GameObject[] decorationMeat = new GameObject[3];
	public GameObject[] decorationVeggie = new GameObject[3];

	private GameController gc;

	private int obstacleIndex;	//Number corresponds to a obstacle type
	private int decorationIndex;
	private int chanceVM; // if 0 make meat, else veggie
	private int foodInARow = 0; //Keeps track of multiple types of food spawning in a row
	private int lastLane = 0; //Keeps track of the last lane food was spawned in

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
		player = GameObject.Find("Player").GetComponent<Player> ();

	}

	// Update is called once per frame
	void Update () {
		chanceVM = Random.Range (0, 2); // 0-10 
		obstacleIndex = Random.Range (0, 3); // 0-2
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
		
		if (!checkIfSpawnMushroom ()) {
			if (chanceVM == 0) {
				//Checks if two veggies have been spawned in a row to avoid impossible situations.
				spawnVegetable();
				// 45.5% Meat
			}  else if (chanceVM == 1) {
				//Checks if two meat have been spawned in a row to avoid impossible situations.
				spawnMeat();
				// 9% Mushroom
			}  
		}
	}

	bool checkIfSpawnMushroom(){
		if (player.veganBackground.activeSelf && foodInARow == 2) {
			Instantiate (mushroom [0]);
			foodInARow = 0;
			return true;
		}
		else if (player.meatBackground.activeSelf && foodInARow == -2) {
			Instantiate (mushroom [0]);
			foodInARow = 0;
			return true;
		}
		return false;
	}

	void spawnVegetable(){
		if (foodInARow == -2) {
			Instantiate (meat [obstacleIndex]);
			foodInARow = 1;
		} else {
			Instantiate (veggie [obstacleIndex]);
			if (foodInARow > 0) {
				foodInARow = -1;
			}
			else{
				foodInARow -= 1;
			}
		}
	}

	void spawnMeat(){
		if (foodInARow == 2) {
			Instantiate (veggie [obstacleIndex]);
			foodInARow = -1;
		} else {
			Instantiate (meat [obstacleIndex]);
			if (foodInARow < 0) {
				foodInARow = 1;
			}
			else{
				foodInARow += 1;
			}
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

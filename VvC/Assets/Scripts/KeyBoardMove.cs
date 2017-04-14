using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardMove : MonoBehaviour {

	private int pos = 0;
	private Rigidbody2D player;

	private void Awake(){
		player = GetComponent<Rigidbody2D>();
	}

	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown(KeyCode.LeftArrow)) 
				{ 
					this.transform.position = new Vector3 (player.transform.position.x - 2.25f, 
						player.transform.position.y, -1);
					pos = pos - 1;
				} 

				//touch right
		else if (Input.GetKeyDown(KeyCode.RightArrow)) 
				{ 
					this.transform.position = new Vector3 (player.transform.position.x + 2.25f, 
						player.transform.position.y, -1);
					pos = pos + 1;
				}

		
	}
}

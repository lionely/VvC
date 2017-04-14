using UnityEngine;
using System.Collections;

public class TouchMovement : MonoBehaviour {
	private int pos = 0;
	private Rigidbody2D player;

	private void Awake(){
		player = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		if (Input.touchCount > 0) 
		{
			Touch t = Input.GetTouch (0);

			if (t.phase == TouchPhase.Began) //At end of touch:
			{
				Vector3 touchPos = Camera.main.ScreenToWorldPoint(new Vector3(t.position.x, t.position.y, 0));          
				//touch left
				if (touchPos.x < player.position.x && touchPos.y < 6.5 && pos != -1) 
				{ 
					this.transform.position = new Vector3 (player.transform.position.x - 2.25f, 
						player.transform.position.y, -1);
					pos = pos - 1;
				} 

				//touch right
				else if (touchPos.x > player.position.x && touchPos.y < 6.5 && pos != 1) 
				{ 
					this.transform.position = new Vector3 (player.transform.position.x + 2.25f, 
						player.transform.position.y, -1);
					pos = pos + 1;
				}
			}
		}
	}
}

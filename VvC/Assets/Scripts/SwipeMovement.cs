using UnityEngine;
using System.Collections;

public class SwipeMovement : MonoBehaviour {
	private Touch initialTouch = new Touch();
	private float distance = 0;
	private bool hasSwiped = false;
	private int pos = 0;

	void FixedUpdate()
	{
		foreach(Touch t in Input.touches)
		{
			if (t.phase == TouchPhase.Began)
			{
				initialTouch = t;
			}
			else if (t.phase == TouchPhase.Moved && !hasSwiped)
			{
				float deltaX = initialTouch.position.x - t.position.x;
				float deltaY = initialTouch.position.y - t.position.y;
				distance = Mathf.Sqrt((deltaX * deltaX) + (deltaY * deltaY));
				bool swipedSideways = Mathf.Abs(deltaX) > Mathf.Abs(deltaY);

				if (distance > 1f)
				{
					if (swipedSideways && deltaX > 0 && pos != -1) //swiped left
					{
						this.transform.position = new Vector3(this.transform.position.x - 2.5f, 
							this.transform.position.y, -1);
						pos = pos - 1;
					}
					else if (swipedSideways && deltaX <= 0 && pos != 1) //swiped right
					{
						this.transform.position = new Vector3(this.transform.position.x + 2.5f, 
							this.transform.position.y, -1);
						pos = pos + 1;
					}
					hasSwiped = true;
				}

			}
			else if (t.phase == TouchPhase.Ended)
			{
				initialTouch = new Touch();
				hasSwiped = false;
			}
		}
	}
}

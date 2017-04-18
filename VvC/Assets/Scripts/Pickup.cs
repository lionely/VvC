using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

	public GameObject particles;
	public GameObject score;

	void OnTriggerEnter(Collider collider)
	{
		//Instantiate(particles,this.transform.position, Quaternion.identity);

		Vector3 viewPos = Camera.main.WorldToViewportPoint (this.transform.position);

		Instantiate(score, new Vector3(viewPos.x,viewPos.y,0), Quaternion.identity);
		Destroy(this.gameObject);
	}
}

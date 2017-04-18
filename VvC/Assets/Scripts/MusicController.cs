using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {

	void Awake()
	{			
		if(GameObject.FindGameObjectsWithTag("music").Length > 1)
			Destroy(this.gameObject);

		DontDestroyOnLoad(this.gameObject);
	}
}

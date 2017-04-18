using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour {

	float fadeDuration = 2.0f;

	void Start () 
	{
		StartCoroutine(Fade(1.0f, 0.0f, fadeDuration));
	}

	public IEnumerator Fade (float startLevel, float endLevel, float time)  
	{  
		float speed = (float) 1.0/time;
		Color c = GetComponent<GUIText>().material.color;

		for (float t = 0.0f; t < 1.0f; t += Time.deltaTime*speed) 
		{
			c.a = Mathf.Lerp(startLevel, endLevel, t);
			GetComponent<GUIText>().material.color = c;
			yield return true;
		}

		Destroy(this.gameObject);

	}

	void Update () 
	{
		this.transform.Translate(Vector3.up * 0.005f);
	}
}

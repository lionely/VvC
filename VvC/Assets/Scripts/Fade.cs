using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour {

	public Texture2D theTexture;

	float fade = 1f;
	float fadeInTime = 0.01f;// time it takes to become black


	void Awake()
	{
		DontDestroyOnLoad(this.gameObject);
	}


	// Use this for initialization
	void Start () {
		StopCoroutine("FadeInCoroutine");
		StartCoroutine("FadeInCoroutine");
	}
	
	//Fades

	IEnumerator FadeInCoroutine()
	{
		while(true)
		{
			fade = 0;
			float time = 0f;
			while (time < fadeInTime)
			{
				yield return true;
				fade += Time.deltaTime / fadeInTime;
				time += Time.deltaTime;
			}

			fade = 1;
			time = 20;


			yield return new WaitForSeconds(0.3f);//time to wait before fading Out

			while (time < (20 + fadeInTime))
			{
				yield return true;
				fade -= Time.deltaTime / fadeInTime;
				time += Time.deltaTime;
			}

			fade = 0;
			Destroy(this.gameObject);
		}
	}

	void OnGUI()
	{
			GUI.depth = 0;
			if (fade > 0)
			{
				Color c = Color.white;
				c.a = fade;
				GUI.color = c;
				GUI.DrawTexture(new Rect(0,0, Screen.width, Screen.height), theTexture);
			}
		

	}
}

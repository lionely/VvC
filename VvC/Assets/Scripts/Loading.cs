using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour {
	//Sourced from Holistic Mobile Game development
	/*
	 * This script creates the fading effect in between scenes.
	 */ 
	public static string levelToLoad;
	public Texture2D theTexture;
	
	float fade = 1f;
	float fadeInTime = 1f;
	
	void Awake()
	{
	    StopCoroutine("FadeInCoroutine");
		StartCoroutine("FadeInCoroutine");
		}
	

	//Fades inbetween screens.
	
	IEnumerator FadeInCoroutine()
	{
	    while(true)
	    {
	        fade = 0;
	        float time = 0f;
	        while (time < fadeInTime)
	        {
	            yield return true;
	            fade += Time.deltaTime / fadeInTime; //Fades in
	            time += Time.deltaTime;
	        }

	        fade = 1;
	        time = 20;

			SceneManager.LoadScene (levelToLoad);//loads scenes

			while (time < (20 + fadeInTime))
	        {
	            yield return true;
	            fade -= Time.deltaTime / fadeInTime; // Fades out
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
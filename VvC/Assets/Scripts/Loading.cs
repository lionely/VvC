using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour {
	//Sourced from Holistic Mobile Game development
	public static string levelToLoad;
	public Texture2D theTexture;
	
	float fade = 1f;
	float fadeInTime = 1f;
	
	void Awake()
	{
	    //DontDestroyOnLoad(this.gameObject);

//		if (FindObjectsOfType(GetType()).Length > 1)
//		{
//			Destroy(gameObject);
//		}

		StopCoroutine("FadeInCoroutine");
		StartCoroutine("FadeInCoroutine");
		//print ("Loading awake");
	}
	
	void Start()
	{
//	    StopCoroutine("FadeInCoroutine");
//	    StartCoroutine("FadeInCoroutine");
		//print ("Loading start coroutine");
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
	            fade += Time.deltaTime / fadeInTime;
	            time += Time.deltaTime;
	        }

	        fade = 1;
	        time = 20;

			SceneManager.LoadScene (levelToLoad);//loads scenes
			//print("Loaded gameplay");

	    	//yield return async;
	
	        while (time < (20 + fadeInTime))
	        {
	            yield return true;
	            fade -= Time.deltaTime / fadeInTime;
	            time += Time.deltaTime;
	        }

	        fade = 0;
			Destroy(this.gameObject);
			//print ("Loading was destroyed");
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
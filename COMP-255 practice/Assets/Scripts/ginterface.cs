using UnityEngine;
using System.Collections;

public class ginterface : MonoBehaviour 
{
	public static int totalScore = 0;
	
	void OnGUI()
	{
		GUI.Label(new Rect(10,10,100,30), "Score: " + totalScore.ToString());	
	
		if(GUI.Button(new Rect(Screen.width - 100,10,100,30), "Back"))
		{
			Application.LoadLevel("firstscene");
		}

	
	}
	
	
	
}


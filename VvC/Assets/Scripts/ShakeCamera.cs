using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour {

	public Camera mainCam;
	public float shakeTime; 
	public float shakeAmount;

	void Awake () {
		if (mainCam == null) {
			mainCam = Camera.main;
		}
	}

	public void Shake (float shakePwr, float shakeDur) {
		shakeAmount = shakePwr;
		InvokeRepeating ("DoShake", 0, 0.01f);
		Invoke ("StopShake", shakeDur);
	}

	void DoShake () {
		if (shakeAmount > 0) {

			Vector3 camPos = mainCam.transform.position;

			// random equation for shaking
			float offsetX = Random.value * shakeAmount * 2 - shakeAmount;
			float offsetY = Random.value * shakeAmount * 2 - shakeAmount;

			camPos.x += offsetX;
			camPos.y += offsetY;

			mainCam.transform.position = camPos;
		}
	}

	void StopShake () {
		CancelInvoke ("DoShake");
		mainCam.transform.localPosition = Vector3.zero;
	}
}

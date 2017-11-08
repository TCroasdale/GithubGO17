using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shakeable : MonoBehaviour, iSuckable {

	public bool isShaking = false;
	public float shakeTime = 0.1f;
	float timer;
	public Vector3 shakeAmt = new Vector3(0.04f, 0 , 0);
	public float shakeSpeed = 25.0f;

	Vector3 originalPos;
	public Transform objToShake;

	// Update is called once per frame
	void Update () {
		if(isShaking){
			timer -= Time.deltaTime;
			if(timer <=0){
				endShake();
			}

			//shaking code
			objToShake.localPosition = Mathf.Sin(Time.time * shakeSpeed) * shakeAmt;
		}
	}

	public void onSuck(Vector3 o, float p){
		shake();
	}

	public void onBlow(Vector3 o, float p){
		shake();
	}

	void shake(){
		originalPos = objToShake.localPosition;
		isShaking = true;
		timer = shakeTime;
	}

	void endShake(){
		objToShake.localPosition = originalPos;
		isShaking = false;
	}
}

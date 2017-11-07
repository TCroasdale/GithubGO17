using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuckerScript : MonoBehaviour {

	public float suckPower = 5;
	public float blowPower = 5;

	public bool isSucking = true;

	// Use this for initialization
	void Start () {
		turnOff();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void turnOn(bool suck){
		isSucking = suck;
		gameObject.SetActive(true);
	}

	public void turnOff(){
		gameObject.SetActive(false);
	}

	void OnTriggerEnter(Collider other){
		iSuckable comp = (iSuckable)other.GetComponent(typeof(iSuckable));
		if(comp != null){
			if(isSucking){
				comp.onSuck(transform.parent.position, suckPower);
			}else{
				comp.onBlow(transform.parent.position, blowPower);
			}
		}
	}
}

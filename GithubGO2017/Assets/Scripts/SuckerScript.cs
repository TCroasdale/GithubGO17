using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuckerScript : MonoBehaviour {

	public float power = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		Debug.Log("Sucking");
		iSuckable comp =(iSuckable)other.GetComponent(typeof(iSuckable));
		if(comp != null){
			comp.onSuck(transform.parent.position, power);
		}
	}
}

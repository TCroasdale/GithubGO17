using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotScript : MonoBehaviour, iSuckable {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onSuck(Vector3 suckOrigin, float power){
		GetComponent<Rigidbody>().AddForce((suckOrigin - transform.position) * power, ForceMode.Force);
	}
}

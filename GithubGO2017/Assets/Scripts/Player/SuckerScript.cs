using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuckerScript : MonoBehaviour {

	public float suckPower = 5;
	public float blowPower = 5;

	public bool isSucking = true;

	public GameObject suckParticles;
	public GameObject blowParticles;

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
		if(isSucking){
			suckParticles.SetActive(true);
		}else{
			blowParticles.SetActive(true);
		}
	}

	public void turnOff(){
		gameObject.SetActive(false);
		if(isSucking){
			suckParticles.SetActive(false);
		}else{
			blowParticles.SetActive(false);
		}
	}

	void OnTriggerStay(Collider other){
		iSuckable comp = (iSuckable)other.GetComponent(typeof(iSuckable));
		if(comp != null){
			if(isSucking){
				comp.onSuck(transform.parent.position, suckPower);
			}else{
				comp.onBlow(transform.parent.position, blowPower);
			}
		}
	}

    void OnTriggerExit(Collider other){
        iSuckable comp = (iSuckable)other.GetComponent(typeof(iSuckable));
		if(comp != null){
			comp.onFinishedInteraction();
		}
    }
}

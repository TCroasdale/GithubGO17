using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour, iSuckable {

	public GameObject cleanMesh;
	public GameObject brokenMesh;
	bool isBroke;

	float maxH = 100.0f;
	public float Health = 100.0f;

	public Collider cleanCollider;
	public Collider brokenCollider;

	public shakeable shaker;

	public GameObject hiddenObject;
	public Transform hidObjPos;

	// Use this for initialization
	void Start () {
		maxH = Health;
		reset();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onSuck(Vector3 o, float p){
		damage(p);
		shaker.onSuck(o, p * (Health / maxH));
	}

	public void onBlow(Vector3 o, float p){
		damage(p);
		shaker.onSuck(o, p * (Health / maxH));
	}

    public void onFinishedInteraction(){}

	void damage(float amt){
		Health -= amt;
		if(Health <= 0.0f){
			cleanMesh.SetActive(false);
			brokenMesh.SetActive(true);
			if(cleanCollider != null) cleanCollider.isTrigger = true;
			if(brokenCollider != null) brokenCollider.isTrigger = false;
			if(shaker != null) shaker.objToShake = brokenMesh.transform;

			if(!isBroke){
				if(hiddenObject != null) Instantiate(hiddenObject, hidObjPos.position, Quaternion.identity);
			}
			isBroke = true;
		}
	}

	public void reset(){
		cleanMesh.SetActive(true);
		brokenMesh.SetActive(false);
		if(cleanCollider != null) cleanCollider.isTrigger = false;
		if(brokenCollider != null) brokenCollider.isTrigger = true;
		if(shaker != null) shaker.objToShake = cleanMesh.transform;
		Health = maxH;
		isBroke = false;
	}
}

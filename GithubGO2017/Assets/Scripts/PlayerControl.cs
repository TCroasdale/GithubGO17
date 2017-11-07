using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	public float moveSpeed = 4.0f;
	public float rotSpeed = 4.0f;

	public CharacterController c_Control;

	public SuckerScript sucker;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float in_h = Input.GetAxis("Horizontal");
		float in_v = Input.GetAxis("Vertical");

		Vector3 dir = new Vector3(in_h, 0, in_v);

		Quaternion prevRot = transform.rotation;
		Quaternion targRot ;
		Vector3 lookDir;

		if(Input.GetButtonDown("Suck")){
			sucker.turnOn();
		}
		if(Input.GetButtonUp("Suck")){
			sucker.turnOff();
		}

		if(Input.GetButton("Suck")){

			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Plane playerPlane = new Plane(Vector3.up, transform.position);
			float hit_dist = 0.0f;
			if(playerPlane.Raycast(ray, out hit_dist)){
				Vector3 mPos = ray.GetPoint(hit_dist);
				lookDir = (mPos - transform.position);
				lookDir.y = 0;	
			}else{
				lookDir = dir;
			}
		
		}else{
			lookDir = dir;
		}
		if(lookDir != Vector3.zero){
			targRot = Quaternion.LookRotation(lookDir.normalized, Vector3.up);
		}else{
			targRot = prevRot;
		}
		transform.rotation = Quaternion.Slerp(prevRot, targRot, rotSpeed * Time.deltaTime);

		if(!c_Control.isGrounded){ dir.y = Physics.gravity.y * Time.deltaTime; }
		c_Control.Move(new Vector3(dir.x * moveSpeed * Time.deltaTime, dir.y, dir.z * moveSpeed * Time.deltaTime));
	}
}

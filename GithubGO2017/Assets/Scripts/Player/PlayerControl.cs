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
		doMove();

		
	}

	

	void doMove(){
		float in_h = Input.GetAxis("Horizontal"); //movement axis
		float in_v = Input.GetAxis("Vertical");

		float look_h = Input.GetAxis("Look X"); //look axis for controller
		float look_v = Input.GetAxis("Look Y");


		Vector3 moveDir = new Vector3(in_h, 0, in_v); //raw movement vector

		if(moveDir.magnitude > 1){ moveDir /= moveDir.magnitude; }

		Quaternion prevRot = transform.rotation;
		Quaternion targRot ;
		Vector3 lookDir = new Vector3(look_h, 0, -look_v); //0 if no controller input

		bool suckPressed = Input.GetButtonDown("Suck");
		bool blowPressed = Input.GetButtonDown("Blow");
		bool suckReleased = Input.GetButtonUp("Suck");
		bool blowReleased = Input.GetButtonUp("Blow");
		bool suckDown = Input.GetButton("Suck");
		bool blowDown = Input.GetButton("Blow");

		if(suckPressed || blowPressed){ //if sucking or blowing, turn on sucker
			sucker.turnOn(suckPressed);
		}
		if(suckReleased || blowReleased){ //on release stop.
			sucker.turnOff();
		}

		if(suckDown || blowDown){ //while sucking and blowing.
			if(lookDir.magnitude == 0){ //If no controller input
				//Convert mouse direction to in game direction.
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				Plane playerPlane = new Plane(Vector3.up, transform.position);
				float hit_dist = 0.0f;
				if(playerPlane.Raycast(ray, out hit_dist)){
					Vector3 mPos = ray.GetPoint(hit_dist);
					lookDir = (mPos - transform.position);
					lookDir.y = 0;	
				}else{
					lookDir = moveDir;
				} 
			}	
			//if controller input don't need to do anything
			//as lookDir already has the right values.	
		}else{
			lookDir = moveDir;
		}

		if(lookDir != Vector3.zero){ //if lookDir isn't 0 set targRot to lookDir 
			targRot = Quaternion.LookRotation(lookDir.normalized, Vector3.up);
		}else{ //else dontarget rotation is current rotation.
			targRot = prevRot;
		}
		
		//slerp the rotation.
		transform.rotation = Quaternion.Slerp(prevRot, targRot, rotSpeed * Time.deltaTime);

		//if in air apply gravity.
		if(!c_Control.isGrounded){ moveDir.y = Physics.gravity.y * Time.deltaTime; }
		//move according to moveDir
		c_Control.Move(new Vector3(moveDir.x * moveSpeed * Time.deltaTime, moveDir.y, moveDir.z * moveSpeed * Time.deltaTime));
	}
}

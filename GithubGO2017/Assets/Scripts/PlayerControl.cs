using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	public float moveSpeed = 4.0f;
	public float rotSpeed = 4.0f;

	public CharacterController c_Control;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float in_h = Input.GetAxis("Horizontal");
		float in_v = Input.GetAxis("Vertical");

		Quaternion prevRot = transform.rotation;
		Vector3 dir = new Vector3(in_h, 0, in_v);
		Quaternion targRot ;
		if(dir != Vector3.zero){
			targRot = Quaternion.LookRotation(dir, Vector3.up);
		}else{
			targRot = prevRot;
		}

		transform.rotation = Quaternion.Slerp(prevRot, targRot, rotSpeed * Time.deltaTime);

		if(!c_Control.isGrounded){ dir.y = Physics.gravity.y * Time.deltaTime; }
		c_Control.Move(new Vector3(dir.x * moveSpeed, dir.y, dir.z * moveSpeed));
	}
}

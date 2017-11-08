using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	public Transform target;
	public Vector3 offset = new Vector3(0, 0, -4);
	public float targetHeight = 4.0f;
	public float moveSpeed = 4.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 tPos = target.position;
		tPos.y = targetHeight;
		transform.position = Vector3.Lerp(transform.position, tPos + offset, Time.deltaTime *moveSpeed);

		//transform.LookAt(target);
	}
}

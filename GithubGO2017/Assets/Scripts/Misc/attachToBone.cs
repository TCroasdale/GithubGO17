using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attachToBone : MonoBehaviour {

    public Transform bone;

	// Use this for initialization
	void Start () {
		transform.parent = bone;
		transform.localPosition = Vector3.zero;
		transform.localRotation = Quaternion.identity;
	}
	
}

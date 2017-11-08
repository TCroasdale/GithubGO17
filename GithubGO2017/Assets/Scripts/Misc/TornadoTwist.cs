using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoTwist : MonoBehaviour {

	public float Degps = 3.6f;

	// Update is called once per frame
	void Update () {
		transform.RotateAroundLocal(Vector3.forward, Degps * Time.deltaTime);
	}
}

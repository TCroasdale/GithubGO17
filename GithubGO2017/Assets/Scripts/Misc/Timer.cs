using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Timer :System.Object {

    public float time;
    bool valid;
    float count;

	// Update is called once per frame
	public void doUpdate (float dT) {
		if(!valid){
            count -= dT;
            if(count <= 0){
                valid = true;
            }
        }
	}

    public void start(){
        count = time;
        valid = false;
    }

    public bool getDone(){ return valid; }
}

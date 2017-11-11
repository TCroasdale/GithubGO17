using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TileTexture : MonoBehaviour {

    enum SurfaceDirection { XY, XZ, YZ }

    [SerializeField]
    SurfaceDirection surfDir;

	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().material.mainTexture.wrapMode = TextureWrapMode.Repeat;
        if(transform.localScale != new Vector3(1, 1, 1)){
            Vector2 s = new Vector2(1, 1);
            Vector3 absS = transform.localScale;
            if(surfDir == SurfaceDirection.XY){ s = new Vector2(absS.x, absS.y); }
            else if(surfDir == SurfaceDirection.XZ){ s = new Vector2(absS.x, absS.z); }
            else { s = new Vector2(absS.y, absS.z); }
            GetComponent<Renderer>().material.mainTextureScale = s;
        }
	}

}

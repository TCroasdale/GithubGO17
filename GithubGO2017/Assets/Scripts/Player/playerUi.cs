using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerUi : MonoBehaviour {

    public List<RawImage> heartsUi;
    public Texture fullHeart;
    public Texture emptyHeart;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setHeartsVisible(int numHearts){
        for(int h = 0; h < heartsUi.Count; h++){
            heartsUi[h].enabled = (h < numHearts);
        }
    }

    public void setFullHeartCount(int numHearts){
        for(int h = 0; h < heartsUi.Count; h++){
            if(h < numHearts){
                heartsUi[h].texture = fullHeart; 
            }else{
                heartsUi[h].texture = emptyHeart; 
            }
        }
    }
}

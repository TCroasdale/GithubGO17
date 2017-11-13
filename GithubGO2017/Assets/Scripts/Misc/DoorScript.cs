using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour, iInteraction {

    public bool locked = false;

    public string sceneToLoad = "";
    public bool loadNewScene = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void open(){
        gameObject.SetActive(false);
    }

    public void onUse(Player player){
        if(!locked){ open(); }
        else{
            if(player.inventory[Item.KEY] > 0){
                open();
                player.inventory[Item.KEY] -= 1;
            }
        }
    }
}

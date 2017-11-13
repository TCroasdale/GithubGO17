using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestScript : MonoBehaviour, iInteraction  {

	public Item containedItem;

    public GameObject hiddenObj;
    
    bool isOpen = false;
    [SerializeField]
    Animator anim;

    void start(){
        hiddenObj.SetActive(false);
    }

	public void onUse(Player player){
        if(!isOpen){
		    player.inventory[containedItem] += 1;
            anim.SetBool("isOpen", true);
            hiddenObj.SetActive(true);
        }
	}
}

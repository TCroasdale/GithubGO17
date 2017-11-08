using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestScript : MonoBehaviour, iInteraction  {

	public iItem containedItem;

	public void onUse(Player player){
		Debug.Log("used!");
	}
}

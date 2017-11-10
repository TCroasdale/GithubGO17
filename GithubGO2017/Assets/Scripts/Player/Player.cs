using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public PlayerControl p_Control;
    public playerUi p_Ui;

	public int score = 0;
	public int numKeys = 0;

	public float interactDist = 3.0f;

    public int maxHP;
    public int hitPoints;

	// Use this for initialization
	void Start () {
        hitPoints = maxHP;
        p_Ui.setHeartsVisible(maxHP);
        p_Ui.setFullHeartCount(hitPoints);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Interact")){
			doInteract();
		}
	}

	void doInteract(){
		RaycastHit hit;
		if(Physics.Raycast(transform.position, transform.forward, out hit, interactDist)){
			iInteraction thing = (iInteraction)hit.transform.GetComponent(typeof(iInteraction));
			if(thing != null){
				thing.onUse(GetComponent<Player>());
			}
		}
	}


	void OnCollisionEnter(Collision col){
		if(col.collider.transform.tag == "Dot"){
			score++;
			Destroy(col.collider.gameObject);
		}
		else if(col.collider.transform.tag == "PowerPellet"){
            GameObject[] gO = GameObject.FindGameObjectsWithTag("Ghost");
            foreach(GameObject g in gO){
                g.GetComponent<Ghost>().setScared();
            }

			Destroy(col.collider.gameObject);
		}
	}

    void OnTriggerEnter(Collider col){
        if(col.transform.tag == "Damager"){
            takeDamage(1);
        }
    }

    public void takeDamage(int d){
        hitPoints -= d;
        p_Ui.setFullHeartCount(hitPoints);
    }
}

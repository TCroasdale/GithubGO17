using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Item { KEY }

public class Player : MonoBehaviour {

	public PlayerControl p_Control;
    public playerUi p_Ui;

	public int score = 0;

	public float interactDist = 3.0f;

    public int maxHP;
    public int hitPoints;
    public Timer invulnTimer;

    public Dictionary<Item, int> inventory;
    
    
    
	// Use this for initialization
	void Start () {
        hitPoints = maxHP;
        p_Ui.setHeartsVisible(maxHP);
        p_Ui.setFullHeartCount(hitPoints);

        setUpInventory();
	}
	
    void setUpInventory(){
        inventory = new Dictionary<Item, int>();
        inventory.Add(Item.KEY, 0);
    }

	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Interact")){
			doInteract();
		}

        invulnTimer.doUpdate(Time.deltaTime);
	}

	void doInteract(){
		RaycastHit hit;
		if(Physics.Raycast(transform.position, transform.forward, out hit, interactDist)){
			iInteraction thing = (iInteraction)hit.transform.GetComponent(typeof(iInteraction));
			if(thing != null){
				thing.onUse(this);
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
        if(invulnTimer.getDone()){
            Debug.Log("Taking damage!");
            hitPoints -= d;
            p_Ui.setFullHeartCount(hitPoints);
            invulnTimer.start();
        }
    }
}

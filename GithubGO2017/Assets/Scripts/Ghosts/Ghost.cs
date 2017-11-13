using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour, iSuckable {

    public Ai ai;

    float maxHealth;
    public float Health = 100;
    public float dps = 6.0f;


    public Timer scaredTimer;

    public Transform target;

    public Transform mesh;
    public Material normalMaterial;
    public Material specialMaterial;

    CharacterController c_Control;
    public float moveSpeed;
    public float rotSpeed = 2.0f;
    bool canMove = true;

    public Color suckerColor;

    Animator anim;

    public GhostUi ui;
    public int numHearts = 3;
    int currHearts = 3;

	// Use this for initialization
	void Start () {
		transform.tag = "Ghost";
        normalMaterial = mesh.GetComponent<Renderer>().material;
        GetComponent<Ai>().setTarget(target);
        c_Control = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

        currHearts = numHearts;
        maxHealth = Health;
        ui.setHeartsVisible(numHearts);
        ui.setFullHeartCount(currHearts);
	}
	
	// Update is called once per frame
	void Update () {
		if(ai.GetState() == Ai.EnemyState.SCARED){
            if(scaredTimer.getDone()){
                resetScared();
            }
        }

        Vector3 dir = ai.think();

        Quaternion lookDir = Quaternion.LookRotation(dir, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookDir, Time.deltaTime * rotSpeed);
        dir.y += Physics.gravity.y * Time.deltaTime; 
        if(canMove) c_Control.Move(dir * moveSpeed * Time.deltaTime);
        canMove = true;


        scaredTimer.doUpdate(Time.deltaTime);
	}

    public void setScared(){
        ai.setState(Ai.EnemyState.SCARED);

        scaredTimer.start();
        mesh.GetComponent<Renderer>().material = specialMaterial;
        anim.SetBool("scared", true);
    }

    public void resetScared(){
        ai.setState(Ai.EnemyState.NORMAL);
        mesh.GetComponent<Renderer>().material = normalMaterial;
        anim.SetBool("scared", false);
        anim.SetBool("sucked", false);
    }


    void doDamage(int dmg){
        if(ai.GetState() == Ai.EnemyState.SCARED){
            Health -= dps * Time.deltaTime;
            canMove = false;
            if(Health < ((currHearts-1) / (float)numHearts) * maxHealth){
                currHearts --;
                ui.setFullHeartCount(currHearts);
            }

            if(Health <= 0){
                Destroy(gameObject);
                ui.showHearts(false);
            }
        }
    }

    public Color changeColor() { return suckerColor; }

    public void onSuck(Vector3 o, float p){
        doDamage(3);
        anim.SetBool("sucked", true);
    }

    public void onBlow(Vector3 o, float p){
        doDamage(3);
    }

    public void onFinishedInteraction(){
        anim.SetBool("sucked", false);
    }

}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour, iSuckable {

    public Ai ai;

    public float Health = 100;
    public float dps = 6.0f;


    public float scaredTimer = 10.0f;
    float timer;

    public Transform target;

    public Transform mesh;
    public Material normalMaterial;
    public Material specialMaterial;

    CharacterController c_Control;
    public float moveSpeed;
    bool canMove = true;


    Animator anim;

	// Use this for initialization
	void Start () {
		transform.tag = "Ghost";
        normalMaterial = mesh.GetComponent<Renderer>().material;
        GetComponent<Ai>().setTarget(target);
        c_Control = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(ai.GetState() == Ai.EnemyState.SCARED){
            timer -= Time.deltaTime;
            if(timer <= 0){
                resetScared();
            }
        }

        Vector3 dir = ai.think();

        Quaternion lookDir = Quaternion.LookRotation(dir, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookDir, Time.deltaTime);
        dir.y += Physics.gravity.y * Time.deltaTime; 
        if(canMove) c_Control.Move(dir * moveSpeed * Time.deltaTime);
        canMove = true;

	}

    public void setScared(){
        ai.setState(Ai.EnemyState.SCARED);

        timer = scaredTimer;
        mesh.GetComponent<Renderer>().material = specialMaterial;
        anim.SetBool("scared", true);
    }

    public void resetScared(){
        ai.setState(Ai.EnemyState.NORMAL);
        mesh.GetComponent<Renderer>().material = normalMaterial;
        anim.SetBool("scared", false);
    }


    void doDamage(int dmg){
        if(ai.GetState() == Ai.EnemyState.SCARED){
            Health -= dps * Time.deltaTime;
            canMove = false;
        }
    }

    public void onSuck(Vector3 o, float p){
        doDamage(3);
    }

    public void onBlow(Vector3 o, float p){
        doDamage(3);
    }



}
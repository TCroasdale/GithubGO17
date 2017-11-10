using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkyAi : Ai {

    [SerializeField]
    float attackDist = 1.5f;

    public GameObject fist;

    public override Vector3 think(){
        if(state == EnemyState.NORMAL){
            return doNormal();
        }
        else if(state == EnemyState.SCARED){
            return doScared();
        }
        else if(state == EnemyState.ATTACKING){
            return doAttacking();
        }



        return Vector3.zero;
    }

    Vector3 doNormal(){
        Vector3 thisPos = transform.position;
        Vector3 targPos = target.position;
        Vector3 moveDir = new Vector3(targPos.x - thisPos.x, 0, targPos.z - thisPos.z);
        float distToTarg = moveDir.magnitude;
        moveDir.Normalize();

        if(distToTarg < attackDist) setState(EnemyState.ATTACKING); 

        return moveDir;
    }

    Vector3 doAttacking(){
        fist.SetActive(true);
        GetComponent<Animator>().SetTrigger("attack");
        AnimatorStateInfo animStateInfo = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
        if(animStateInfo.IsName("Base.normal_run")) {
            setState(EnemyState.NORMAL);
            fist.SetActive(false);
        }

        Vector3 thisPos = transform.position;
        Vector3 targPos = target.position;
        Vector3 dir = new Vector3(targPos.x - thisPos.x, 0, targPos.z - thisPos.z);
        dir.Normalize();
        return dir;
    }



}

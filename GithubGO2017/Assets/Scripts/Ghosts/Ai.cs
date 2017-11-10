using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ai : MonoBehaviour {

    public enum EnemyState{ NORMAL, SCARED, ATTACKING, CHASING, HIDING }

    public EnemyState state;

    protected Transform target;
    public void setTarget(Transform t){ target = t; }

    public void setState(EnemyState s){ state = s; }
    public EnemyState GetState(){ return state; }
    public abstract Vector3 think();

    protected Vector3 doScared(){
        Vector3 thisPos = transform.position;
        Vector3 targPos = target.position;
        Vector3 moveDir = new Vector3(thisPos.x - targPos.x, 0, thisPos.z - targPos.z);
        moveDir.Normalize();

        return moveDir;
    }
}

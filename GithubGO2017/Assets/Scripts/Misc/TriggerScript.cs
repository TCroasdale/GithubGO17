using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour {

    [SerializeField]
    public List<GameObject> eventHolders;

    List<iTriggerable> events = new List<iTriggerable>();

    void Start(){

        foreach(GameObject eh in eventHolders){
            events.Add(eh.GetComponent(typeof(iTriggerable)) as iTriggerable);
        }
    }

    void OnTriggerEnter(Collider other){
        Debug.Log("TRIGGERED");
        if(other.tag == "Player"){
            foreach(iTriggerable e in events){
                e.fireEvent();
            }
        }
    }
}

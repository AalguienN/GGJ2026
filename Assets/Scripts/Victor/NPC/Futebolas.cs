using UnityEngine;
using System.Collections.Generic;

public class Futebolas : NPCBase {

  public List<GameObject> npcs;
  private bool hasEnded; 
  private int targetID;

  public override void Start() {
    base.Start();    
  }

  void Update() {
    transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
     if(!suspiciometer_.isDetected_)
      Behaviour();
    else
      CallThePolice();
  }

  public override void Behaviour(){
    if(hasEnded){
      targetID = Random.Range(1, npcs.Count);
      hasEnded = false;
    }
    if(!hasEnded){
      Vector3 target = npcs[targetID].transform.position;
      navAgent_.SetDestination(target);
      if(AtEndOfPath()){
        hasEnded = true;
      }
    }
  }


}

using System.Collections.Generic;
using UnityEngine;

public class Mustang : NPCBase {

  public List<GameObject> interestPoints_;
  public float currentTime_;
  public float maxTime_;
  public float timeMultiplier_;
  public int currentDestination_;
  public bool hasReachedPosition;

  public override void Start() {
    currentDestination_ = 1;

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
    if(!hasReachedPosition){
      navAgent_.SetDestination(interestPoints_[currentDestination_ % 3].transform.position);
      if(AtEndOfPath()){
        hasReachedPosition = true;
      }
    }
    if(hasReachedPosition){
      if(Waiting()){
        ++currentDestination_;
        hasReachedPosition = false;
      }
    }
  }

  bool Waiting(){
    currentTime_ += Time.deltaTime * timeMultiplier_;
    if(currentTime_ > maxTime_){
      currentTime_ = 0.0f;
      return true;
    }
    return false;
  }

}

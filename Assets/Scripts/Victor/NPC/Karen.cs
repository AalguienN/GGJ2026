using System.Collections.Generic;
using UnityEngine;

public class Karen : NPCBase {

  [SerializeField] private List<Transform> interestPoints_;

  private int currentBehaviour_;
  private int lastBehaviour_;

  [SerializeField] private float maxTime_;
  [SerializeField] private float timeMultiplier_;
  private float currentTime_;

  private int miniTask_;
  private bool hasReachedDestiantion_;
  private bool lockMiniTask_;

  public override void Start() {
    base.Start();
    currentBehaviour_ = 0;
    miniTask_ = 0;
    lastBehaviour_ = 0;
    currentTime_ = 0.0f;
    hasReachedDestiantion_ = false;
    lockMiniTask_ = false;
  }
 
  void Update() {
    transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
    if(!suspiciometer_.isDetected_)
      Behaviour();
    else
      CallThePolice();
  }


  public override void Behaviour() {
    if(currentBehaviour_ == 0)
      FilterBehaviour();

    //Cocina 1
    if(currentBehaviour_ == 1){
      DoTask(0, 1);
    }

    //Baño 2
    if(currentBehaviour_ == 2){
      DoTask(2, 3);
    }

    //Dormitorio 3
    if(currentBehaviour_ == 3){
      DoTask(4, 5);
    }

  }

  void FilterBehaviour(){
    lastBehaviour_ = currentBehaviour_;
    currentBehaviour_ = Random.Range(1, 4);
    if(currentBehaviour_ == lastBehaviour_){
      FilterBehaviour();
    }
  }

  bool DoingTimer(){
    currentTime_ += Time.deltaTime * timeMultiplier_;
    if(currentTime_ > maxTime_){
      currentTime_ = 0.0f;
      return true;
    }
    return false;
  }

  void DoTask(int ip1, int ip2){
    if(!lockMiniTask_){
      miniTask_ = Random.Range(1, 3);
      lockMiniTask_ = true;
    }

    if(miniTask_ == 1){
      if(!hasReachedDestiantion_){
        navAgent_.SetDestination(interestPoints_[ip1].position);
        if(AtEndOfPath()){
          hasReachedDestiantion_ = true;
        }
      }
      if(hasReachedDestiantion_){
        if(DoingTimer()){
          FilterBehaviour();
          hasReachedDestiantion_ = false;
          lockMiniTask_ = false;
        }
      }
    }
     if(miniTask_ == 2){
      if(!hasReachedDestiantion_){
        navAgent_.SetDestination(interestPoints_[ip2].position);
        if(AtEndOfPath()){
          hasReachedDestiantion_ = true;
        }
      }
      if(hasReachedDestiantion_){
        if(DoingTimer()){
          FilterBehaviour();
          hasReachedDestiantion_ = false;
          lockMiniTask_ = false;
        }
      }
    }
  }

}

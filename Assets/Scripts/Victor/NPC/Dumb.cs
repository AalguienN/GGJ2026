using System.Collections.Generic;
using UnityEngine;

public class Dumb : NPCBase  {

  public List<Vector3> pathList_;
  [SerializeField] private int listLength_;
  [SerializeField] private int radius_;
  private int currentPoint_;


  public override void Start() {
    currentPoint_ = 0;
    pathList_ = new List<Vector3>();

    for(int i = 0; i < listLength_; ++i){
      Vector3 circlePoints = new Vector3((Mathf.Cos((6.28f / listLength_) * i) * radius_) + transform.position.x,
                                        ((Mathf.Sin((6.28f / listLength_) * i) * radius_)) + transform.position.y,  
                                        0.0f);
      pathList_.Add(circlePoints);
    }

    base.Start();
  }

  void Update() {
    transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
    Behaviour();
    CallThePolice();
  }

  public override void Behaviour(){
    navAgent_.SetDestination(pathList_[currentPoint_ % listLength_]);
    if(AtEndOfPath()){
      currentPoint_++;
    }
  } 

}

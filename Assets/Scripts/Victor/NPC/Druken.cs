using UnityEngine;

public class Druken : NPCBase {

  [SerializeField] private float start_; 
  [SerializeField] private float finish_; 
  [SerializeField] private float offsetRadious_;
  private int direction_;
  private float offset_;

  public override void Start(){
    start_ = 13.0f;
    finish_ = -32.0f;
    direction_ = 1;
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

    offset_ = Mathf.Cos(Time.time) * offsetRadious_;
    transform.position = new Vector3(transform.position.x + offset_, transform.position.y, 0.0f);

    if(direction_ == 0){
      Vector3 endPosition = new Vector3(transform.position.x, start_, 0.0f);
      navAgent_.SetDestination(endPosition);
      if(AtEndOfPath()){
        direction_ = 1;
      }
    }

    if(direction_ == 1){
      Vector3 endPosition = new Vector3(transform.position.x, finish_, 0.0f);
      navAgent_.SetDestination(endPosition);
      if(AtEndOfPath()){
        direction_ = 0;
      }
    }

  }

}

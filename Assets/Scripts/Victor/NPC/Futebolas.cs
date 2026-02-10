using UnityEngine;

public class Futebolas : NPCBase {

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

  }


}

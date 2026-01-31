using UnityEngine;

public class Druken : NPCBase {

  public override void Start(){
    base.Start();
  }

  void Update(){
    transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
    CallThePolice();
  }

  public override void Behaviour(){

  }

}

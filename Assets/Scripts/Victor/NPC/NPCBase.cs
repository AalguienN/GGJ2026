using UnityEngine;
using UnityEngine.AI;

public abstract class NPCBase : MonoBehaviour {
  
  private NavMeshAgent navAgent_;
  private Suspiciometer suspiciometer_;


  void Start() {
    navAgent_ = GetComponent<NavMeshAgent>();
    suspiciometer_ = GetComponent<Suspiciometer>();
  }

  void Update() {
    transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
  }

  void CallThePolice(){

  }

  public abstract void Behaviour();

}

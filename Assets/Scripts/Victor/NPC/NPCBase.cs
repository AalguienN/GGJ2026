using UnityEngine;
using UnityEngine.AI;

public class NPCBase : MonoBehaviour {
  
  [SerializeField, Range(1.0f, 100.0f), HideInInspector] public float alertSpeed_; 

  [HideInInspector] public GameObject frontDoorPosition_;
  [HideInInspector] public NavMeshAgent navAgent_;
  [HideInInspector] public Suspiciometer suspiciometer_;


  public virtual void Start() {
    frontDoorPosition_ = GameObject.FindGameObjectWithTag("GuardaSpawn");
    if(!frontDoorPosition_)
      Debug.Log("No hay puerta");

    navAgent_ = GetComponent<NavMeshAgent>();
    suspiciometer_ = GetComponent<Suspiciometer>();
    if(!suspiciometer_)
      Debug.Log("No hay sospechoso");
  }

  public void CallThePolice(){
    if(suspiciometer_.isDetected_){
      Debug.Log("Police");
      navAgent_.speed = alertSpeed_;
      navAgent_.SetDestination(frontDoorPosition_.transform.position);
      if(navAgent_.isStopped){

      }
    }
  }

  public virtual void Behaviour() {}

}

using UnityEngine;
using UnityEngine.AI;

public class NPCBase : MonoBehaviour {
  
  [SerializeField, Range(1.0f, 100.0f), HideInInspector] public float alertSpeed_; 

  [HideInInspector] public GameObject frontDoorPosition_;
  [HideInInspector] public NavMeshAgent navAgent_;
  [HideInInspector] public Suspiciometer suspiciometer_;

  protected GameController gameController_;

  public virtual void Start() {
    frontDoorPosition_ = GameObject.FindGameObjectWithTag("GuardaSpawn");
    navAgent_ = GetComponent<NavMeshAgent>();
    suspiciometer_ = GetComponent<Suspiciometer>();
    gameController_ = FindFirstObjectByType<GameController>();
  }

  public void CallThePolice(){
    if(suspiciometer_.isDetected_){
      navAgent_.speed = alertSpeed_;
      navAgent_.SetDestination(frontDoorPosition_.transform.position);
      if(AtEndOfPath()){
        gameController_.SpawnGuard(true);
      }
    }
  }

  public virtual void Behaviour() {}


  public float pathEndThreshold = 0.1f;
  private bool hasPath = false;
  public bool AtEndOfPath() {
    hasPath |= navAgent_.hasPath;
    if (hasPath && navAgent_.remainingDistance <= navAgent_.stoppingDistance + pathEndThreshold ) {
        hasPath = false;
        return true;
    }
    return false;
  }

}

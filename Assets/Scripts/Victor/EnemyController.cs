using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

  [SerializeField] private Transform spawnPoint_;
  private PlayerMovement playerPrefab_;

  private NavMeshAgent navAgent_;
  public bool isLeaving_;

  void Start(){
    navAgent_ = GetComponent<NavMeshAgent>();

    isLeaving_ =  false;
    playerPrefab_ = FindFirstObjectByType<PlayerMovement>();
    if(null == playerPrefab_)
      Debug.Log("Player Not Found Biaaach");
  }

  void OnEnable() {
    isLeaving_ = false;
    transform.position = new Vector3(spawnPoint_.position.x, spawnPoint_.position.y, 0.0f);
  }

  void Update() {
    transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
    
    if(!isLeaving_){
      navAgent_.SetDestination(playerPrefab_.transform.position);
    }
    if(isLeaving_){
      navAgent_.SetDestination(spawnPoint_.position);
      if(AtEndOfPath()){
        gameObject.SetActive(false);
      }
    }
  }

  void OnTriggerEnter2D(Collider2D other){
    if(other.gameObject.GetComponent<PlayerMovement>()){
      Debug.Log("Abrazo");
    }
  }


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

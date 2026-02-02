using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour {

  [SerializeField] private Transform spawnPoint_;
  private PlayerMovement playerPrefab_;

  private NavMeshAgent navAgent_;
  public bool isLeaving_;
  public bool isIdle_;

  // public Animator animator_;

  void Start(){
    navAgent_ = GetComponent<NavMeshAgent>();
    // animator_ = GetComponent<Animator>();

    isLeaving_ =  true;
    isIdle_ = true;
    playerPrefab_ = FindFirstObjectByType<PlayerMovement>();
  }

  void OnEnable() {
    isLeaving_ = false;
    transform.position = new Vector3(spawnPoint_.position.x, spawnPoint_.position.y, 0.0f);
  }

  void Update() {
    transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
    
    if(!isLeaving_){
      Vector3 target = new Vector3(playerPrefab_.transform.position.x, playerPrefab_.transform.position.y, 0.0f);
      navAgent_.SetDestination(target);
    }
    if(isLeaving_){
      navAgent_.SetDestination(spawnPoint_.position);
      if(AtEndOfPath()){
        isIdle_ = true;
      }
    }
    // animator_.SetBool("IsIdle", isIdle_);
  }

  void OnTriggerEnter2D(Collider2D other){
    if(other.gameObject.GetComponent<PlayerMovement>()){
      GameController.Instance.gameOverCanvas_.SetActive(true);
      Time.timeScale = 0.0f;
      GameController.Instance.barras.SetActive(false);
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

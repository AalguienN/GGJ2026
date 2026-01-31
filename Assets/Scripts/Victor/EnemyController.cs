using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

  [SerializeField] private Transform spawnPoint_;
  private PlayerMovement playerPrefab_;

  private NavMeshAgent navAgent_;

  void Start(){
    navAgent_ = GetComponent<NavMeshAgent>();

    playerPrefab_ = FindFirstObjectByType<PlayerMovement>();
    if(null == playerPrefab_)
      Debug.Log("Player Not Found Biaaach");
  }

  void OnEnable() {
    transform.position = new Vector3(spawnPoint_.position.x, spawnPoint_.position.y, 0.0f);
  }

  void Update() {
    transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
    navAgent_.SetDestination(playerPrefab_.transform.position);
  }
}

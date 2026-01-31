using UnityEngine;

public class Suspiciometer : MonoBehaviour {

  [SerializeField, Range(0.0f, 100.0f)] private float detectionDistance_;
  private PlayerMovement playerPrefab_;

  [SerializeField] private GameController gameController_;
  private float distanceIncresing_;
  private float currentDistance_;

  public bool isDetected_;

  void Start() {
    distanceIncresing_ = 0.0f;
    isDetected_ = false;

    playerPrefab_ = FindFirstObjectByType<PlayerMovement>();
    if(null == playerPrefab_)
      Debug.Log("Player Not Found Biaaach");
  }

  void Update(){
    distanceIncresing_ = gameController_.accumulatedTime_ / 54.0f; 

  }

  void FixedUpdate() {
    float actualDistance = Vector3.Distance(transform.position, playerPrefab_.transform.position);
    currentDistance_ = detectionDistance_ + distanceIncresing_;
    if(actualDistance <= currentDistance_){
      Vector2 alpha = new Vector2(transform.position.x - playerPrefab_.transform.position.x, 
                                  transform.position.y - playerPrefab_.transform.position.y);

      float magnitude = alpha.magnitude;

      if(magnitude <= currentDistance_ * 0.5f + distanceIncresing_ * 0.5f){
        isDetected_ = true;
      }


      // RaycastHit2D hit = Physics2D.Raycast(transform.position, playerPrefab_.transform.position, detectionDistance_);
      // if(hit.transform.GetComponent<PlayerMovement>()){
      //   Debug.DrawRay(transform.position, hit.transform.position, Color.yellow);
      // }
    }
  }

  void OnDrawGizmos() {
    Gizmos.color = Color.orange;
    Gizmos.DrawWireSphere(transform.position, currentDistance_);
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(transform.position, currentDistance_ * 0.5f + distanceIncresing_ * 0.5f);
  }

}

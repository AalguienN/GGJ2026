using UnityEngine;

public class Suspiciometer : MonoBehaviour {

  [SerializeField, Range(0.0f, 10.0f)] private float detectionDistance_;
  private PlayerMovement playerPrefab_;

  void Start() {
    playerPrefab_ = FindFirstObjectByType<PlayerMovement>();
    if(null == playerPrefab_)
      Debug.Log("Player Not Found Biaaach");
  }

  void FixedUpdate() {
    float actualDistance = Vector3.Distance(transform.position, playerPrefab_.transform.position);
    if(actualDistance <= detectionDistance_){
      RaycastHit2D hit = Physics2D.Raycast(transform.position, playerPrefab_.transform.position, detectionDistance_);
      if(hit){
        if(hit.transform.GetComponent<PlayerMovement>()){
          Debug.DrawRay(transform.position, playerPrefab_.transform.position, Color.yellow);
        }
      }
    }
  }

  void OnDrawGizmos() {
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(transform.position, detectionDistance_);
  }

}

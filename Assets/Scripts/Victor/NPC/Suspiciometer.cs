using UnityEngine;

public class Suspiciometer : MonoBehaviour {

  [SerializeField, Range(0.0f, 100.0f)] private float detectionDistance_;
  private PlayerMovement playerPrefab_;

  private float distanceIncresing_;
  private float currentDistance_;

  public bool isDetected_;

  public SpriteRenderer spriteRenderer_;
  public Sprite[] sprites_;

  void Start() {
    distanceIncresing_ = 0.0f;
    isDetected_ = false;

    playerPrefab_ = FindFirstObjectByType<PlayerMovement>();
  }

  void Update(){
    distanceIncresing_ = GameController.Instance.accumulatedTime_ / 54.0f; 
  }

  void FixedUpdate() {
    if(!isDetected_){
      float actualDistance = Vector3.Distance(transform.position, playerPrefab_.transform.position);
      currentDistance_ = detectionDistance_ + distanceIncresing_;
      if(actualDistance <= currentDistance_){
        spriteRenderer_.sprite = sprites_[0];

        Vector2 alpha = new Vector2(transform.position.x - playerPrefab_.transform.position.x, 
                                    transform.position.y - playerPrefab_.transform.position.y);

        float magnitude = alpha.magnitude;


        if(magnitude <= currentDistance_ * 0.3f + distanceIncresing_){
          isDetected_ = true;
        }

      }
      else {
        spriteRenderer_.sprite = sprites_[2];
      }
    }
   
    if(isDetected_) {
      spriteRenderer_.sprite = sprites_[1];
    }

  }

  void OnDrawGizmos() {
    Gizmos.color = Color.orange;
    Gizmos.DrawWireSphere(transform.position, currentDistance_);
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(transform.position, currentDistance_ * 0.5f + distanceIncresing_ * 0.5f);
  }

}

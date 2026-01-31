using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

  [SerializeField] private RectTransform fillHealthBarTransform_;
  [SerializeField] private float timerMultiplier = 2.0f;  
  private float width;
  private float originalWidth;

  [SerializeField] private EnemyController enemyController_;
  [SerializeField] private RectTransform enemyTimeRemaining_;
  [SerializeField] private float enemyTimeMultiplier_ = 12.0f;
  [SerializeField] private GameObject enemyTimer_;

  public float accumulatedTime_;


  void Start() {
    accumulatedTime_ = 0.0f;
    originalWidth = fillHealthBarTransform_.sizeDelta.x;
    width = originalWidth;
  }

  void Update() {
    MaskTimer();
    // EnemyTimer();

  }

  void MaskTimer(){
    if(!enemyController_.gameObject.activeInHierarchy){
      fillHealthBarTransform_.sizeDelta = new Vector2(width - (accumulatedTime_ += Time.deltaTime * timerMultiplier), 20.0f);
      if(fillHealthBarTransform_.sizeDelta.x <= 0.0f){
        enemyController_.gameObject.SetActive(true);
      }
    }
  }

  void EnemyTimer(){
    if(enemyController_.gameObject.activeInHierarchy){
      enemyTimer_.SetActive(true);
      enemyTimeRemaining_.sizeDelta = new Vector2(width -= Time.deltaTime * enemyTimeMultiplier_, 20.0f);
      if(enemyTimeRemaining_.sizeDelta.x <= 0.0f){
        enemyController_.gameObject.SetActive(false);
        enemyTimeRemaining_.sizeDelta = new Vector2(originalWidth, 0.0f);
      }
    }
  }

}

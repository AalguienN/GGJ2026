using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

  [SerializeField] private RectTransform fillHealthBarTransform_;
  [SerializeField] private float timerMultiplier = 2.0f;  
  [SerializeField] private EnemyController enemyController_;


  public enum Zone { Outside, Inside };
  public Zone CurrentPlayerZone = Zone.Outside;

  private float width = 540.0f;

  void Start() {

  }

  void Update() {
    MaskTimer();
  }


  void MaskTimer(){
    if(!enemyController_.gameObject.activeInHierarchy)
      fillHealthBarTransform_.sizeDelta = new Vector2(width -= Time.deltaTime * timerMultiplier, 20.0f);

    if(fillHealthBarTransform_.sizeDelta.x <= 0.0f )
      enemyController_.gameObject.SetActive(true);

  }

}

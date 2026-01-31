using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

  [SerializeField] private RectTransform fillHealthBarTransform_;
  [SerializeField] private float timerMultiplier = 2.0f;  
  private float width = 540.0f;

  void Start() {

  }

  void Update() {
  }


  void MaskTimer(){
    fillHealthBarTransform_.sizeDelta = new Vector2(width -= Time.deltaTime * timerMultiplier, 20.0f);
  }

}

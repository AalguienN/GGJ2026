using UnityEngine;

public class PlayerMovement : MonoBehaviour {

  [SerializeField, Range(1.0f, 20000.0f)] private float playerSpeed_;
  private Rigidbody2D playerRB_;

  void Start(){

    playerRB_ = GetComponent<Rigidbody2D>();
      
  }

  void FixedUpdate(){
    Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    playerRB_.linearVelocity = input * playerSpeed_ * Time.fixedDeltaTime;
  }

  void OnTriggerEnter2D(Collider2D other){
    if(other.tag == "Collectable")
      Debug.Log("Objetarro");
  }

}

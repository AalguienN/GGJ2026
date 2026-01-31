using UnityEngine;

public class PlayerMovement : MonoBehaviour {

  [SerializeField, Range(1.0f, 20.0f)] private float playerSpeed_;

  void Start(){
      
  }

  void Update(){
    Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical")).normalized;
    transform.position += input * playerSpeed_ * Time.deltaTime;
  }

  void OnTriggerEnter2D(Collider2D other){
    if(other.tag == "Collectable")
      Debug.Log("Objetarro");
  }

}

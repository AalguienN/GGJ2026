using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

  [SerializeField, Range(1.0f, 20000.0f)] private float playerSpeed_;
  private Rigidbody2D playerRB_;
    private Animator animator;

  void Start(){

    playerRB_ = GetComponent<Rigidbody2D>();

        animator = GetComponentInChildren<Animator>();
  }

  void FixedUpdate(){
    Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    playerRB_.linearVelocity = input * playerSpeed_ * Time.fixedDeltaTime;

    Vector2 velocity = playerRB_.linearVelocity;
    float speed = 2*velocity.x + velocity.y;
    animator.SetFloat("speed", speed);
  }

  void OnTriggerEnter2D(Collider2D other){
<<<<<<< HEAD
    if(other.tag == "Collectable"){
      
    }

  }
=======
        Draggable d = other.gameObject.GetComponent<Draggable>();
        if (d != null)
        {
            d.Selectable = true;
        }
    }
>>>>>>> e6da6a81c2974f4bdbe2fb13bd65d2f6964acace

    private void OnTriggerExit2D(Collider2D collision)
    {
        Draggable d = collision.gameObject.GetComponent<Draggable>();
        if (d != null && !d.YEYIAMDRAGGEDTHISFRAME)
        {
            d.Selectable = false;
        }
        else if (d != null && d.YEYIAMDRAGGEDTHISFRAME)
        {
            
        }
    }
}

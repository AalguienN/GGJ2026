using UnityEngine;

public class AnimationLR : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    Vector3 lastPos;
    float speed = 0;
    //[SerializeField]
    //Rigidbody2D rb2d;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        lastPos = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (animator == null) return;
        Vector3 ps = transform.position;
        speed = (lastPos - ps).magnitude * -Mathf.Sign((lastPos - ps).x); 
        //* 10 + speed * 0.5f;
        animator.SetFloat("Speed", speed);
        lastPos = ps;
    }
}

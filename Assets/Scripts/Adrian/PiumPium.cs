using System;
using UnityEngine;

public class PiumPium : MonoBehaviour
{
    public Vector3 pos1;
    public Vector3 pos2;

    public Transform t1;
    public Transform t2;

    [SerializeField] Animator anim;

    public bool shoot = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public void ShootAnim()
    {
        Debug.Log("PIUM PIUM PIUM");
        anim.SetTrigger("Pium");
    }


    // Update is called once per frame
    void Update()
    {
        if (shoot)
        {
            ShootAnim();
            shoot = false;
        }
        if (t1 != null) pos1 = t1.position;
        if (t2 != null) pos2 = t2.position;

        transform.position = pos1;

        Vector3 dir = pos2 - pos1;

        transform.localScale = new Vector3(
            dir.magnitude,
            4,
            4
        );

        // Rotar para que el eje X mire hacia t2
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

}

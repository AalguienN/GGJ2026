using UnityEngine;
using UnityEngine.InputSystem;

public class Dragger : MonoBehaviour
{
    public Collider coll;

    void Start()
    {
        coll = GetComponent<Collider>();
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;

            if (coll.Raycast(ray, out hit, 100.0f))
            {
                transform.position = ray.GetPoint(100.0f);
            }
        }
    }
}


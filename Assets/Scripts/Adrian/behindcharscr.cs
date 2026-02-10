using Unity.VisualScripting;
using UnityEngine;

public class behindcharscr : MonoBehaviour
{
    Transform player;
    SpriteRenderer sr;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindAnyObjectByType<PlayerMovement>().transform;
        sr = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (player.position.y < sr.transform.position.y && sr != null)
            {
                sr.sortingOrder = 1;
            }
            else sr.sortingOrder = 20;
        }
    }
}

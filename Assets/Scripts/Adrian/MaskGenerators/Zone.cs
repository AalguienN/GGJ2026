using UnityEngine;

public class Zone : MonoBehaviour
{
    //TODO AÑADIR MAS ZONAS
    public enum ZType { Outside, Inside };

    public ZType Type = ZType.Outside;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<GameController>())
        {
            GameController.CurrentPlayerZone = Type;
        }
    }
}

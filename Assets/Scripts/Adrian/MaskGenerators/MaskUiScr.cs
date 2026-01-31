using System;
using UnityEngine;

public class MaskUiScr : MonoBehaviour
{
    Plane dragPlane;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Camera myMainCamera;

    void Start()
    {
        myMainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.TryGetComponent<Draggable>(out Draggable dragable);
        if (dragable != null && InteractUiScaler.Instance?.Interacting == InteractUiScaler.Interaction.Dragging)
        {
            Debug.Log($"{dragable.gameObject.name}");
            dragable.gameObject.transform.parent = this.transform.parent;
        }
    }    
    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.TryGetComponent<Draggable>(out Draggable dragable);
        if (dragable != null)
        {
            dragable.gameObject.transform.parent = null;
            dragable.gameObject.transform.localScale = Vector3.one;
        }

    }
}

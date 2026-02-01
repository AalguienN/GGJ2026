using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour
{
    // The plane the object is currently being dragged on
    private Plane dragPlane;

    // The difference between where the mouse is on the drag plane and 
    // where the origin of the object is on the drag plane
    private Vector3 offset;

    private Camera myMainCamera;

    public bool YEYIAMDRAGGEDTHISFRAME;

    void Start()
    {
        myMainCamera = Camera.main; // Camera.main is expensive ; cache it here
        YEYIAMDRAGGEDTHISFRAME = false;
    }

    void OnMouseDown()
    {
        dragPlane = new Plane(myMainCamera.transform.forward, transform.position);
        Ray camRay = myMainCamera.ScreenPointToRay(Input.mousePosition);
        YEYIAMDRAGGEDTHISFRAME = true;

        float planeDist;
        LayerMask layerMask = LayerMask.GetMask(new string[] { "Draggable" });
        dragPlane.Raycast(camRay, out planeDist);

        Debug.Log($"{planeDist} {this.name}");
        offset = transform.position - camRay.GetPoint(planeDist);
        InteractUiScaler.Instance.Interacting = InteractUiScaler.Interaction.Dragging;
    }

    void OnMouseDrag()
    {
        dragPlane = new Plane(myMainCamera.transform.forward, transform.position);

        Ray camRay = myMainCamera.ScreenPointToRay(Input.mousePosition);
        if (dragPlane.Raycast(camRay, out float planeDist))
        {
            YEYIAMDRAGGEDTHISFRAME = true;
            transform.position = camRay.GetPoint(planeDist) + offset;
        }
    }

    private void OnMouseUp()
    {
        YEYIAMDRAGGEDTHISFRAME = false;
        InteractUiScaler.Instance.Interacting = InteractUiScaler.Interaction.NoInteraction;
    }
}

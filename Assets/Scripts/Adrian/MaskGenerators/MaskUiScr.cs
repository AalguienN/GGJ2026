using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class MaskUiScr : MonoBehaviour
{
    public static MaskUiScr Instance;
    Plane dragPlane;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Camera myMainCamera;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
    }

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
        if (dragable != null && InteractUiScaler.Instance?.Interacting == InteractUiScaler.Interaction.Dragging && dragable.YEYIAMDRAGGEDTHISFRAME)
        {
            Debug.Log($"{dragable.gameObject.name}");

            dragable.gameObject.transform.parent = this.transform.parent;
            RefreshCollectables();
        }
    }    
    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.TryGetComponent<Draggable>(out Draggable dragable);
        if (dragable != null)
        {
            dragable.gameObject.transform.parent = null;
            dragable.gameObject.transform.localScale = 2*Vector3.one;
            RefreshCollectables();
        }
    }

    private void RefreshCollectables()
    {
        HashSet<Collectable.Type> typesHash = new();
        List<Collectable> types = transform.parent.gameObject.GetComponentsInChildren<Collectable>().ToList();
        Debug.Log(types.Count);
        foreach (var t in types)
            typesHash.Add(t.type);

        GameController.Instance.HoldedTypes = typesHash.ToList();
    }
}

using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class InGameMaskGenerator : MonoBehaviour
{
    public static InGameMaskGenerator Instance;
    public MaskUiScr maskUI;
    public Transform maskT;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    void Start()
    {        
        if (maskUI == null) maskUI = GameObject.FindAnyObjectByType<MaskUiScr>();
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: BORRAR ESTO PLS
        if (Input.GetKeyDown(KeyCode.G))
        {
            Generate();
        }
    }
    public void Remove()
    {
        var listOldDragables = transform.GetComponentsInChildren<Draggable>();
        Debug.Log(listOldDragables.Count());
        foreach (Draggable d in listOldDragables)
        {
            Destroy(d.gameObject);
        }
    }

    public void Generate()
    {
        var listOldDragables = transform.GetComponentsInChildren<Draggable>();
        foreach (Draggable d in listOldDragables)
        {
            Destroy(d.gameObject);
        }
        var listDragables = maskUI.transform.parent.GetComponentsInChildren<Draggable>();
        foreach (Draggable d in listDragables)
        {
            GameObject clone = Instantiate(d.gameObject);
            clone.GetComponent<Draggable>().enabled = false;
            clone.transform.parent = maskT;
            clone.transform.localPosition = d.transform.localPosition;
            clone.transform.localScale = d.transform.localScale;
            clone.transform.localRotation = d.transform.localRotation;
        }
        //GameController.Instance.TryNextObjective();
    }
}

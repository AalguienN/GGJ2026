using System;
using System.Linq;
using UnityEngine;

public class Abductable : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    ObjetivoSO self;

    void Start()
    {
        if (GetComponent<Karen>()) { 
           self = Resources.Load<ObjetivoSO>("ScriptableObjects/ObjetivoKaren");
        }
        else if (GetComponent<Dumb>())
        {
            self = Resources.Load<ObjetivoSO>("ScriptableObjects/ObjetivoTonTorres"); 
        }
        else if (GetComponent<Druken>())
        {
            self = Resources.Load<ObjetivoSO>("ScriptableObjects/ObjetivoKevin"); 
        }
        //TODO
        //else if (GetComponent<M>)
        //{

        //Resources.Load<ObjetivoSO>("ScriptableObjects/ObjetivoMustang");
        //}
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnMouseDown()
    {
        Debug.Log("CLICK DETECTADO!");
        Debug.Log($"{GameController.Instance.ObjetivoActual.GetType()} || {self.GetType()}");
        InGameMaskGenerator.Instance.Generate();
        if (self.Name == GameController.Instance.ObjetivoActual.Name)
        {
            if (GameController.Instance.IsCorrectMaskCorrect())
            {
                GameController.Instance.TryNextObjective();
                gameObject.SetActive(false);
            }
            var listDragables =  InGameMaskGenerator.Instance.transform.parent.GetComponentsInChildren<Draggable>();
            Debug.Log("---------------");
            Debug.Log(listDragables.Count());
            foreach (var d in listDragables)
            {
                Debug.Log(d);
                Destroy(d);
            }
        }
        else
        {
            InGameMaskGenerator.Instance.Remove();
        }
    }

    void OnMouseDrag()
    {
        
    }

}

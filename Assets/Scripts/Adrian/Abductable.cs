using System;
using System.Collections;
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
    private Coroutine corr;

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
                PlayerMovement.Instance.Abduscan();
                //gameObject.SetActive(false);
                corr = StartCoroutine(DeleteIE(1f));
            }
            var listDragables =  MaskUiScr.Instance.transform.parent.GetComponentsInChildren<Draggable>();
            foreach (var d in listDragables)
            {
                Destroy(d.gameObject);
            }
        }
        else
        {
            InGameMaskGenerator.Instance.Remove();
        }
    }
    IEnumerator aaaaaaaaaa;
    IEnumerator DeleteIE(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        gameObject.SetActive(false);
    }
    void OnMouseDrag()
    {
        
    }

}

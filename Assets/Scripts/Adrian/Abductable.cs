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
        if (GameController.Instance)
        {
            GameController.Instance.TryNextObjective();
        }
    } 
    
    void OnMouseDown()
    {

    }

    void OnMouseDrag()
    {
        
    }

}

using System;
using System.Collections;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class Abductable : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public ObjetivoSO self;
    public PiumPium piumpium;
    public PlayerMovement player;

    void Start()
    {
        if (GetComponent<Karen>())
        {
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
        else if (GetComponent<Mustang>())
        {
            self = Resources.Load<ObjetivoSO>("ScriptableObjects/ObjetivoMustang");
        }
        player = GameObject.FindAnyObjectByType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private Coroutine corr;

    private bool clickCD = false;

    void OnMouseDown()
    {
        if (clickCD) return;
        CLickWait();

        Debug.Log(self.Name);
        Debug.Log(GameController.Instance.ObjetivoActual.Name);
        Debug.Log("------------------------------------");
        if (self.Name == GameController.Instance.ObjetivoActual.Name)
        {
            Debug.Log("=======================");
            if (GameController.Instance.IsCorrectMaskCorrect())
            {
                player.PlaySound();
                piumpium.t2 = this.transform; 
                Debug.Log("((((((((((((((((");
                PlayerMovement.Instance.Abduscan();
                //gameObject.SetActive(false);
                //corr = StartCoroutine(DeleteIE(1f));
                corr = StartCoroutine(WAIT());
            }
        }
        else
        {
            Debug.Log("Va a ser que no");
            InGameMaskGenerator.Instance.Remove();
        }
    }

    //IEnumerator aaaaaaaaaa;
    //IEnumerator DeleteIE(float waitTime)
    //{
    //    yield return new WaitForSeconds(waitTime);
    //    gameObject.SetActive(false);
    //}

    IEnumerator WAIT()
    {
        yield return new WaitForSeconds(2f);
        InGameMaskGenerator.Instance.Generate();
        GameController.Instance.TryNextObjective();
        gameObject.SetActive(false);
        var listDragables = MaskUiScr.Instance.transform.parent.GetComponentsInChildren<Draggable>();
        foreach (var d in listDragables)
        {
            Destroy(d.gameObject);
        }
    }

    IEnumerator CLickWait()
    {
        clickCD = true;
        yield return new WaitForSeconds(2f);
        clickCD = false;
    }
    void OnMouseDrag()
    {

    }

}

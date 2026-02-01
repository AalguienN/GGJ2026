using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public List<string> Dialogos;
    public List<string> Dialogs;
    private int CurrentDialog = 0;
    string currentEs = "";
    string currentEn = "";
    public TMP_Text textEs;
    public TMP_Text textEn;

    void Start()
    {
        SetDialog(0);
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.anyKeyDown)
        {
            NextDialog();
        }
    }


    public void SetDialog(int num)
    {
        if (num < Dialogos.Count)
            currentEs = Dialogos[num];
        //textEs.text = Dialogos[num];
        if (num < Dialogs.Count)
            currentEs = Dialogs[num];
        //textEn.text = Dialogs[num];

        CurrentDialog = num;
    }

    private IEnumerator TypeWriterCorroutine;

    IEnumerator TypeWritterEspanol(float waitTime)
    {
        float timePerletter = waitTime / currentEs.Length;
        string curr_text = "";
        for (int i = 0; i < currentEs.Length; i++)
        {
            yield return new WaitForSeconds(timePerletter);

            
        }
        print("WaitAndPrint " + Time.time);
    }


    public void NextDialog()
    {
        if (CurrentDialog + 1 < Dialogos.Count)
            SetDialog(CurrentDialog + 1);
        else
            Debug.Log("NEXT");
    }
}

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

    private bool isTyping = false;
    private Coroutine esCoroutine;
    private Coroutine enCoroutine;

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
        StopAllCoroutines();

        if (num < Dialogos.Count)
            currentEs = Dialogos[num];
        if (num < Dialogs.Count)
            currentEn = Dialogs[num];

        textEs.text = "";
        textEn.text = "";

        isTyping = true;

        esCoroutine = StartCoroutine(TypeWritterEspanol(1f));
        enCoroutine = StartCoroutine(TypeWritterEnglish(1f));

        CurrentDialog = num;
    }


    private IEnumerator TypeWriterCorroutine;

    IEnumerator TypeWritterEspanol(float waitTime)
    {
        float timePerLetter = waitTime / currentEs.Length;
        string curr = "";

        for (int i = 0; i < currentEs.Length; i++)
        {
            yield return new WaitForSecondsRealtime(timePerLetter);
            curr += currentEs[i];
            textEs.text = curr;
        }
    }

    IEnumerator TypeWritterEnglish(float waitTime)
    {
        float timePerLetter = waitTime / currentEn.Length;
        string curr = "";

        for (int i = 0; i < currentEn.Length; i++)
        {
            yield return new WaitForSecondsRealtime(timePerLetter);
            curr += currentEn[i];
            textEn.text = curr;
        }

        // Cuando ambas acaban
        isTyping = false;
    }


    public void NextDialog()
    {
        if (isTyping)
        {
            // Cancelar escritura y mostrar todo
            StopAllCoroutines();
            textEs.text = currentEs;
            textEn.text = currentEn;
            isTyping = false;
            return;
        }

        if (CurrentDialog + 1 < Dialogos.Count)
            SetDialog(CurrentDialog + 1);
        else
        {
            Time.timeScale = 1.0f;
            Debug.Log("NEXT");
            gameObject.SetActive(false);
        }
    }

    void OnEnable(){
        GameController.Instance.globalAudio.clip = GameController.Instance.audioList[1];
        GameController.Instance.globalAudio.Play();
    }

    void OnDisable(){
        GameController.Instance.globalAudio.clip = GameController.Instance.audioList[2];
        GameController.Instance.globalAudio.Play();
    }

}

using UnityEngine;

public class Menu : MonoBehaviour {

    public GameObject Tutorial;
    public GameObject startButton;
    public GameObject continueButton;

    void Start() {
      Time.timeScale = 0.0f;
      GameObject.Find("Tutorial");
        if (Tutorial != null)
        Tutorial.SetActive(false);
    }

    public void StartButton(){
      //Time.timeScale = .1f;
        Tutorial.SetActive(true);
      gameObject.SetActive(false);
      startButton.SetActive(false);
      continueButton.SetActive(true);
    }

    public void ContinueButton(){
      gameObject.SetActive(false);
    }

    public void QuitButton(){
      Application.Quit();
    }

}

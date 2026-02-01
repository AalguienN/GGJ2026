using UnityEngine;

public class Menu : MonoBehaviour {

    void Start() {
      Time.timeScale = 0.0f;
    }

    public void StartButton(){
      Time.timeScale = 1.0f;
      gameObject.SetActive(false);
    }

    public void QuitButton(){
      Application.Quit();
    }
}

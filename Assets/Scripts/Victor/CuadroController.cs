using UnityEngine;

public class CuadroController : MonoBehaviour {

  private Transform haloChildTr;
  private Transform imageChildTr;
  public bool isActive;

  void Start(){
    haloChildTr = transform.GetChild(0);
    imageChildTr = transform.GetChild(1);
    isActive = imageChildTr.gameObject.activeInHierarchy;
  }

  void OnTriggerEnter2D(Collider2D other){
    if(other.tag == "Player")
      haloChildTr.gameObject.SetActive(true);
  }

  void OnTriggerExit2D(Collider2D other){
    if(other.tag == "Player")
      haloChildTr.gameObject.SetActive(false);
  }

  void OnMouseOver(){
    haloChildTr.gameObject.SetActive(true);
  }

  void OnMouseExit(){
    haloChildTr.gameObject.SetActive(false);
  }

  void OnMouseDown(){
    imageChildTr.gameObject.SetActive(isActive = !isActive);
  }

  void OnEnable(){
    Time.timeScale = 0.0f;
  }

  void OnDisable(){
    Time.timeScale = 1.0f;
  }

}

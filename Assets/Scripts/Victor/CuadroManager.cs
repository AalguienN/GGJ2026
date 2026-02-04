using UnityEngine;

public class CuadroManager : MonoBehaviour {

  private GameObject cuadroParent;
  private CuadroController cc;

  void Start(){
    cc = transform.parent.transform.parent.GetComponent<CuadroController>();
    cuadroParent = transform.parent.gameObject;
  }

  void OnMouseDown(){
    cuadroParent.SetActive(cc.isActive = !cc.isActive);
  }


}

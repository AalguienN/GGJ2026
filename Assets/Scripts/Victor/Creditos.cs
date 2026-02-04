using System.Collections.Generic;
using UnityEngine;


public class Creditos : MonoBehaviour {

  public List<Collider2D> cuadros;
  public int isOneActive;

  void Start() {
    cuadros = new List<Collider2D>();
    for(int i = 0; i < transform.childCount; ++i){
      cuadros.Add(transform.GetChild(i).GetComponent<Collider2D>());
    }
  }


}

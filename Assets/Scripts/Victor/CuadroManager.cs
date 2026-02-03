using System.Collections.Generic;
using UnityEngine;

public class CuadroManager : MonoBehaviour {

  [SerializeField] private List<GameObject> childs;
  private int lastChild;
  private int activeCount;

  void Start() {
    childs = new List<GameObject>();
    for(int i = 0; i < transform.childCount; ++i){
      childs.Add(transform.GetChild(i).gameObject.transform.GetChild(1).gameObject);
    }
  }


}

using System.Collections.Generic;
using UnityEngine;


public class Coletas : NPCBase {

  [SerializeField] private GameObject[] itemList_;
  [SerializeField] private List<Transform> rooms_;

  public bool isItemSelected_;
  public bool isItemPicked_;
  public int itemID_;
  public int lastItem_;
  public GameObject itemToPick_;
  public int task_;

  public int roomIndex_; 
  public bool isRoomSelected_;
  public bool hasReachedDestination_;


  [SerializeField] public float waitTime_;
  [SerializeField] public float timeMultiplier_;
  public float currentTime_;
  public int lastRoom_;

  public override void Start() {
    itemList_ = GameObject.FindGameObjectsWithTag("Collectable");
    isItemSelected_ = false;
    isItemPicked_ = false;
    itemID_ = 0;
    task_ = 2;
    isRoomSelected_ = false;
    hasReachedDestination_ = false;

    base.Start();
  }

  void Update() {
    transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
    if(!suspiciometer_.isDetected_)
      Behaviour();
    else
      CallThePolice();
  }

  public override void Behaviour(){

    if(task_ == 0){
      task_ = Random.Range(1, 3);
      Debug.Log("Paras Aqui Puta");
    }

    if(task_ == 1)
      RoamRandomly();

    if(task_ == 2)
      ChangeItem();

  } 

  void FilterRoom(){
    lastRoom_ = roomIndex_;
    roomIndex_ = Random.Range(0, 7);
    if(roomIndex_ == lastRoom_){
      FilterRoom();
    }
  }

  void FilterItem(){
    lastItem_ = itemID_;
    itemID_ = Random.Range(0, 8);
    if(itemID_ == lastItem_){
      FilterItem();
    }
  }

  void RoamRandomly(){
    if(!isRoomSelected_){
      FilterRoom();
      isRoomSelected_ = true; 
    }
    if(!hasReachedDestination_){
      if(isRoomSelected_){
        navAgent_.SetDestination(rooms_[roomIndex_].position);
        if(AtEndOfPath()){
          hasReachedDestination_ = true;
        }
      }
    }

    if(hasReachedDestination_){
      if(Waiting()){
        isRoomSelected_ = false;
        hasReachedDestination_ = false;
        if(isItemPicked_){
          task_ = 2;
          itemToPick_.transform.position = rooms_[roomIndex_].position;
          isItemPicked_ = false;
        }
      }
    }

  }

  void ChangeItem(){
    if(!isItemPicked_){
      if(!isItemSelected_){
        FilterItem();
        itemToPick_ = itemList_[itemID_];
        isItemSelected_ = true;
      }
      if(isItemSelected_){
        navAgent_.SetDestination(itemToPick_.transform.position);
        if(AtEndOfPath()){
          isItemPicked_ = true;
        }
      }
    }

    if(isItemPicked_){
      itemToPick_.transform.position = new Vector3(transform.position.x, transform.position.y, 0.0f);
      if(Waiting()){
        task_ = 1;
        Debug.Log("ItemEnMano");
      }
    }

  }

  bool Waiting(){
    currentTime_ += Time.deltaTime * timeMultiplier_;
    if(currentTime_ > waitTime_){
      currentTime_ = 0.0f;
      return true;
    }
    return false;
  }

}

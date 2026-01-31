using UnityEngine;

public class CameraController : MonoBehaviour {

  private PlayerMovement playerPrefab_;
  private float cameraHeight_ = -7.0f;

  void Start(){

    playerPrefab_ = FindFirstObjectByType<PlayerMovement>();
    if(null == playerPrefab_)
      Debug.Log("Player Not Found Biaaach");

  }

  void Update(){
    Camera.main.transform.position = new Vector3(playerPrefab_.transform.position.x, playerPrefab_.transform.position.y, cameraHeight_);
  }

}

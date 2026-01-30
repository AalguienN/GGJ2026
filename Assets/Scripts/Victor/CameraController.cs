using UnityEngine;

public class CameraController : MonoBehaviour {

  private PlayerMovement playerPrefab_;
  [SerializeField] private float cameraHeight_ = 7.0f;

  void Start(){
    Camera.main.transform.localEulerAngles = new Vector3(90.0f, 0.0f, 0.0f);

    playerPrefab_ = FindFirstObjectByType<PlayerMovement>();
    if(null == playerPrefab_)
      Debug.Log("Player Not Found Biaaach");

  }

  void Update(){
    Camera.main.transform.position = new Vector3(playerPrefab_.transform.position.x, cameraHeight_, playerPrefab_.transform.position.z);
  }

}

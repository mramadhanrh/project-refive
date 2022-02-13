using UnityEngine;

public class CameraController : MonoBehaviour
{
  public GameObject player;
  Vector3 _cameraPos;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
  }
}

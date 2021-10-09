using UnityEngine;

public class CameraFollow : MonoBehaviour
{
  private GameObject _player;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    this.FollowPlayer();
  }

  void FollowPlayer()
  {
    if (_player != null)
    {
      transform.position = Vector3.Lerp(transform.position, _player.transform.position, 0.1f) + new Vector3(0, 0, -10); ;
    }
  }

  public void SetPlayer(GameObject player)
  {
    _player = player;
  }
}

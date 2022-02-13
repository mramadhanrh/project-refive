using UnityEngine;

public class CameraFollow : MonoBehaviour
{
  private GameObject _player;

  private Vector3 _velocity = Vector3.zero;
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
      Vector3 playerPos = new Vector3(_player.transform.position.x, _player.transform.position.y, transform.position.z);
      transform.position = Vector3.SmoothDamp(transform.position, playerPos, ref _velocity, 0.3f);
    }
  }

  public void SetPlayer(GameObject player)
  {
    _player = player;
  }
}

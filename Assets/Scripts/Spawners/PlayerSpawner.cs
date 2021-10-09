using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
  public GameObject player;

  public GameObject SpawnPlayer()
  {
    GameObject _player = Instantiate(player);
    return _player;
  }
}

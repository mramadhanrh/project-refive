using UnityEngine;

public class PictureGridManager : MonoBehaviour
{
  public GameObject Frame;
  public Vector2Int GridSize;
  public PlayerSpawner PlayerSpawner;

  public CameraFollow _camera;
  private PictureGridItem[,] _pictureGroup;

  // Start is called before the first frame update
  void Start()
  {
    this.SpawnFrameGrid();
    this.SpawnPlayer();
  }

  void SetPictureGroupItem(int row, int column, GameObject go)
  {
    _pictureGroup[row, column] = new PictureGridItem(row, column, go, GridSize);
  }

  void SpawnFrameGrid()
  {
    _pictureGroup = new PictureGridItem[GridSize.x, GridSize.y];

    for (int i = 0; i < GridSize.x; i += 1)
    {
      for (int j = 0; j < GridSize.y; j += 1)
      {
        Debug.Log($"Spawn {i} {j} {GridSize}");
        GameObject _gridItem = Instantiate(Frame);
        _gridItem.transform.position = new Vector2(j * 10, i * -10);
        _gridItem.name = $"Frame[{i}][{j}]";
        _gridItem.transform.SetParent(this.transform);

        this.SetPictureGroupItem(j, i, _gridItem);
      }
    }

  }

  void SpawnPlayer()
  {
    GameObject _firstPic = _pictureGroup[0, 0].GameObject;
    PictureData _picData = _firstPic.GetComponent<PictureConfig>().PictureData;
    GameObject _player = this.PlayerSpawner.SpawnPlayer();
    _player.transform.SetParent(_firstPic.transform);
    _player.transform.localPosition = _picData.spawnPoint;

    _camera.SetPlayer(_player);

    _player.GetComponent<PlayerTeleporter>().SetPictureGroup(_pictureGroup, GridSize, _pictureGroup[0, 0]);
  }

}

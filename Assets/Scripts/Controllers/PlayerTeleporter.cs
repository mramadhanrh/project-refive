using UnityEngine;

public class PlayerTeleporter : MonoBehaviour
{
  private PictureGridItem[,] _picturegroup;
  private Vector2Int _gridSize;
  private Vector2Int _currGridPos;


  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    this.TeleportByControl();
  }

  void TeleportByControl()
  {
    if (Input.GetKeyUp(KeyCode.L))
      this.TeleportToGrid(new Vector2Int(_currGridPos.x + 1, _currGridPos.y));
    if (Input.GetKeyUp(KeyCode.J))
      this.TeleportToGrid(new Vector2Int(_currGridPos.x - 1, _currGridPos.y));
    if (Input.GetKeyUp(KeyCode.I))
      this.TeleportToGrid(new Vector2Int(_currGridPos.x, _currGridPos.y - 1));
    if (Input.GetKeyUp(KeyCode.K))
      this.TeleportToGrid(new Vector2Int(_currGridPos.x, _currGridPos.y + 1));
  }

  void TeleportToGrid(Vector2Int targetGrid)
  {
    if (targetGrid.x < _gridSize.x && targetGrid.y < _gridSize.y && targetGrid.x >= 0 && targetGrid.y >= 0)
    {
      PictureGridItem _pci = _picturegroup[targetGrid.x, targetGrid.y];
      Vector2 _spawnPoint = _pci.GameObject.GetComponent<PictureConfig>().PictureData.spawnPoint;

      this.transform.SetParent(_pci.GameObject.transform);
      this.transform.localPosition = _spawnPoint;
      _currGridPos = targetGrid;
    }
  }

  public void SetPictureGroup(PictureGridItem[,] pictureGroup, Vector2Int gridSize, PictureGridItem currGrid)
  {
    this._picturegroup = pictureGroup;
    this._gridSize = gridSize;
    this._currGridPos = new Vector2Int(currGrid.Row, currGrid.Column);
  }
}

using UnityEngine;

public class PictureGridItem
{
  public int Row;
  public int Column;
  public GameObject GameObject;

  public Vector2Int GridSize;

  public PictureGridItem(int row, int column, GameObject gameObject, Vector2Int gridSize)
  {
    Row = row;
    Column = column;
    GameObject = gameObject;
    GridSize = gridSize;
  }
};
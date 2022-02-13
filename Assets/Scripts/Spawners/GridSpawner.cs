using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GridSpawner : MonoBehaviour
{

  public Vector2 gridOffset;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  public void SpawnGrid(LevelConfig levelConfig, GridListTemplate gridList)
  {
    Vector3 gridBound = gridList.gridReference.GetComponent<SpriteRenderer>().bounds.size;
    Vector2 initPos = new Vector2(0, 0);
    Vector2 lastPos = new Vector2(0, 0);
    Dictionary<string, GameObject> gridCollection = new Dictionary<string, GameObject>();

    foreach (LevelConfigGrid grid in levelConfig.config)
    {
      GameObject gridItem = Instantiate(gridList.list[grid.gridId]);
      Vector3 gridItemBound = gridItem.GetComponent<SpriteRenderer>().bounds.size;
      gridItem.transform.position = new Vector2(
        grid.position[0] * gridBound.x + (gridItemBound.x / 2),
        grid.position[1] * gridBound.y - (gridItemBound.y / 2)
      );

      lastPos.x = grid.position[0] > lastPos.x ? grid.position[0] : lastPos.x;
      lastPos.y = grid.position[1] > lastPos.y ? grid.position[0] : lastPos.y;
      gridCollection.Add($"{grid.position[0]}{grid.position[1]}", gridItem);
    }

    SpawnGridCollider(initPos, lastPos, gridCollection);
  }

  public void SpawnGridCollider(Vector2 startPos, Vector2 endPos, Dictionary<string, GameObject> gridCollection)
  {
    Debug.Log(startPos);
    Debug.Log(endPos);
    Debug.Log(gridCollection);
    for (int i = (int)startPos.x; i <= endPos.x; i++)
    {
      Debug.Log("i: " + i);
      for (int j = (int)startPos.y; j <= endPos.y; j++)
      {
        Debug.Log("j: " + i);
        if (gridCollection[$"{i}{j}"]) Debug.Log($"{i},{j} are have grid");
        else Debug.Log($"{i},{j} dont have grid");
      }
    }
  }
}

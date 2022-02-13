using UnityEngine;

[CreateAssetMenu]
public class GridListTemplate : ScriptableObject
{
  // Must 1x1 grid for bounds reference on SpawnGrid() in GridSpawner
  public GameObject gridReference;
  public GameObject[] list;
}
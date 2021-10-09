using UnityEngine;

[CreateAssetMenu]
public class PictureData : ScriptableObject
{
  public float maxYPos;
  public float minYPos;
  public float minScale;
  public float maxScale;
  public float baseSpeed = 3;
  public float minSpeed;
  public float maxSpeed;
  public Vector2 spawnPoint;

}

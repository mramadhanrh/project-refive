using System.IO;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
  public string levelName;

  public GridListTemplate gridList;
  public GridSpawner gridSpawner;

  [SerializeField]
  private LevelConfig _levelConfig;

  // Start is called before the first frame update
  void Start()
  {
    this.LoadConfigFromJson();
    this.gridSpawner.SpawnGrid(_levelConfig, gridList);
  }

  // Update is called once per frame
  void Update()
  {

  }

  void LoadConfigFromJson()
  {
    string json = File.ReadAllText($"{Application.dataPath}/Json/LevelConfigs/{levelName}.json");
    _levelConfig = JsonUtility.FromJson<LevelConfig>(json);
  }
}

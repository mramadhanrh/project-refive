using System;

[Serializable]
public class LevelConfigGrid
{
  public int gridId;
  public int[] position = new int[2];
}


[Serializable]
public class LevelConfig
{
  public string name;
  public LevelConfigGrid[] config;
}


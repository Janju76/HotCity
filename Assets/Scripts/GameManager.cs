using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public SettingsData Settings;

    public List<BuildingType> BuildingTypes = new List<BuildingType>();
    public List<LevelData> Level = new List<LevelData>();

    public HotGrid Grid;

    public LevelData LevelData;

    public UIPreview Preview;

    public void SetBuilding(int x, int y)
    {
        if (!Grid.Tiles[y, x].HasBuilding())
        {
            BuildingData first = LevelData.BuildingQ.FirstOrDefault();
            if (first != null)
            {
                LevelData.BuildingQ.RemoveAt(0);
            }

            Grid.Tiles[y, x].SetBuilding(first);

            Preview.Refresh();
        }
    }

    private void Awake()
    {
        LevelData = Instantiate(LevelData);
        LevelData.Refresh();
        Instance = this;
    }
}
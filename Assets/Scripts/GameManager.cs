using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public SettingsData Settings;
    public int Score;

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
            if (first == null)
            {
                return;
            }

            LevelData.BuildingQ.RemoveAt(0);
            Grid.Tiles[y, x].SetBuilding(first);
            Preview.Refresh();
            Score += CalculateScore(x, y, first);
        }
    }

    private readonly int[,] Directions =
    {
        {1, 0},
        {1, 1},
        {0, 1},
        {-1, 1},
        {-1, 0},
        {-1, -1},
        {0, -1},
        {1, -1},
    };

    private int CalculateScore(int x, int y, BuildingData buildingData)
    {
        List<BuildingType> surroundingTypes = new List<BuildingType>();
        for (int direction = 0; direction < Directions.GetLength(0); direction++)
        {
            int targetX = x + Directions[direction, 0];
            int targetY = y + Directions[direction, 1];
            if (targetX >= 0 && targetX < Grid.Tiles.GetLength(1)
                && targetY >= 0 && targetY < Grid.Tiles.GetLength(0))
            {
                var gridTile = Grid.Tiles[targetY, targetX];
                if (gridTile != null)
                {
                    if (gridTile.HasBuilding())
                    {
                        surroundingTypes.Add(gridTile.GetBuildingData().buildingType);
                    }
                }
            }
        }

        int scoreIncrease = 0;
        BuildingType newBuildingType = buildingData.buildingType;
        foreach (BuildingType surroundingType in surroundingTypes)
        {
            if (newBuildingType.goodNeighbour
                .Contains(surroundingType))
            {
                scoreIncrease += 100;
            }
        }

        return scoreIncrease;
    }

    public void Init()
    {
        Score = 0;
        LevelData = Instantiate(LevelData);
        LevelData.Refresh();
        Instance = this;
    }

    private void Awake()
    {
        Init();
    }
}
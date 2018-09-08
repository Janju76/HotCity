using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu]
public class LevelData : ScriptableObject
{
    public string Name;
    public Texture2D Level;

    public BuildingData[,] BuildingOnTiles;
    public bool[,] TileExists;

    public List<BuildingData> BuildingQ = new List<BuildingData>();

    public void Refresh()
    {
        Dictionary<Color, List<BuildingData>> buildings = new Dictionary<Color, List<BuildingData>>();

        foreach (BuildingData buildingData in Resources.LoadAll<BuildingData>(""))
        {
            Color color = buildingData.colorReference;
            if (buildings.ContainsKey(color))
            {
                buildings[color].Add(buildingData);
            }
            else
            {
                buildings.Add(color, new List<BuildingData>() { buildingData });
            }
        }

        BuildingOnTiles = new BuildingData[Level.width, Level.height];
        TileExists = new bool[Level.width, Level.height];

        for (var y = 0; y < Level.height; y++)
        {
            for (var x = 0; x < Level.width; x++)
            {
                Color c = Level.GetPixel(x, y);
                if (c != Color.black) // black == no tile
                {
                    TileExists[y, x] = true;

                    if (c != Color.white) // white == empty tile
                    {
                        if (buildings.ContainsKey(c))
                        {
                            List<BuildingData> buildingsList = buildings[c];
                            BuildingOnTiles[y, x] = buildingsList[Random.Range(0, buildingsList.Count)];
                        }
                        else
                        {
                            Debug.LogWarning("leavel loading: color " + c + " not supported!");
                        }
                    }
                }
                else
                {
                    TileExists[y, x] = false;
                }
            }
        }
    }
}
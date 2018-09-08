using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class HotGrid : MonoBehaviour
{
    public List<GameObject> GroundTilePrefab;

    public Vector2 Size = new Vector2(19, 19);

    public LevelData LevelData;
    public SettingsData SettingsData;

    void OnEnable()
    {
        Refresh();
    }

    void Update()
    {

    }

    public void Refresh()
    {
        LevelData.Refresh();
        var tileDataLevelData = LevelData.Tiles;

        int totalXAmount = tileDataLevelData.GetLength(0);
        int totalYAmount = tileDataLevelData.GetLength(1);
        int halfTotalWidth = totalXAmount * (SettingsData.TileWidth+SettingsData.SpaceBetweenTiles)/2;
        int halfTotalHeight = totalYAmount * (SettingsData.TileHeight + SettingsData.SpaceBetweenTiles)/2;
        for (var y = 0; y < totalXAmount; y++)
        {
            for (var x = 0; x < totalYAmount; x++)
            {
                if (tileDataLevelData[y, x])
                {
                    int xPos = (SettingsData.TileWidth + SettingsData.SpaceBetweenTiles) * x;
                    int zPos = (SettingsData.TileHeight + SettingsData.SpaceBetweenTiles) * y;
                    int range = Random.Range(0, GroundTilePrefab.Count);
                    GameObject toInstantiate = GroundTilePrefab[range];
                    Instantiate(toInstantiate, new Vector3(xPos - halfTotalWidth, 0, zPos - halfTotalHeight), Quaternion.identity);
                }
            }
        }
    }
}

﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class HotGrid : MonoBehaviour
{
    public List<GameObject> GroundTilePrefab;
    
    public SettingsData SettingsData;

    public HotTile[,] Tiles;


    void Start()
    {
        Refresh();
    }

    void Update()
    {
    }

    public void Refresh()
    {
        
        var tileDataLevelData = GameManager.Instance.LevelData.BuildingOnTiles;

        int totalXAmount = tileDataLevelData.GetLength(0);
        int totalYAmount = tileDataLevelData.GetLength(1);

        int halfTotalWidth = totalXAmount * (SettingsData.TileWidth + SettingsData.SpaceBetweenTiles) / 2;
        int halfTotalHeight = totalYAmount * (SettingsData.TileHeight + SettingsData.SpaceBetweenTiles) / 2;


        Tiles = new HotTile[totalYAmount,totalXAmount];

        for (var y = 0; y < totalYAmount; y++)
        {
            for (var x = 0; x < totalXAmount; x++)
            {
                if (GameManager.Instance.LevelData.TileExists[y, x])
                {
                    int xPos = (SettingsData.TileWidth + SettingsData.SpaceBetweenTiles) * x;
                    int zPos = (SettingsData.TileHeight + SettingsData.SpaceBetweenTiles) * y;
                    int range = Random.Range(0, GroundTilePrefab.Count);
                    GameObject toInstantiate = GroundTilePrefab[range];
                    GameObject instantiated = Instantiate(toInstantiate,
                        new Vector3(xPos - halfTotalWidth, 0, zPos - halfTotalHeight), Quaternion.identity);
                    instantiated.transform.parent = this.transform;

                    HotTile hotTile = instantiated.GetComponent<HotTile>();
                    hotTile.SetPos(x, y);

                    if (tileDataLevelData[y, x] != null)
                    {
                        hotTile
                            .SetBuilding(tileDataLevelData[y, x]);
                    }

                    Tiles[y, x] = hotTile;
                }
            }
        }
    }
}
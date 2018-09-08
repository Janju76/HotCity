using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class HotGrid : MonoBehaviour
{
    public List<GameObject> GroundTilePrefab;

    public Vector2 Size = new Vector2(19, 19);

    public TileData TileData;
    public LevelData LevelData;

    void OnEnable()
    {
        Refresh();
    }

    void Update()
    {

    }

    public void Refresh()
    {
        TileData.Refresh();
        var tileDataLevelData = TileData.LevelData;
        for (var y = 0; y < tileDataLevelData.GetLength(0); y++)
        {
            for (var x = 0; x < tileDataLevelData.GetLength(1); x++)
            {
                if (tileDataLevelData[y, x])
                {
                    int xPos = (LevelData.TileWidth + LevelData.SpaceBetweenTiles) * x;
                    int zPos = (LevelData.TileHeight + LevelData.SpaceBetweenTiles) * y;
                    int range = Random.Range(0, GroundTilePrefab.Count);
                    Debug.Log(range);
                    GameObject toInstantiate = GroundTilePrefab[range];
                    Instantiate(toInstantiate, new Vector3(xPos, 0, zPos), Quaternion.identity);
                }
            }
        }
    }
}

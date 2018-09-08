using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelData : ScriptableObject
{
    public string Name;
    public Texture2D Level;

    public bool[,] Tiles;

    public List<BuildingData> BuildingQ = new List<BuildingData>();

    public void Refresh()
    {
        Tiles = new bool[Level.width, Level.height];
        
        for (var y = 0; y < Level.height; y++)
        {
            for (var x = 0; x < Level.width; x++)
            {
                Color c = Level.GetPixel(x, y);
                Tiles[y, x] = c.r == 0 && c.g == 0 && c.b == 0;
            }
        }
    }
}
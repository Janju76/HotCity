using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TileData : ScriptableObject
{
    public string Name;
    public Texture2D Level;

    public bool[,] LevelData;

    public void Refresh()
    {
        LevelData = new bool[Level.width, Level.height];


        for (var y = 0; y < Level.height; y++)
        {
            for (var x = 0; x < Level.width; x++)
            {
                Color c = Level.GetPixel(x, y);
                LevelData[y, x] = c.r == 0 && c.g == 0 && c.b == 0;
            }
        }
    }
}
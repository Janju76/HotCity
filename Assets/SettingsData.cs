using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SettingsData : ScriptableObject
{
    public int SpaceBetweenTiles = 5;
    public int TileWidth = 20;
    public int TileHeight = 20;

    [Header("Building Settings")]
    [Tooltip("Type of Buildings that are considered empty and will get a collider")]
    public BuildingType emptyBuildingType;
}
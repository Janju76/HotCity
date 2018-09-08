using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EBuildingSize
{
    SMALL = 1,
    LARGE = 4
}

[CreateAssetMenu(fileName = "newBuilding", menuName = "HotCity/Buildings/New Building")]
public class BuildingData : ScriptableObject
{
    public Color colorReference;

    public BuildingType buildingType;

    [Tooltip("Name of the building")]
    public string buildingName;

    public Sprite Icon;

    public EBuildingSize buildingSize = EBuildingSize.SMALL;

    [Tooltip("Building Prefab")]
    public GameObject buildingPrefab;

    public BuildingFusionDictionary fusions;

}

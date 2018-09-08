using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EBuildingTypeRelation
{
    NEUTRAL,
    GOOD,
    BAD
}

[CreateAssetMenu(fileName = "newBuildingType", menuName = "HotCity/Buildings/New Building Type")]
public class BuildingType : ScriptableObject {

    public List<BuildingType> goodNeighbour = new List<BuildingType>();
    public List<BuildingType> badNeighbour = new List<BuildingType>();


    /// <summary>
    /// Returns the BuildingType Relation
    /// </summary>
    /// <param name="otherType"></param>
    /// <returns></returns>
    public EBuildingTypeRelation GetBuildingTypeRelation(BuildingType otherType)
    {
        if (goodNeighbour.Contains(otherType))
            return EBuildingTypeRelation.GOOD;
        else
        if (badNeighbour.Contains(otherType))
            return EBuildingTypeRelation.BAD;
        else
            return EBuildingTypeRelation.NEUTRAL;

    }
}

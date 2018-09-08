using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotTile : MonoBehaviour
{
    private BuildingData  buildingData;
    private GameObject    myBuilding;

    public void SetBuilding(BuildingData newBuilding)
    {
        if (!newBuilding) return;

        if (myBuilding)
            Destroy(myBuilding);

        buildingData = newBuilding;

        if (newBuilding.buildingPrefab)
            myBuilding = Instantiate<GameObject>(newBuilding.buildingPrefab, transform);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotTile : MonoBehaviour
{
    [Tooltip("Type of Buildings that are considered empty and will get an collider")]
    public  BuildingType    emptyBuildingType;
    private BuildingData    buildingData;
    private GameObject      myBuilding;

    public void SetBuilding(BuildingData newBuilding)
    {
        if (!newBuilding) return;

        if (myBuilding)
            Destroy(myBuilding);

        buildingData = newBuilding;

        if (newBuilding.buildingPrefab)
        {
            myBuilding = Instantiate<GameObject>(newBuilding.buildingPrefab, transform);

            if (buildingData.buildingType == emptyBuildingType)
            {
                BoxCollider collider = myBuilding.AddComponent<BoxCollider>();
                MeshRenderer meshRenderer = myBuilding.GetComponentInChildren<MeshRenderer>();

                if (meshRenderer)
                {
                    collider.center = meshRenderer.bounds.center;
                    collider.size = meshRenderer.bounds.size;
                }
            }
        }
    }
}

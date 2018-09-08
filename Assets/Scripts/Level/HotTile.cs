using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HotTile : MonoBehaviour
{
    public GameObject myBuilding;

    private BuildingData    buildingData;

    public int X;
    public int Y;

    public bool HasBuilding()
    {
        return buildingData != null;
    }

    public BuildingData GetBuildingData()
    {
        return buildingData;
    }

    public void SetPos(int x, int y)
    {
        X = x;
        Y = y;
    }

    private void OnMouseEnter()
    {

    }

    private void OnMouseExit()
    {

    }

    private void OnMouseDown()
    {
        GameManager.Instance.SetBuilding(X,Y);
    }

    public void SetBuilding(BuildingData newBuilding)
    {
        if (!newBuilding) return;

        if (myBuilding)
            Destroy(myBuilding);

        buildingData = newBuilding;

        if (newBuilding.buildingPrefab)
        {
            myBuilding = Instantiate<GameObject>(newBuilding.buildingPrefab, transform);
            myBuilding.transform.localScale = buildingData.buildingScaleFactor;

            if (buildingData.buildingType == GameManager.Instance.Settings.emptyBuildingType)
            {
                BoxCollider collider = myBuilding.AddComponent<BoxCollider>();
                MeshRenderer meshRenderer = myBuilding.GetComponentInChildren<MeshRenderer>();

                if (meshRenderer)
                {
                    collider.center = Vector3.zero;
                    // Hack
                    collider.size = new Vector3(10, 10, 10);
                }
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HotTile : MonoBehaviour
{
    private BuildingData    buildingData;
    private GameObject      myBuilding;

    public int X;
    public int Y;

    public bool HasBuilding()
    {
        return buildingData != null;
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
                    collider.center = meshRenderer.bounds.center;
                    collider.size = meshRenderer.bounds.size;
                }
            }
        }
    }
}

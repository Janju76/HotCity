using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HotTile : MonoBehaviour
{
    private BuildingData    buildingData;
    private GameObject      myBuilding;

    //Detect if the Cursor starts to pass over the GameObject
    private void OnMouseEnter()
    {
        GameManager.Instance.SelectedTile = gameObject;
    }

    private void OnMouseExit()
    {
        if (GameManager.Instance.SelectedTile == gameObject)
        {
        GameManager.Instance.SelectedTile = null;
        }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public SettingsData Settings;

    public List<BuildingType> BuildingTypes = new List<BuildingType>();
    public List<LevelData> Level = new List<LevelData>();

    public HotGrid Grid;

    public GameObject SelectedTile = null;

    public void SetBuilding(int x, int y)
    {

    }

    private void Awake()
    {
        Instance = this;
    }

}

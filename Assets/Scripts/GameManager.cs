using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public SettingsData Settings;

    public BuildingType BuildingTypes;

    private void Awake()
    {
        Instance = this;
    }
}

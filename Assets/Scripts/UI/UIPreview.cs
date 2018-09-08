using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPreview : MonoBehaviour
{
    public LevelData levelData;
    public List<Image> Preview;

    public Transform Container;
    public UIPoolItem PoolItem;

    private void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        for (var i = 0; i < Preview.Count; i++)
        {
            if (i < levelData.BuildingQ.Count)
            {
                Preview[i].sprite = levelData.BuildingQ[i].Icon;
            }

            Preview[i].gameObject.SetActive(i < levelData.BuildingQ.Count);
        }

        for (var i = 0; i < Container.childCount; i++)
        {
            Destroy(Container.GetChild(i).gameObject);
        }

        foreach (var building in GameManager.Instance.BuildingTypes)
        {
            var item = Instantiate(PoolItem, Container);

            item.Text.text = building.name;
            item.Icon.sprite = building.Icon;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPreview : MonoBehaviour
{
    public List<Image> Preview;

    public Transform Container;
    public UIPoolItem PoolItem;
    public Text Score;

    private void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        for (var i = 0; i < Preview.Count; i++)
        {
            if (i < GameManager.Instance.LevelData.BuildingQ.Count)
            {
                Preview[i].sprite = GameManager.Instance.LevelData.BuildingQ[i].Icon;
            }

            Preview[i].gameObject.SetActive(i < GameManager.Instance.LevelData.BuildingQ.Count);
        }

        for (var i = 0; i < Container.childCount; i++)
        {
            Destroy(Container.GetChild(i).gameObject);
        }

        foreach (var building in GameManager.Instance.BuildingTypes)
        {
            var item = Instantiate(PoolItem, Container);

            var cnt = 0;

            for (var i = Preview.Count; i < GameManager.Instance.LevelData.BuildingQ.Count; i++)
            {
                if (GameManager.Instance.LevelData.BuildingQ[i].buildingType == building)
                {
                    cnt++;
                }
            }

            item.Text.text = string.Format("x{0}", cnt);
            item.Icon.color = building.TileColor;
        }
    }
}

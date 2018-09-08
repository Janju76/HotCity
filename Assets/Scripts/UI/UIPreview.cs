using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPreview : MonoBehaviour
{
    public List<Image> Preview;

    public Transform Container;
    public UIPoolItem PoolItem;

    private void OnEnable()
    {
        Refresh();
    }

    public void Refresh()
    {
        for (var i = 0; i < Container.childCount; i++)
        {
            Destroy(Container.GetChild(i).gameObject);
        }
    }
}

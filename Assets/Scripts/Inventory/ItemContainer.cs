using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ItemSlot
{
    public Item item;
    public int count;
}
public class ItemContainer : MonoBehaviour
{
    [SerializeField] private Inventory inventoryPanel;
    [SerializeField] private GameObject itemPanel;
    [SerializeField] private List<ItemSlot> items;
    [SerializeField] private GameObject itemPrefab;

    public void ShowItems()
    {
        foreach (Transform child in itemPanel.transform)
        {
            Destroy(child.gameObject);
        }
        for (int i = 0; i < items.Count; i++)
        {
            GameObject itemInstance = Instantiate(itemPrefab, itemPanel.transform);
            itemInstance.GetComponent<ItemUI>().itemName.text = items[i].item.itemName;
            itemInstance.GetComponent<ItemUI>().count.text = items[i].count.ToString();
            itemInstance.GetComponent<ItemUI>().icon.sprite = items[i].item.icon;
        }
    }
}

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
    public ItemSlot(Item itemToAdd, int countToAdd)
    {
        item = itemToAdd;
        count = countToAdd;
    }
}
public class ItemContainer : MonoBehaviour
{
    [SerializeField] private Inventory inventoryPanel;
    [SerializeField] private GameObject itemPanel;
    [SerializeField] private GameObject itemPrefab;

    private GameManager gm;
    private void Start()
    {
        gm = GameManager.GetInstance();
    }
    public void ShowItems()
    {
        foreach (Transform child in itemPanel.transform)
        {
            Destroy(child.gameObject);
        }
        if (gm == null)
        {
            gm = GameManager.GetInstance();
        }
        InventoryManager invManage = gm.inventoryManager;
        for (int i = 0; i < invManage.items.Count; i++)
        {
            GameObject itemInstance = Instantiate(itemPrefab, itemPanel.transform);
            itemInstance.GetComponent<ItemUI>().itemName.text = invManage.items[i].item.itemName;
            itemInstance.GetComponent<ItemUI>().count.text = invManage.items[i].count.ToString();
            itemInstance.GetComponent<ItemUI>().icon.sprite = invManage.items[i].item.icon;
        }
    }
}

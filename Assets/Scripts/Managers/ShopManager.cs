using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour, iDataPersistence
{
    [SerializeField] public List<Item> shopItems;
    
    public static ShopManager instance { get; private set; }

    public void LoadData(GameData data)
    {
        InventoryManager inv = InventoryManager.instance;
        if ( data.shopManagerIds.Count > 0 )
        {
            shopItems.Clear();
        }
        foreach (Item dbItem in inv.itemsDatabase)
        {
            if (data.shopManagerIds.Contains(dbItem.id))
            {
                shopItems.Add(dbItem);
            }
        }
    }

    public void SaveData(ref GameData data)
    {
        data.shopManagerIds.Clear();

        foreach (Item dbItem in shopItems)
        {
            data.shopManagerIds.Add(dbItem.id);
        }
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("more than one shop manager");
        }
        instance = this;
    }

}

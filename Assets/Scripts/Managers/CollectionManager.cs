using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CollectionSlot
{
    public Item item;
    public bool discovered;
    public CollectionSlot(Item itemToAdd, bool isDiscovered)
    {
        item = itemToAdd;
        discovered = isDiscovered;
    }
}
public class CollectionManager : MonoBehaviour, iDataPersistence
{
    public List<CollectionSlot> collection;

    public static CollectionManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("more than one collection manager");
        }
        instance = this;
    }

    public bool discoverNew(Item itemToDiscover)
    {
        foreach (CollectionSlot slot in collection)
        {
            if (slot.item.id == itemToDiscover.id)
            {
                bool alreadyDiscovered = slot.discovered;
                slot.discovered = true;
                return alreadyDiscovered;
            }
        }
        return false;
    }

    public int getAllDiscovered()
    {
        int discoveredItems = 0;
        foreach (CollectionSlot slot in collection)
        {
            if (slot.discovered)
            {
                discoveredItems++;
            }
        }
        return discoveredItems;
    }
    public void LoadData(GameData data)
    {
        InventoryManager inv = InventoryManager.instance;
        foreach (Item dbItem in inv.itemsDatabase)
        {
            if (data.collection.ContainsKey(dbItem.id))
            {
                bool isdiscovered;
                data.collection.TryGetValue(dbItem.id, out isdiscovered);
                foreach ( CollectionSlot collectionItem in collection)
                {
                    if ( dbItem.id == collectionItem.item.id )
                    {
                        collectionItem.discovered = isdiscovered;
                    }
                }
            }
        }
    }
    public void SaveData(ref GameData data)
    {
        foreach (CollectionSlot slot in collection)
        {
            if (data.collection.ContainsKey(slot.item.id))
            {
                data.collection.Remove(slot.item.id);
            }
            data.collection.Add(slot.item.id, slot.discovered);
        }
        if (collection.Count == 0)
        {
            data.collection.Clear();
        }
    }
}

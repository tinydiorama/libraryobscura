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
public class CollectionManager : MonoBehaviour
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
        foreach ( CollectionSlot slot in collection )
        {
            if ( slot.item.id == itemToDiscover.id )
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
}

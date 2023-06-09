using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[Serializable]
public class GrimoireItem
{
    public Item plant;
    public bool discovered;
    public GrimoireItem(Item plantToAdd, bool isDiscovered)
    {
        plant = plantToAdd;
        discovered = isDiscovered;
    }
}
public class GrimoireController : MonoBehaviour, iDataPersistence
{
    [SerializeField] private List<GrimoireItem> grimoire;
    private GameManager gm;

    private void Start()
    {
        gm = GameManager.GetInstance();
        List<Item> inv = gm.inventoryManager.itemsDatabase; 

        foreach( Item item in inv )
        {
            if (item.category.ToString() == "Plant" )
            {
                grimoire.Add(new GrimoireItem(item, false));
            }
        }
    }

    public void SaveData(ref GameData data)
    {
        data.grimoire.Clear();
        foreach( GrimoireItem plant in grimoire )
        {
            data.grimoire.Add(plant.plant.id, plant.discovered);
        }
    }

    public void LoadData(GameData data)
    {
        grimoire.Clear();
        gm = GameManager.GetInstance();
        List<Item> inv = gm.inventoryManager.itemsDatabase;

        foreach (Item item in inv)
        {
            if (item.category.ToString() == "Plant")
            {
                grimoire.Add(new GrimoireItem(item, false));
            }
        }

        foreach (GrimoireItem plant in grimoire)
        {
            if ( data.grimoire.ContainsKey(plant.plant.id) )
            {
                bool isDiscovered;
                data.grimoire.TryGetValue(plant.plant.id, out isDiscovered);
                plant.discovered = isDiscovered;
            }
        }
    }
}

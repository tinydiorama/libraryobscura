using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Category { Seed, Plant, KeyItem };


[CreateAssetMenu(menuName = "Item/Item")]
public class Item : ScriptableObject
{
    public string id;
    public string itemName;
    public Sprite icon;
    public bool sellable;
    public bool buyable;
    public bool canBeSacrificed;
    public Category category;
    public int buyPrice;
    public int sellPrice;
    [TextArea(5, 10)]
    public string itemDesc;

    public Sprite[] seedImages;
    public Item harvestPlant;
    public Item crossBreed1;
    public Item crossBreedResult1;
    public Item crossBreed2;
    public Item crossBreedResult2;
    public Item crossBreed3;
    public Item crossBreedResult3;

    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }
}

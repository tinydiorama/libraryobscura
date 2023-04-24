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
    public Category category;

    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }
}

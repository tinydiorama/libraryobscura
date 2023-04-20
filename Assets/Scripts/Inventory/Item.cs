using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Category { Seed, Plant, KeyItem };


[CreateAssetMenu(menuName = "Item/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public bool sellable;
    public Category category;

}

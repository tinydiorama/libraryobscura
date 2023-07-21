using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarData : MonoBehaviour
{
    [Header("Lucid Sprig and Lucid Sprig")]
    public List<Item> lucidSprigItems;
    [Header("Lucid Sprig and Dwarf Sage")]
    public List<Item> lucidSprigDwarfSageItems;
    [Header("Dwarf Sage and Dwarf Sage")]
    public List<Item> dwarfSageItems;

    public List<Item> getSacrificeItems(Item item1, Item item2)
    {
        if ( item1.id == "lucidsprigplant" && item2.id == "lucidsprigplant")
        {
            return lucidSprigItems;
        } else if (item1.id == "lucidsprigplant" && item2.id == "dwarfsageplant" ||
            item1.id == "dwarfsageplant" && item2.id == "lucidsprigplant")
        {
            return lucidSprigDwarfSageItems;
        }
        else if (item1.id == "dwarfsageplant" && item2.id == "dwarfsageplant")
        {
            return dwarfSageItems;
        }
        return new List<Item>();
    }
}

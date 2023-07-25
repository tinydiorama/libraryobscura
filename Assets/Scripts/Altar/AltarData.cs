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
    [Header("Cloudsprig and Cloudsprig")]
    public List<Item> cloudsprigItems;
    [Header("Cloudsprig and Dwarfsage")]
    public List<Item> cloudsprigDwarfSageItems;
    [Header("Cloudsprig and Lucid Sprig")]
    public List<Item> cloudsprigLucidSprigItems;
    [Header("Grand Titian and Grand Titian")]
    public List<Item> grandtitianItems;
    [Header("Grand Titian and Lucid Sprig")]
    public List<Item> grandtitianLucidSprigItems;
    [Header("Grand Titian and Dwarf Sage")]
    public List<Item> grandtitianDwarfSageItems;
    [Header("Grand Titian and Cloudsprig")]
    public List<Item> grandtitianCloudSprigItems;
    [Header("Ophidian's Eye and Ophidian's Eye")]
    public List<Item> ophidianeyeItems;
    [Header("Ophidian's Eye and Lucid Sprig")]
    public List<Item> ophidianeyeLucidSprigItems;
    [Header("Ophidian's Eye and Dwarf Sage")]
    public List<Item> ophidianeyeDwarfSageItems;
    [Header("Ophidian's Eye and Cloudsprig")]
    public List<Item> ophidianeyeCloudSprigItems;
    [Header("Ophidian's Eye and Grand Titian")]
    public List<Item> ophidianeyeGrandTitianItems;

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
        else if (item1.id == "cloudsprigplant" && item2.id == "cloudsprigplant")
        {
            return cloudsprigItems;
        }
        else if (item1.id == "cloudsprigplant" && item2.id == "dwarfsageplant" ||
            item1.id == "dwarfsageplant" && item2.id == "cloudsprigplant")
        {
            return cloudsprigDwarfSageItems;
        }
        else if (item1.id == "cloudsprigplant" && item2.id == "lucidsprigplant" ||
            item1.id == "lucidsprigplant" && item2.id == "cloudsprigplant")
        {
            return cloudsprigLucidSprigItems;
        }
        else if (item1.id == "grandtitianplant" && item2.id == "grandtitianplant")
        {
            return grandtitianItems;
        }
        else if (item1.id == "grandtitianplant" && item2.id == "dwarfsageplant" ||
            item1.id == "dwarfsageplant" && item2.id == "grandtitianplant")
        {
            return grandtitianDwarfSageItems;
        }
        else if (item1.id == "grandtitianplant" && item2.id == "lucidsprigplant" ||
            item1.id == "lucidsprigplant" && item2.id == "grandtitianplant")
        {
            return grandtitianLucidSprigItems;
        }
        else if (item1.id == "grandtitianplant" && item2.id == "cloudsprigplant" ||
            item1.id == "cloudsprigplant" && item2.id == "grandtitianplant")
        {
            return grandtitianCloudSprigItems;
        }
        else if (item1.id == "ophidianeyeplant" && item2.id == "ophidianeyeplant")
        {
            return ophidianeyeItems;
        }
        else if (item1.id == "ophidianeyeplant" && item2.id == "dwarfsageplant" ||
            item1.id == "dwarfsageplant" && item2.id == "ophidianeyeplant")
        {
            return ophidianeyeDwarfSageItems;
        }
        else if (item1.id == "ophidianeyeplant" && item2.id == "lucidsprigplant" ||
            item1.id == "lucidsprigplant" && item2.id == "ophidianeyeplant")
        {
            return ophidianeyeLucidSprigItems;
        }
        else if (item1.id == "ophidianeyeplant" && item2.id == "cloudsprigplant" ||
            item1.id == "cloudsprigplant" && item2.id == "ophidianeyeplant")
        {
            return ophidianeyeCloudSprigItems;
        }
        else if (item1.id == "ophidianeyeplant" && item2.id == "grandtitianplant" ||
            item1.id == "grandtitianplant" && item2.id == "ophidianeyeplant")
        {
            return ophidianeyeGrandTitianItems;
        }
        return new List<Item>();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarData : MonoBehaviour
{
    [Header("Lucid Sprig items")]
    public List<Item> lucidSprigItems;
    [Header("Dwarf Sage items")]
    public List<Item> lucidSprigDwarfSageItems;
    public List<Item> dwarfSageItems;
    [Header("Cloudsprig items")]
    public List<Item> cloudsprigItems;
    public List<Item> cloudsprigDwarfSageItems;
    public List<Item> cloudsprigLucidSprigItems;
    [Header("Grand Titian items")]
    public List<Item> grandtitianItems;
    public List<Item> grandtitianLucidSprigItems;
    public List<Item> grandtitianDwarfSageItems;
    public List<Item> grandtitianCloudSprigItems;
    [Header("Ophidian's Eye items")]
    public List<Item> ophidianeyeItems;
    public List<Item> ophidianeyeLucidSprigItems;
    public List<Item> ophidianeyeDwarfSageItems;
    public List<Item> ophidianeyeCloudSprigItems;
    public List<Item> ophidianeyeGrandTitianItems;
    [Header("Sunbloom items")]
    public List<Item> sunbloomItems;
    public List<Item> sunbloomLucidSprigItems;
    public List<Item> sunbloomDwarfSageItems;
    public List<Item> sunbloomCloudSprigItems;
    public List<Item> sunbloomGrandTitianItems;
    public List<Item> sunbloomOphidianEyeItems;
    [Header("Bloodroot items")]
    public List<Item> bloodrootItems;
    public List<Item> bloodrootLucidSprigItems;
    public List<Item> bloodrootDwarfSageItems;
    public List<Item> bloodrootCloudSprigItems;
    public List<Item> bloodrootGrandTitianItems;
    public List<Item> bloodrootOphidianEyeItems;
    public List<Item> bloodrootSunbloomItems;
    [Header("Divine Needle items")]
    public List<Item> divineNeedleItems;
    public List<Item> divineNeedleLucidSprigItems;
    public List<Item> divineNeedleDwarfSageItems;
    public List<Item> divineNeedleCloudSprigItems;
    public List<Item> divineNeedleGrandTitianItems;
    public List<Item> divineNeedleOphidianEyeItems;
    public List<Item> divineNeedleSunbloomItems;
    public List<Item> divineNeedleBloodrootItems;
    [Header("Heliotrope items")]
    public List<Item> heliotropeItems;
    public List<Item> heliotropeLucidSprigItems;
    public List<Item> heliotropeDwarfSageItems;
    public List<Item> heliotropeCloudSprigItems;
    public List<Item> heliotropeGrandTitianItems;
    public List<Item> heliotropeOphidianEyeItems;
    public List<Item> heliotropeSunbloomItems;
    public List<Item> heliotropeBloodrootItems;
    public List<Item> heliotropeDivineNeedleItems;

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
        else if (item1.id == "sunbloomplant" && item2.id == "sunbloomplant")
        {
            return sunbloomItems;
        }
        else if (item1.id == "sunbloomplant" && item2.id == "dwarfsageplant" ||
            item1.id == "dwarfsageplant" && item2.id == "sunbloomplant")
        {
            return sunbloomDwarfSageItems;
        }
        else if (item1.id == "sunbloomplant" && item2.id == "lucidsprigplant" ||
            item1.id == "lucidsprigplant" && item2.id == "sunbloomplant")
        {
            return sunbloomLucidSprigItems;
        }
        else if (item1.id == "sunbloomplant" && item2.id == "cloudsprigplant" ||
            item1.id == "cloudsprigplant" && item2.id == "sunbloomplant")
        {
            return sunbloomCloudSprigItems;
        }
        else if (item1.id == "sunbloomplant" && item2.id == "grandtitianplant" ||
            item1.id == "grandtitianplant" && item2.id == "sunbloomplant")
        {
            return sunbloomGrandTitianItems;
        }
        else if (item1.id == "sunbloomplant" && item2.id == "ophidianeyeplant" ||
            item1.id == "ophidianeyeplant" && item2.id == "sunbloomplant")
        {
            return sunbloomOphidianEyeItems;
        }
        else if (item1.id == "bloodrootplant" && item2.id == "bloodrootplant")
        {
            return bloodrootItems;
        }
        else if (item1.id == "bloodrootplant" && item2.id == "dwarfsageplant" ||
            item1.id == "dwarfsageplant" && item2.id == "bloodrootplant")
        {
            return bloodrootDwarfSageItems;
        }
        else if (item1.id == "bloodrootplant" && item2.id == "lucidsprigplant" ||
            item1.id == "lucidsprigplant" && item2.id == "bloodrootplant")
        {
            return bloodrootLucidSprigItems;
        }
        else if (item1.id == "bloodrootplant" && item2.id == "cloudsprigplant" ||
            item1.id == "cloudsprigplant" && item2.id == "bloodrootplant")
        {
            return bloodrootCloudSprigItems;
        }
        else if (item1.id == "bloodrootplant" && item2.id == "grandtitianplant" ||
            item1.id == "grandtitianplant" && item2.id == "bloodrootplant")
        {
            return bloodrootGrandTitianItems;
        }
        else if (item1.id == "bloodrootplant" && item2.id == "ophidianeyeplant" ||
            item1.id == "ophidianeyeplant" && item2.id == "bloodrootplant")
        {
            return bloodrootOphidianEyeItems;
        }
        else if (item1.id == "bloodrootplant" && item2.id == "sunbloomplant" ||
            item1.id == "sunbloomplant" && item2.id == "bloodrootplant")
        {
            return bloodrootSunbloomItems;
        }
        else if (item1.id == "divineneedleplant" && item2.id == "divineneedleplant")
        {
            return divineNeedleItems;
        }
        else if (item1.id == "divineneedleplant" && item2.id == "dwarfsageplant" ||
            item1.id == "dwarfsageplant" && item2.id == "divineneedleplant")
        {
            return divineNeedleDwarfSageItems;
        }
        else if (item1.id == "divineneedleplant" && item2.id == "lucidsprigplant" ||
            item1.id == "lucidsprigplant" && item2.id == "divineneedleplant")
        {
            return divineNeedleLucidSprigItems;
        }
        else if (item1.id == "divineneedleplant" && item2.id == "cloudsprigplant" ||
            item1.id == "cloudsprigplant" && item2.id == "divineneedleplant")
        {
            return divineNeedleCloudSprigItems;
        }
        else if (item1.id == "divineneedleplant" && item2.id == "grandtitianplant" ||
            item1.id == "grandtitianplant" && item2.id == "divineneedleplant")
        {
            return divineNeedleGrandTitianItems;
        }
        else if (item1.id == "divineneedleplant" && item2.id == "ophidianeyeplant" ||
            item1.id == "ophidianeyeplant" && item2.id == "divineneedleplant")
        {
            return divineNeedleOphidianEyeItems;
        }
        else if (item1.id == "divineneedleplant" && item2.id == "sunbloomplant" ||
            item1.id == "sunbloomplant" && item2.id == "divineneedleplant")
        {
            return divineNeedleSunbloomItems;
        }
        else if (item1.id == "divineneedleplant" && item2.id == "bloodrootplant" ||
            item1.id == "bloodrootplant" && item2.id == "divineneedleplant")
        {
            return divineNeedleBloodrootItems;
        }
        else if (item1.id == "heliotropeplant" && item2.id == "heliotropeplant")
        {
            return heliotropeItems;
        }
        else if (item1.id == "heliotropeplant" && item2.id == "dwarfsageplant" ||
            item1.id == "dwarfsageplant" && item2.id == "heliotropeplant")
        {
            return heliotropeDwarfSageItems;
        }
        else if (item1.id == "heliotropeplant" && item2.id == "lucidsprigplant" ||
            item1.id == "lucidsprigplant" && item2.id == "heliotropeplant")
        {
            return heliotropeLucidSprigItems;
        }
        else if (item1.id == "heliotropeplant" && item2.id == "cloudsprigplant" ||
            item1.id == "cloudsprigplant" && item2.id == "heliotropeplant")
        {
            return heliotropeCloudSprigItems;
        }
        else if (item1.id == "heliotropeplant" && item2.id == "grandtitianplant" ||
            item1.id == "grandtitianplant" && item2.id == "heliotropeplant")
        {
            return heliotropeGrandTitianItems;
        }
        else if (item1.id == "heliotropeplant" && item2.id == "ophidianeyeplant" ||
            item1.id == "ophidianeyeplant" && item2.id == "heliotropeplant")
        {
            return heliotropeOphidianEyeItems;
        }
        else if (item1.id == "heliotropeplant" && item2.id == "sunbloomplant" ||
            item1.id == "sunbloomplant" && item2.id == "heliotropeplant")
        {
            return heliotropeSunbloomItems;
        }
        else if (item1.id == "heliotropeplant" && item2.id == "bloodrootplant" ||
            item1.id == "bloodrootplant" && item2.id == "heliotropeplant")
        {
            return heliotropeBloodrootItems;
        }
        else if (item1.id == "heliotropeplant" && item2.id == "divineneedleplant" ||
            item1.id == "divineneedleplant" && item2.id == "heliotropeplant")
        {
            return heliotropeDivineNeedleItems;
        }
        return new List<Item>();
    }
}

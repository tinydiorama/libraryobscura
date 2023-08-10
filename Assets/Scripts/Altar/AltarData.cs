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
    [Header("Stormvine items")]
    public List<Item> stormvineItems;
    public List<Item> stormvineLucidSprigItems;
    public List<Item> stormvineDwarfSageItems;
    public List<Item> stormvineCloudSprigItems;
    public List<Item> stormvineGrandTitianItems;
    public List<Item> stormvineOphidianEyeItems;
    public List<Item> stormvineSunbloomItems;
    public List<Item> stormvineBloodrootItems;
    public List<Item> stormvineDivineNeedleItems;
    public List<Item> stormvineHeliotropeItems;
    [Header("Brimstone items")]
    public List<Item> brimstoneItems;
    public List<Item> brimstoneLucidSprigItems;
    public List<Item> brimstoneDwarfSageItems;
    public List<Item> brimstoneCloudSprigItems;
    public List<Item> brimstoneGrandTitianItems;
    public List<Item> brimstoneOphidianEyeItems;
    public List<Item> brimstoneSunbloomItems;
    public List<Item> brimstoneBloodrootItems;
    public List<Item> brimstoneDivineNeedleItems;
    public List<Item> brimstoneHeliotropeItems;
    public List<Item> brimstoneStormvineItems;
    [Header("Twilight Fern items")]
    public List<Item> twilightFernItems;
    public List<Item> twilightFernLucidSprigItems;
    public List<Item> twilightFernDwarfSageItems;
    public List<Item> twilightFernCloudSprigItems;
    public List<Item> twilightFernGrandTitianItems;
    public List<Item> twilightFernOphidianEyeItems;
    public List<Item> twilightFernSunbloomItems;
    public List<Item> twilightFernBloodrootItems;
    public List<Item> twilightFernDivineNeedleItems;
    public List<Item> twilightFernHeliotropeItems;
    public List<Item> twilightFernStormvineItems;
    public List<Item> twilightFernBrimstoneItems;
    [Header("Aureate items")]
    public List<Item> aureateItems;
    public List<Item> aureateLucidSprigItems;
    public List<Item> aureateDwarfSageItems;
    public List<Item> aureateCloudSprigItems;
    public List<Item> aureateGrandTitianItems;
    public List<Item> aureateOphidianEyeItems;
    public List<Item> aureateSunbloomItems;
    public List<Item> aureateBloodrootItems;
    public List<Item> aureateDivineNeedleItems;
    public List<Item> aureateHeliotropeItems;
    public List<Item> aureateStormvineItems;
    public List<Item> aureateBrimstoneItems;
    public List<Item> aureateTwilightFernItems;
    [Header("Boorish Thyme items")]
    public List<Item> boorishThymeItems;
    public List<Item> boorishThymeLucidSprigItems;
    public List<Item> boorishThymeDwarfSageItems;
    public List<Item> boorishThymeCloudSprigItems;
    public List<Item> boorishThymeGrandTitianItems;
    public List<Item> boorishThymeOphidianEyeItems;
    public List<Item> boorishThymeSunbloomItems;
    public List<Item> boorishThymeBloodrootItems;
    public List<Item> boorishThymeDivineNeedleItems;
    public List<Item> boorishThymeHeliotropeItems;
    public List<Item> boorishThymeStormvineItems;
    public List<Item> boorishThymeBrimstoneItems;
    public List<Item> boorishThymeTwilightFernItems;
    public List<Item> boorishThymeAureateItems;
    [Header("Brightflower items")]
    public List<Item> brightflowerItems;
    public List<Item> brightflowerLucidSprigItems;
    public List<Item> brightflowerDwarfSageItems;
    public List<Item> brightflowerCloudSprigItems;
    public List<Item> brightflowerGrandTitianItems;
    public List<Item> brightflowerOphidianEyeItems;
    public List<Item> brightflowerSunbloomItems;
    public List<Item> brightflowerBloodrootItems;
    public List<Item> brightflowerDivineNeedleItems;
    public List<Item> brightflowerHeliotropeItems;
    public List<Item> brightflowerStormvineItems;
    public List<Item> brightflowerBrimstoneItems;
    public List<Item> brightflowerTwilightFernItems;
    public List<Item> brightflowerAureateItems;
    public List<Item> brightflowerBoorishThymeItems;

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
        else if (item1.id == "stormvineplant" && item2.id == "stormvineplant")
        {
            return stormvineItems;
        }
        else if (item1.id == "stormvineplant" && item2.id == "dwarfsageplant" ||
            item1.id == "dwarfsageplant" && item2.id == "stormvineplant")
        {
            return stormvineDwarfSageItems;
        }
        else if (item1.id == "stormvineplant" && item2.id == "lucidsprigplant" ||
            item1.id == "lucidsprigplant" && item2.id == "stormvineplant")
        {
            return stormvineLucidSprigItems;
        }
        else if (item1.id == "stormvineplant" && item2.id == "cloudsprigplant" ||
            item1.id == "cloudsprigplant" && item2.id == "stormvineplant")
        {
            return stormvineCloudSprigItems;
        }
        else if (item1.id == "stormvineplant" && item2.id == "grandtitianplant" ||
            item1.id == "grandtitianplant" && item2.id == "stormvineplant")
        {
            return stormvineGrandTitianItems;
        }
        else if (item1.id == "stormvineplant" && item2.id == "ophidianeyeplant" ||
            item1.id == "ophidianeyeplant" && item2.id == "stormvineplant")
        {
            return stormvineOphidianEyeItems;
        }
        else if (item1.id == "stormvineplant" && item2.id == "sunbloomplant" ||
            item1.id == "sunbloomplant" && item2.id == "stormvineplant")
        {
            return stormvineSunbloomItems;
        }
        else if (item1.id == "stormvineplant" && item2.id == "bloodrootplant" ||
            item1.id == "bloodrootplant" && item2.id == "stormvineplant")
        {
            return stormvineBloodrootItems;
        }
        else if (item1.id == "stormvineplant" && item2.id == "divineneedleplant" ||
            item1.id == "divineneedleplant" && item2.id == "stormvineplant")
        {
            return stormvineDivineNeedleItems;
        }
        else if (item1.id == "stormvineplant" && item2.id == "heliotropeplant" ||
            item1.id == "heliotropeplant" && item2.id == "stormvineplant")
        {
            return stormvineHeliotropeItems;
        }
        else if (item1.id == "brimstoneplant" && item2.id == "brimstoneplant")
        {
            return brimstoneItems;
        }
        else if (item1.id == "brimstoneplant" && item2.id == "dwarfsageplant" ||
            item1.id == "dwarfsageplant" && item2.id == "brimstoneplant")
        {
            return brimstoneDwarfSageItems;
        }
        else if (item1.id == "brimstoneplant" && item2.id == "lucidsprigplant" ||
            item1.id == "lucidsprigplant" && item2.id == "brimstoneplant")
        {
            return brimstoneLucidSprigItems;
        }
        else if (item1.id == "brimstoneplant" && item2.id == "cloudsprigplant" ||
            item1.id == "cloudsprigplant" && item2.id == "brimstoneplant")
        {
            return brimstoneCloudSprigItems;
        }
        else if (item1.id == "brimstoneplant" && item2.id == "grandtitianplant" ||
            item1.id == "grandtitianplant" && item2.id == "brimstoneplant")
        {
            return brimstoneGrandTitianItems;
        }
        else if (item1.id == "brimstoneplant" && item2.id == "ophidianeyeplant" ||
            item1.id == "ophidianeyeplant" && item2.id == "brimstoneplant")
        {
            return brimstoneOphidianEyeItems;
        }
        else if (item1.id == "brimstoneplant" && item2.id == "sunbloomplant" ||
            item1.id == "sunbloomplant" && item2.id == "brimstoneplant")
        {
            return brimstoneSunbloomItems;
        }
        else if (item1.id == "brimstoneplant" && item2.id == "bloodrootplant" ||
            item1.id == "bloodrootplant" && item2.id == "brimstoneplant")
        {
            return brimstoneBloodrootItems;
        }
        else if (item1.id == "brimstoneplant" && item2.id == "divineneedleplant" ||
            item1.id == "divineneedleplant" && item2.id == "brimstoneplant")
        {
            return brimstoneDivineNeedleItems;
        }
        else if (item1.id == "brimstoneplant" && item2.id == "heliotropeplant" ||
            item1.id == "heliotropeplant" && item2.id == "brimstoneplant")
        {
            return brimstoneHeliotropeItems;
        }
        else if (item1.id == "brimstoneplant" && item2.id == "stormvineplant" ||
            item1.id == "stormvineplant" && item2.id == "brimstoneplant")
        {
            return brimstoneStormvineItems;
        }
        else if (item1.id == "twilightfernplant" && item2.id == "twilightfernplant")
        {
            return twilightFernItems;
        }
        else if (item1.id == "twilightfernplant" && item2.id == "dwarfsageplant" ||
            item1.id == "dwarfsageplant" && item2.id == "twilightfernplant")
        {
            return twilightFernDwarfSageItems;
        }
        else if (item1.id == "twilightfernplant" && item2.id == "lucidsprigplant" ||
            item1.id == "lucidsprigplant" && item2.id == "twilightfernplant")
        {
            return twilightFernLucidSprigItems;
        }
        else if (item1.id == "twilightfernplant" && item2.id == "cloudsprigplant" ||
            item1.id == "cloudsprigplant" && item2.id == "twilightfernplant")
        {
            return twilightFernCloudSprigItems;
        }
        else if (item1.id == "twilightfernplant" && item2.id == "grandtitianplant" ||
            item1.id == "grandtitianplant" && item2.id == "twilightfernplant")
        {
            return twilightFernGrandTitianItems;
        }
        else if (item1.id == "twilightfernplant" && item2.id == "ophidianeyeplant" ||
            item1.id == "ophidianeyeplant" && item2.id == "twilightfernplant")
        {
            return twilightFernOphidianEyeItems;
        }
        else if (item1.id == "twilightfernplant" && item2.id == "sunbloomplant" ||
            item1.id == "sunbloomplant" && item2.id == "twilightfernplant")
        {
            return twilightFernSunbloomItems;
        }
        else if (item1.id == "twilightfernplant" && item2.id == "bloodrootplant" ||
            item1.id == "bloodrootplant" && item2.id == "twilightfernplant")
        {
            return twilightFernBloodrootItems;
        }
        else if (item1.id == "twilightfernplant" && item2.id == "divineneedleplant" ||
            item1.id == "divineneedleplant" && item2.id == "twilightfernplant")
        {
            return twilightFernDivineNeedleItems;
        }
        else if (item1.id == "twilightfernplant" && item2.id == "heliotropeplant" ||
            item1.id == "heliotropeplant" && item2.id == "twilightfernplant")
        {
            return twilightFernHeliotropeItems;
        }
        else if (item1.id == "twilightfernplant" && item2.id == "stormvineplant" ||
            item1.id == "stormvineplant" && item2.id == "twilightfernplant")
        {
            return twilightFernStormvineItems;
        }
        else if (item1.id == "twilightfernplant" && item2.id == "brimstoneplant" ||
            item1.id == "brimstoneplant" && item2.id == "twilightfernplant")
        {
            return twilightFernBrimstoneItems;
        }
        else if (item1.id == "aureateplant" && item2.id == "aureateplant")
        {
            return aureateItems;
        }
        else if (item1.id == "aureateplant" && item2.id == "dwarfsageplant" ||
            item1.id == "dwarfsageplant" && item2.id == "aureateplant")
        {
            return aureateDwarfSageItems;
        }
        else if (item1.id == "aureateplant" && item2.id == "lucidsprigplant" ||
            item1.id == "lucidsprigplant" && item2.id == "aureateplant")
        {
            return aureateLucidSprigItems;
        }
        else if (item1.id == "aureateplant" && item2.id == "cloudsprigplant" ||
            item1.id == "cloudsprigplant" && item2.id == "aureateplant")
        {
            return aureateCloudSprigItems;
        }
        else if (item1.id == "aureateplant" && item2.id == "grandtitianplant" ||
            item1.id == "grandtitianplant" && item2.id == "aureateplant")
        {
            return aureateGrandTitianItems;
        }
        else if (item1.id == "aureateplant" && item2.id == "ophidianeyeplant" ||
            item1.id == "ophidianeyeplant" && item2.id == "aureateplant")
        {
            return aureateOphidianEyeItems;
        }
        else if (item1.id == "aureateplant" && item2.id == "sunbloomplant" ||
            item1.id == "sunbloomplant" && item2.id == "aureateplant")
        {
            return aureateSunbloomItems;
        }
        else if (item1.id == "aureateplant" && item2.id == "bloodrootplant" ||
            item1.id == "bloodrootplant" && item2.id == "aureateplant")
        {
            return aureateBloodrootItems;
        }
        else if (item1.id == "aureateplant" && item2.id == "divineneedleplant" ||
            item1.id == "divineneedleplant" && item2.id == "aureateplant")
        {
            return aureateDivineNeedleItems;
        }
        else if (item1.id == "aureateplant" && item2.id == "heliotropeplant" ||
            item1.id == "heliotropeplant" && item2.id == "aureateplant")
        {
            return aureateHeliotropeItems;
        }
        else if (item1.id == "aureateplant" && item2.id == "stormvineplant" ||
            item1.id == "stormvineplant" && item2.id == "aureateplant")
        {
            return aureateStormvineItems;
        }
        else if (item1.id == "aureateplant" && item2.id == "brimstoneplant" ||
            item1.id == "brimstoneplant" && item2.id == "aureateplant")
        {
            return aureateBrimstoneItems;
        }
        else if (item1.id == "aureateplant" && item2.id == "twilightfernplant" ||
            item1.id == "twilightfernplant" && item2.id == "aureateplant")
        {
            return aureateTwilightFernItems;
        }
        else if (item1.id == "boorishthymeplant" && item2.id == "boorishthymeplant")
        {
            return boorishThymeItems;
        }
        else if (item1.id == "boorishthymeplant" && item2.id == "dwarfsageplant" ||
            item1.id == "dwarfsageplant" && item2.id == "boorishthymeplant")
        {
            return boorishThymeDwarfSageItems;
        }
        else if (item1.id == "boorishthymeplant" && item2.id == "lucidsprigplant" ||
            item1.id == "lucidsprigplant" && item2.id == "boorishthymeplant")
        {
            return boorishThymeLucidSprigItems;
        }
        else if (item1.id == "boorishthymeplant" && item2.id == "cloudsprigplant" ||
            item1.id == "cloudsprigplant" && item2.id == "boorishthymeplant")
        {
            return boorishThymeCloudSprigItems;
        }
        else if (item1.id == "boorishthymeplant" && item2.id == "grandtitianplant" ||
            item1.id == "grandtitianplant" && item2.id == "boorishthymeplant")
        {
            return boorishThymeGrandTitianItems;
        }
        else if (item1.id == "boorishthymeplant" && item2.id == "ophidianeyeplant" ||
            item1.id == "ophidianeyeplant" && item2.id == "boorishthymeplant")
        {
            return boorishThymeOphidianEyeItems;
        }
        else if (item1.id == "boorishthymeplant" && item2.id == "sunbloomplant" ||
            item1.id == "sunbloomplant" && item2.id == "boorishthymeplant")
        {
            return boorishThymeSunbloomItems;
        }
        else if (item1.id == "boorishthymeplant" && item2.id == "bloodrootplant" ||
            item1.id == "bloodrootplant" && item2.id == "boorishthymeplant")
        {
            return boorishThymeBloodrootItems;
        }
        else if (item1.id == "boorishthymeplant" && item2.id == "divineneedleplant" ||
            item1.id == "divineneedleplant" && item2.id == "boorishthymeplant")
        {
            return boorishThymeDivineNeedleItems;
        }
        else if (item1.id == "boorishthymeplant" && item2.id == "heliotropeplant" ||
            item1.id == "heliotropeplant" && item2.id == "boorishthymeplant")
        {
            return boorishThymeHeliotropeItems;
        }
        else if (item1.id == "boorishthymeplant" && item2.id == "stormvineplant" ||
            item1.id == "stormvineplant" && item2.id == "boorishthymeplant")
        {
            return boorishThymeStormvineItems;
        }
        else if (item1.id == "boorishthymeplant" && item2.id == "brimstoneplant" ||
            item1.id == "brimstoneplant" && item2.id == "boorishthymeplant")
        {
            return boorishThymeBrimstoneItems;
        }
        else if (item1.id == "boorishthymeplant" && item2.id == "twilightfernplant" ||
            item1.id == "twilightfernplant" && item2.id == "boorishthymeplant")
        {
            return boorishThymeTwilightFernItems;
        }
        else if (item1.id == "boorishthymeplant" && item2.id == "aureate" ||
            item1.id == "aureate" && item2.id == "boorishthymeplant")
        {
            return boorishThymeAureateItems;
        }
        else if (item1.id == "brightflowerplant" && item2.id == "brightflowerplant")
        {
            return brightflowerItems;
        }
        else if (item1.id == "brightflowerplant" && item2.id == "dwarfsageplant" ||
            item1.id == "dwarfsageplant" && item2.id == "brightflowerplant")
        {
            return brightflowerDwarfSageItems;
        }
        else if (item1.id == "brightflowerplant" && item2.id == "lucidsprigplant" ||
            item1.id == "lucidsprigplant" && item2.id == "brightflowerplant")
        {
            return brightflowerLucidSprigItems;
        }
        else if (item1.id == "brightflowerplant" && item2.id == "cloudsprigplant" ||
            item1.id == "cloudsprigplant" && item2.id == "brightflowerplant")
        {
            return brightflowerCloudSprigItems;
        }
        else if (item1.id == "brightflowerplant" && item2.id == "grandtitianplant" ||
            item1.id == "grandtitianplant" && item2.id == "brightflowerplant")
        {
            return brightflowerGrandTitianItems;
        }
        else if (item1.id == "brightflowerplant" && item2.id == "ophidianeyeplant" ||
            item1.id == "ophidianeyeplant" && item2.id == "brightflowerplant")
        {
            return brightflowerOphidianEyeItems;
        }
        else if (item1.id == "brightflowerplant" && item2.id == "sunbloomplant" ||
            item1.id == "sunbloomplant" && item2.id == "brightflowerplant")
        {
            return brightflowerSunbloomItems;
        }
        else if (item1.id == "brightflowerplant" && item2.id == "bloodrootplant" ||
            item1.id == "bloodrootplant" && item2.id == "brightflowerplant")
        {
            return brightflowerBloodrootItems;
        }
        else if (item1.id == "brightflowerplant" && item2.id == "divineneedleplant" ||
            item1.id == "divineneedleplant" && item2.id == "brightflowerplant")
        {
            return brightflowerDivineNeedleItems;
        }
        else if (item1.id == "brightflowerplant" && item2.id == "heliotropeplant" ||
            item1.id == "heliotropeplant" && item2.id == "brightflowerplant")
        {
            return brightflowerHeliotropeItems;
        }
        else if (item1.id == "brightflowerplant" && item2.id == "stormvineplant" ||
            item1.id == "stormvineplant" && item2.id == "brightflowerplant")
        {
            return brightflowerStormvineItems;
        }
        else if (item1.id == "brightflowerplant" && item2.id == "brimstoneplant" ||
            item1.id == "brimstoneplant" && item2.id == "brightflowerplant")
        {
            return brightflowerBrimstoneItems;
        }
        else if (item1.id == "brightflowerplant" && item2.id == "twilightfernplant" ||
            item1.id == "twilightfernplant" && item2.id == "brightflowerplant")
        {
            return brightflowerTwilightFernItems;
        }
        else if (item1.id == "brightflowerplant" && item2.id == "aureate" ||
            item1.id == "aureate" && item2.id == "brightflowerplant")
        {
            return brightflowerAureateItems;
        }
        else if (item1.id == "brightflowerplant" && item2.id == "boorishthymeplant" ||
            item1.id == "boorishthymeplant" && item2.id == "brightflowerplant")
        {
            return brightflowerBoorishThymeItems;
        }
        return new List<Item>();
    }
}

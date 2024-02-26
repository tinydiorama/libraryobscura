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
    [Header("Dark spinneret items")]
    public List<Item> darkspinneretItems;
    public List<Item> darkspinneretLucidSprigItems;
    public List<Item> darkspinneretDwarfSageItems;
    public List<Item> darkspinneretCloudSprigItems;
    public List<Item> darkspinneretGrandTitianItems;
    public List<Item> darkspinneretOphidianEyeItems;
    public List<Item> darkspinneretSunbloomItems;
    public List<Item> darkspinneretBloodrootItems;
    public List<Item> darkspinneretDivineNeedleItems;
    public List<Item> darkspinneretHeliotropeItems;
    public List<Item> darkspinneretStormvineItems;
    public List<Item> darkspinneretBrimstoneItems;
    public List<Item> darkspinneretTwilightFernItems;
    public List<Item> darkspinneretAureateItems;
    public List<Item> darkspinneretBoorishThymeItems;
    public List<Item> darkspinneretBrightflowerItems;
    [Header("Dusk Dendron items")]
    public List<Item> duskdendronItems;
    public List<Item> duskdendronLucidSprigItems;
    public List<Item> duskdendronDwarfSageItems;
    public List<Item> duskdendronCloudSprigItems;
    public List<Item> duskdendronGrandTitianItems;
    public List<Item> duskdendronOphidianEyeItems;
    public List<Item> duskdendronSunbloomItems;
    public List<Item> duskdendronBloodrootItems;
    public List<Item> duskdendronDivineNeedleItems;
    public List<Item> duskdendronHeliotropeItems;
    public List<Item> duskdendronStormvineItems;
    public List<Item> duskdendronBrimstoneItems;
    public List<Item> duskdendronTwilightFernItems;
    public List<Item> duskdendronAureateItems;
    public List<Item> duskdendronBoorishThymeItems;
    public List<Item> duskdendronBrightflowerItems;
    public List<Item> duskdendronDarkspinneretItems;
    [Header("Harsh Snapjaw items")]
    public List<Item> harshSnapjawItems;
    public List<Item> harshSnapjawLucidSprigItems;
    public List<Item> harshSnapjawDwarfSageItems;
    public List<Item> harshSnapjawCloudSprigItems;
    public List<Item> harshSnapjawGrandTitianItems;
    public List<Item> harshSnapjawOphidianEyeItems;
    public List<Item> harshSnapjawSunbloomItems;
    public List<Item> harshSnapjawBloodrootItems;
    public List<Item> harshSnapjawDivineNeedleItems;
    public List<Item> harshSnapjawHeliotropeItems;
    public List<Item> harshSnapjawStormvineItems;
    public List<Item> harshSnapjawBrimstoneItems;
    public List<Item> harshSnapjawTwilightFernItems;
    public List<Item> harshSnapjawAureateItems;
    public List<Item> harshSnapjawBoorishThymeItems;
    public List<Item> harshSnapjawBrightflowerItems;
    public List<Item> harshSnapjawDarkspinneretItems;
    public List<Item> harshSnapjawDuskDendronItems;
    [Header("Razorback items")]
    public List<Item> razorbackItems;
    public List<Item> razorbackLucidSprigItems;
    public List<Item> razorbackDwarfSageItems;
    public List<Item> razorbackCloudSprigItems;
    public List<Item> razorbackGrandTitianItems;
    public List<Item> razorbackOphidianEyeItems;
    public List<Item> razorbackSunbloomItems;
    public List<Item> razorbackBloodrootItems;
    public List<Item> razorbackDivineNeedleItems;
    public List<Item> razorbackHeliotropeItems;
    public List<Item> razorbackStormvineItems;
    public List<Item> razorbackBrimstoneItems;
    public List<Item> razorbackTwilightFernItems;
    public List<Item> razorbackAureateItems;
    public List<Item> razorbackBoorishThymeItems;
    public List<Item> razorbackBrightflowerItems;
    public List<Item> razorbackDarkspinneretItems;
    public List<Item> razorbackDuskDendronItems;
    public List<Item> razorbackHarshSnapjawItems;
    [Header("Murky Siltstrider items")]
    public List<Item> murkySiltstriderItems;
    public List<Item> murkySiltstriderLucidSprigItems;
    public List<Item> murkySiltstriderDwarfSageItems;
    public List<Item> murkySiltstriderCloudSprigItems;
    public List<Item> murkySiltstriderGrandTitianItems;
    public List<Item> murkySiltstriderOphidianEyeItems;
    public List<Item> murkySiltstriderSunbloomItems;
    public List<Item> murkySiltstriderBloodrootItems;
    public List<Item> murkySiltstriderDivineNeedleItems;
    public List<Item> murkySiltstriderHeliotropeItems;
    public List<Item> murkySiltstriderStormvineItems;
    public List<Item> murkySiltstriderBrimstoneItems;
    public List<Item> murkySiltstriderTwilightFernItems;
    public List<Item> murkySiltstriderAureateItems;
    public List<Item> murkySiltstriderBoorishThymeItems;
    public List<Item> murkySiltstriderBrightflowerItems;
    public List<Item> murkySiltstriderDarkspinneretItems;
    public List<Item> murkySiltstriderDuskDendronItems;
    public List<Item> murkySiltstriderHarshSnapjawItems;
    public List<Item> murkySiltstriderRazorbackItems;
    [Header("Pale Verruca items")]
    public List<Item> paleVerrucaItems;
    public List<Item> paleVerrucaLucidSprigItems;
    public List<Item> paleVerrucaDwarfSageItems;
    public List<Item> paleVerrucaCloudSprigItems;
    public List<Item> paleVerrucaGrandTitianItems;
    public List<Item> paleVerrucaOphidianEyeItems;
    public List<Item> paleVerrucaSunbloomItems;
    public List<Item> paleVerrucaBloodrootItems;
    public List<Item> paleVerrucaDivineNeedleItems;
    public List<Item> paleVerrucaHeliotropeItems;
    public List<Item> paleVerrucaStormvineItems;
    public List<Item> paleVerrucaBrimstoneItems;
    public List<Item> paleVerrucaTwilightFernItems;
    public List<Item> paleVerrucaAureateItems;
    public List<Item> paleVerrucaBoorishThymeItems;
    public List<Item> paleVerrucaBrightflowerItems;
    public List<Item> paleVerrucaDarkspinneretItems;
    public List<Item> paleVerrucaDuskDendronItems;
    public List<Item> paleVerrucaHarshSnapjawItems;
    public List<Item> paleVerrucaRazorbackItems;
    public List<Item> paleVerrucaMurkySiltstriderItems;
    [Header("Sanguine Clover items")]
    public List<Item> sanguineCloverItems;
    public List<Item> sanguineCloverLucidSprigItems;
    public List<Item> sanguineCloverDwarfSageItems;
    public List<Item> sanguineCloverCloudSprigItems;
    public List<Item> sanguineCloverGrandTitianItems;
    public List<Item> sanguineCloverOphidianEyeItems;
    public List<Item> sanguineCloverSunbloomItems;
    public List<Item> sanguineCloverBloodrootItems;
    public List<Item> sanguineCloverDivineNeedleItems;
    public List<Item> sanguineCloverHeliotropeItems;
    public List<Item> sanguineCloverStormvineItems;
    public List<Item> sanguineCloverBrimstoneItems;
    public List<Item> sanguineCloverTwilightFernItems;
    public List<Item> sanguineCloverAureateItems;
    public List<Item> sanguineCloverBoorishThymeItems;
    public List<Item> sanguineCloverBrightflowerItems;
    public List<Item> sanguineCloverDarkspinneretItems;
    public List<Item> sanguineCloverDuskDendronItems;
    public List<Item> sanguineCloverHarshSnapjawItems;
    public List<Item> sanguineCloverRazorbackItems;
    public List<Item> sanguineCloverMurkySiltstriderItems;
    public List<Item> sanguineCloverPaleVerrucaItems;
    [Header("Sunworn Thistle items")]
    public List<Item> sunwornThistleItems;
    public List<Item> sunwornThistleLucidSprigItems;
    public List<Item> sunwornThistleDwarfSageItems;
    public List<Item> sunwornThistleCloudSprigItems;
    public List<Item> sunwornThistleGrandTitianItems;
    public List<Item> sunwornThistleOphidianEyeItems;
    public List<Item> sunwornThistleSunbloomItems;
    public List<Item> sunwornThistleBloodrootItems;
    public List<Item> sunwornThistleDivineNeedleItems;
    public List<Item> sunwornThistleHeliotropeItems;
    public List<Item> sunwornThistleStormvineItems;
    public List<Item> sunwornThistleBrimstoneItems;
    public List<Item> sunwornThistleTwilightFernItems;
    public List<Item> sunwornThistleAureateItems;
    public List<Item> sunwornThistleBoorishThymeItems;
    public List<Item> sunwornThistleBrightflowerItems;
    public List<Item> sunwornThistleDarkspinneretItems;
    public List<Item> sunwornThistleDuskDendronItems;
    public List<Item> sunwornThistleHarshSnapjawItems;
    public List<Item> sunwornThistleRazorbackItems;
    public List<Item> sunwornThistleMurkySiltstriderItems;
    public List<Item> sunwornThistlePaleVerrucaItems;
    public List<Item> sunwornThistleSanguineCloverItems;
    [Header("Thorned Esprit items")]
    public List<Item> thornedEspritItems;
    public List<Item> thornedEspritLucidSprigItems;
    public List<Item> thornedEspritDwarfSageItems;
    public List<Item> thornedEspritCloudSprigItems;
    public List<Item> thornedEspritGrandTitianItems;
    public List<Item> thornedEspritOphidianEyeItems;
    public List<Item> thornedEspritSunbloomItems;
    public List<Item> thornedEspritBloodrootItems;
    public List<Item> thornedEspritDivineNeedleItems;
    public List<Item> thornedEspritHeliotropeItems;
    public List<Item> thornedEspritStormvineItems;
    public List<Item> thornedEspritBrimstoneItems;
    public List<Item> thornedEspritTwilightFernItems;
    public List<Item> thornedEspritAureateItems;
    public List<Item> thornedEspritBoorishThymeItems;
    public List<Item> thornedEspritBrightflowerItems;
    public List<Item> thornedEspritDarkspinneretItems;
    public List<Item> thornedEspritDuskDendronItems;
    public List<Item> thornedEspritHarshSnapjawItems;
    public List<Item> thornedEspritRazorbackItems;
    public List<Item> thornedEspritMurkySiltstriderItems;
    public List<Item> thornedEspritPaleVerrucaItems;
    public List<Item> thornedEspritSanguineCloverItems;
    public List<Item> thornedEspritSunwornThistleItems;
    [Header("Waxy Laurel items")]
    public List<Item> waxyLaurelItems;
    public List<Item> waxyLaurelLucidSprigItems;
    public List<Item> waxyLaurelDwarfSageItems;
    public List<Item> waxyLaurelCloudSprigItems;
    public List<Item> waxyLaurelGrandTitianItems;
    public List<Item> waxyLaurelOphidianEyeItems;
    public List<Item> waxyLaurelSunbloomItems;
    public List<Item> waxyLaurelBloodrootItems;
    public List<Item> waxyLaurelDivineNeedleItems;
    public List<Item> waxyLaurelHeliotropeItems;
    public List<Item> waxyLaurelStormvineItems;
    public List<Item> waxyLaurelBrimstoneItems;
    public List<Item> waxyLaurelTwilightFernItems;
    public List<Item> waxyLaurelAureateItems;
    public List<Item> waxyLaurelBoorishThymeItems;
    public List<Item> waxyLaurelBrightflowerItems;
    public List<Item> waxyLaurelDarkspinneretItems;
    public List<Item> waxyLaurelDuskDendronItems;
    public List<Item> waxyLaurelHarshSnapjawItems;
    public List<Item> waxyLaurelRazorbackItems;
    public List<Item> waxyLaurelMurkySiltstriderItems;
    public List<Item> waxyLaurelPaleVerrucaItems;
    public List<Item> waxyLaurelSanguineCloverItems;
    public List<Item> waxyLaurelSunwornThistleItems;
    public List<Item> waxyLaurelThornedEspritItems;

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
        else if (item1.id == "boorishthymeplant" && item2.id == "aureateplant" ||
            item1.id == "aureateplant" && item2.id == "boorishthymeplant")
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
        else if (item1.id == "brightflowerplant" && item2.id == "aureateplant" ||
            item1.id == "aureateplant" && item2.id == "brightflowerplant")
        {
            return brightflowerAureateItems;
        }
        else if (item1.id == "brightflowerplant" && item2.id == "boorishthymeplant" ||
            item1.id == "boorishthymeplant" && item2.id == "brightflowerplant")
        {
            return brightflowerBoorishThymeItems;
        }
        else if (item1.id == "darkspinneretplant" && item2.id == "darkspinneretplant")
        {
            return darkspinneretItems;
        }
        else if (item1.id == "darkspinneretplant" && item2.id == "dwarfsageplant" ||
            item1.id == "dwarfsageplant" && item2.id == "darkspinneretplant")
        {
            return darkspinneretDwarfSageItems;
        }
        else if (item1.id == "darkspinneretplant" && item2.id == "lucidsprigplant" ||
            item1.id == "lucidsprigplant" && item2.id == "darkspinneretplant")
        {
            return darkspinneretLucidSprigItems;
        }
        else if (item1.id == "darkspinneretplant" && item2.id == "cloudsprigplant" ||
            item1.id == "cloudsprigplant" && item2.id == "darkspinneretplant")
        {
            return darkspinneretCloudSprigItems;
        }
        else if (item1.id == "darkspinneretplant" && item2.id == "grandtitianplant" ||
            item1.id == "grandtitianplant" && item2.id == "darkspinneretplant")
        {
            return darkspinneretGrandTitianItems;
        }
        else if (item1.id == "darkspinneretplant" && item2.id == "ophidianeyeplant" ||
            item1.id == "ophidianeyeplant" && item2.id == "darkspinneretplant")
        {
            return darkspinneretOphidianEyeItems;
        }
        else if (item1.id == "darkspinneretplant" && item2.id == "sunbloomplant" ||
            item1.id == "sunbloomplant" && item2.id == "darkspinneretplant")
        {
            return darkspinneretSunbloomItems;
        }
        else if (item1.id == "darkspinneretplant" && item2.id == "bloodrootplant" ||
            item1.id == "bloodrootplant" && item2.id == "darkspinneretplant")
        {
            return darkspinneretBloodrootItems;
        }
        else if (item1.id == "darkspinneretplant" && item2.id == "divineneedleplant" ||
            item1.id == "divineneedleplant" && item2.id == "darkspinneretplant")
        {
            return darkspinneretDivineNeedleItems;
        }
        else if (item1.id == "darkspinneretplant" && item2.id == "heliotropeplant" ||
            item1.id == "heliotropeplant" && item2.id == "darkspinneretplant")
        {
            return darkspinneretHeliotropeItems;
        }
        else if (item1.id == "darkspinneretplant" && item2.id == "stormvineplant" ||
            item1.id == "stormvineplant" && item2.id == "darkspinneretplant")
        {
            return darkspinneretStormvineItems;
        }
        else if (item1.id == "darkspinneretplant" && item2.id == "brimstoneplant" ||
            item1.id == "brimstoneplant" && item2.id == "darkspinneretplant")
        {
            return darkspinneretBrimstoneItems;
        }
        else if (item1.id == "darkspinneretplant" && item2.id == "twilightfernplant" ||
            item1.id == "twilightfernplant" && item2.id == "darkspinneretplant")
        {
            return darkspinneretTwilightFernItems;
        }
        else if (item1.id == "darkspinneretplant" && item2.id == "aureateplant" ||
            item1.id == "aureateplant" && item2.id == "darkspinneretplant")
        {
            return darkspinneretAureateItems;
        }
        else if (item1.id == "darkspinneretplant" && item2.id == "boorishthymeplant" ||
            item1.id == "boorishthymeplant" && item2.id == "darkspinneretplant")
        {
            return darkspinneretBoorishThymeItems;
        }
        else if (item1.id == "darkspinneretplant" && item2.id == "brightflowerplant" ||
            item1.id == "brightflowerplant" && item2.id == "darkspinneretplant")
        {
            return darkspinneretBrightflowerItems;
        }
        else if (item1.id == "duskdendronplant" && item2.id == "duskdendronplant")
        {
            return duskdendronItems;
        }
        else if (item1.id == "duskdendronplant" && item2.id == "dwarfsageplant" ||
            item1.id == "dwarfsageplant" && item2.id == "duskdendronplant")
        {
            return duskdendronDwarfSageItems;
        }
        else if (item1.id == "duskdendronplant" && item2.id == "lucidsprigplant" ||
            item1.id == "lucidsprigplant" && item2.id == "duskdendronplant")
        {
            return duskdendronLucidSprigItems;
        }
        else if (item1.id == "duskdendronplant" && item2.id == "cloudsprigplant" ||
            item1.id == "cloudsprigplant" && item2.id == "duskdendronplant")
        {
            return duskdendronCloudSprigItems;
        }
        else if (item1.id == "duskdendronplant" && item2.id == "grandtitianplant" ||
            item1.id == "grandtitianplant" && item2.id == "duskdendronplant")
        {
            return duskdendronGrandTitianItems;
        }
        else if (item1.id == "duskdendronplant" && item2.id == "ophidianeyeplant" ||
            item1.id == "ophidianeyeplant" && item2.id == "duskdendronplant")
        {
            return duskdendronOphidianEyeItems;
        }
        else if (item1.id == "duskdendronplant" && item2.id == "sunbloomplant" ||
            item1.id == "sunbloomplant" && item2.id == "duskdendronplant")
        {
            return duskdendronSunbloomItems;
        }
        else if (item1.id == "duskdendronplant" && item2.id == "bloodrootplant" ||
            item1.id == "bloodrootplant" && item2.id == "duskdendronplant")
        {
            return duskdendronBloodrootItems;
        }
        else if (item1.id == "duskdendronplant" && item2.id == "divineneedleplant" ||
            item1.id == "divineneedleplant" && item2.id == "duskdendronplant")
        {
            return duskdendronDivineNeedleItems;
        }
        else if (item1.id == "duskdendronplant" && item2.id == "heliotropeplant" ||
            item1.id == "heliotropeplant" && item2.id == "duskdendronplant")
        {
            return duskdendronHeliotropeItems;
        }
        else if (item1.id == "duskdendronplant" && item2.id == "stormvineplant" ||
            item1.id == "stormvineplant" && item2.id == "duskdendronplant")
        {
            return duskdendronStormvineItems;
        }
        else if (item1.id == "duskdendronplant" && item2.id == "brimstoneplant" ||
            item1.id == "brimstoneplant" && item2.id == "duskdendronplant")
        {
            return duskdendronBrimstoneItems;
        }
        else if (item1.id == "duskdendronplant" && item2.id == "twilightfernplant" ||
            item1.id == "twilightfernplant" && item2.id == "duskdendronplant")
        {
            return duskdendronTwilightFernItems;
        }
        else if (item1.id == "duskdendronplant" && item2.id == "aureateplant" ||
            item1.id == "aureateplant" && item2.id == "duskdendronplant")
        {
            return duskdendronAureateItems;
        }
        else if (item1.id == "duskdendronplant" && item2.id == "boorishthymeplant" ||
            item1.id == "boorishthymeplant" && item2.id == "duskdendronplant")
        {
            return duskdendronBoorishThymeItems;
        }
        else if (item1.id == "duskdendronplant" && item2.id == "brightflowerplant" ||
            item1.id == "brightflowerplant" && item2.id == "duskdendronplant")
        {
            return duskdendronBrightflowerItems;
        }
        else if (item1.id == "duskdendronplant" && item2.id == "darkspinneretplant" ||
            item1.id == "darkspinneretplant" && item2.id == "duskdendronplant")
        {
            return duskdendronDarkspinneretItems;
        }
        else if (item1.id == "harshsnapjawplant" && item2.id == "harshsnapjawplant")
        {
            return harshSnapjawItems;
        }
        else if (item1.id == "harshsnapjawplant" && item2.id == "dwarfsageplant" ||
            item1.id == "dwarfsageplant" && item2.id == "harshsnapjawplant")
        {
            return harshSnapjawDwarfSageItems;
        }
        else if (item1.id == "harshsnapjawplant" && item2.id == "lucidsprigplant" ||
            item1.id == "lucidsprigplant" && item2.id == "harshsnapjawplant")
        {
            return harshSnapjawLucidSprigItems;
        }
        else if (item1.id == "harshsnapjawplant" && item2.id == "cloudsprigplant" ||
            item1.id == "cloudsprigplant" && item2.id == "harshsnapjawplant")
        {
            return harshSnapjawCloudSprigItems;
        }
        else if (item1.id == "harshsnapjawplant" && item2.id == "grandtitianplant" ||
            item1.id == "grandtitianplant" && item2.id == "harshsnapjawplant")
        {
            return harshSnapjawGrandTitianItems;
        }
        else if (item1.id == "harshsnapjawplant" && item2.id == "ophidianeyeplant" ||
            item1.id == "ophidianeyeplant" && item2.id == "harshsnapjawplant")
        {
            return harshSnapjawOphidianEyeItems;
        }
        else if (item1.id == "harshsnapjawplant" && item2.id == "sunbloomplant" ||
            item1.id == "sunbloomplant" && item2.id == "harshsnapjawplant")
        {
            return harshSnapjawSunbloomItems;
        }
        else if (item1.id == "harshsnapjawplant" && item2.id == "bloodrootplant" ||
            item1.id == "bloodrootplant" && item2.id == "harshsnapjawplant")
        {
            return harshSnapjawBloodrootItems;
        }
        else if (item1.id == "harshsnapjawplant" && item2.id == "divineneedleplant" ||
            item1.id == "divineneedleplant" && item2.id == "harshsnapjawplant")
        {
            return harshSnapjawDivineNeedleItems;
        }
        else if (item1.id == "harshsnapjawplant" && item2.id == "heliotropeplant" ||
            item1.id == "heliotropeplant" && item2.id == "harshsnapjawplant")
        {
            return harshSnapjawHeliotropeItems;
        }
        else if (item1.id == "harshsnapjawplant" && item2.id == "stormvineplant" ||
            item1.id == "stormvineplant" && item2.id == "harshsnapjawplant")
        {
            return harshSnapjawStormvineItems;
        }
        else if (item1.id == "harshsnapjawplant" && item2.id == "brimstoneplant" ||
            item1.id == "brimstoneplant" && item2.id == "harshsnapjawplant")
        {
            return harshSnapjawBrimstoneItems;
        }
        else if (item1.id == "harshsnapjawplant" && item2.id == "twilightfernplant" ||
            item1.id == "twilightfernplant" && item2.id == "harshsnapjawplant")
        {
            return harshSnapjawTwilightFernItems;
        }
        else if (item1.id == "harshsnapjawplant" && item2.id == "aureateplant" ||
            item1.id == "aureateplant" && item2.id == "harshsnapjawplant")
        {
            return harshSnapjawAureateItems;
        }
        else if (item1.id == "harshsnapjawplant" && item2.id == "boorishthymeplant" ||
            item1.id == "boorishthymeplant" && item2.id == "harshsnapjawplant")
        {
            return harshSnapjawBoorishThymeItems;
        }
        else if (item1.id == "harshsnapjawplant" && item2.id == "brightflowerplant" ||
            item1.id == "brightflowerplant" && item2.id == "harshsnapjawplant")
        {
            return harshSnapjawBrightflowerItems;
        }
        else if (item1.id == "harshsnapjawplant" && item2.id == "darkspinneretplant" ||
            item1.id == "darkspinneretplant" && item2.id == "harshsnapjawplant")
        {
            return harshSnapjawDarkspinneretItems;
        }
        else if (item1.id == "harshsnapjawplant" && item2.id == "duskdendronplant" ||
            item1.id == "duskdendronplant" && item2.id == "harshsnapjawplant")
        {
            return harshSnapjawDuskDendronItems;
        }
        else if (item1.id == "razorbackplant" && item2.id == "razorbackplant")
        {
            return razorbackItems;
        }
        else if (item1.id == "razorbackplant" && item2.id == "dwarfsageplant" ||
            item1.id == "dwarfsageplant" && item2.id == "razorbackplant")
        {
            return razorbackDwarfSageItems;
        }
        else if (item1.id == "razorbackplant" && item2.id == "lucidsprigplant" ||
            item1.id == "lucidsprigplant" && item2.id == "razorbackplant")
        {
            return razorbackLucidSprigItems;
        }
        else if (item1.id == "razorbackplant" && item2.id == "cloudsprigplant" ||
            item1.id == "cloudsprigplant" && item2.id == "razorbackplant")
        {
            return razorbackCloudSprigItems;
        }
        else if (item1.id == "razorbackplant" && item2.id == "grandtitianplant" ||
            item1.id == "grandtitianplant" && item2.id == "razorbackplant")
        {
            return razorbackGrandTitianItems;
        }
        else if (item1.id == "razorbackplant" && item2.id == "ophidianeyeplant" ||
            item1.id == "ophidianeyeplant" && item2.id == "razorbackplant")
        {
            return razorbackOphidianEyeItems;
        }
        else if (item1.id == "razorbackplant" && item2.id == "sunbloomplant" ||
            item1.id == "sunbloomplant" && item2.id == "razorbackplant")
        {
            return razorbackSunbloomItems;
        }
        else if (item1.id == "razorbackplant" && item2.id == "bloodrootplant" ||
            item1.id == "bloodrootplant" && item2.id == "razorbackplant")
        {
            return razorbackBloodrootItems;
        }
        else if (item1.id == "razorbackplant" && item2.id == "divineneedleplant" ||
            item1.id == "divineneedleplant" && item2.id == "razorbackplant")
        {
            return razorbackDivineNeedleItems;
        }
        else if (item1.id == "razorbackplant" && item2.id == "heliotropeplant" ||
            item1.id == "heliotropeplant" && item2.id == "razorbackplant")
        {
            return razorbackHeliotropeItems;
        }
        else if (item1.id == "razorbackplant" && item2.id == "stormvineplant" ||
            item1.id == "stormvineplant" && item2.id == "razorbackplant")
        {
            return razorbackStormvineItems;
        }
        else if (item1.id == "razorbackplant" && item2.id == "brimstoneplant" ||
            item1.id == "brimstoneplant" && item2.id == "razorbackplant")
        {
            return razorbackBrimstoneItems;
        }
        else if (item1.id == "razorbackplant" && item2.id == "twilightfernplant" ||
            item1.id == "twilightfernplant" && item2.id == "razorbackplant")
        {
            return razorbackTwilightFernItems;
        }
        else if (item1.id == "razorbackplant" && item2.id == "aureateplant" ||
            item1.id == "aureateplant" && item2.id == "razorbackplant")
        {
            return razorbackAureateItems;
        }
        else if (item1.id == "razorbackplant" && item2.id == "boorishthymeplant" ||
            item1.id == "boorishthymeplant" && item2.id == "razorbackplant")
        {
            return razorbackBoorishThymeItems;
        }
        else if (item1.id == "razorbackplant" && item2.id == "brightflowerplant" ||
            item1.id == "brightflowerplant" && item2.id == "razorbackplant")
        {
            return razorbackBrightflowerItems;
        }
        else if (item1.id == "razorbackplant" && item2.id == "darkspinneretplant" ||
            item1.id == "darkspinneretplant" && item2.id == "razorbackplant")
        {
            return razorbackDarkspinneretItems;
        }
        else if (item1.id == "razorbackplant" && item2.id == "duskdendronplant" ||
            item1.id == "duskdendronplant" && item2.id == "razorbackplant")
        {
            return razorbackDuskDendronItems;
        }
        else if (item1.id == "razorbackplant" && item2.id == "harshsnapjawplant" ||
            item1.id == "harshsnapjawplant" && item2.id == "razorbackplant")
        {
            return razorbackHarshSnapjawItems;
        }
        else if (item1.id == "murkysiltstriderplant" && item2.id == "murkysiltstriderplant")
        {
            return murkySiltstriderItems;
        }
        else if (item1.id == "murkysiltstriderplant" && item2.id == "dwarfsageplant" ||
            item1.id == "dwarfsageplant" && item2.id == "murkysiltstriderplant")
        {
            return murkySiltstriderDwarfSageItems;
        }
        else if (item1.id == "murkysiltstriderplant" && item2.id == "lucidsprigplant" ||
            item1.id == "lucidsprigplant" && item2.id == "murkysiltstriderplant")
        {
            return murkySiltstriderLucidSprigItems;
        }
        else if (item1.id == "murkysiltstriderplant" && item2.id == "cloudsprigplant" ||
            item1.id == "cloudsprigplant" && item2.id == "murkysiltstriderplant")
        {
            return murkySiltstriderCloudSprigItems;
        }
        else if (item1.id == "murkysiltstriderplant" && item2.id == "grandtitianplant" ||
            item1.id == "grandtitianplant" && item2.id == "murkysiltstriderplant")
        {
            return murkySiltstriderGrandTitianItems;
        }
        else if (item1.id == "murkysiltstriderplant" && item2.id == "ophidianeyeplant" ||
            item1.id == "ophidianeyeplant" && item2.id == "murkysiltstriderplant")
        {
            return murkySiltstriderOphidianEyeItems;
        }
        else if (item1.id == "murkysiltstriderplant" && item2.id == "sunbloomplant" ||
            item1.id == "sunbloomplant" && item2.id == "murkysiltstriderplant")
        {
            return murkySiltstriderSunbloomItems;
        }
        else if (item1.id == "murkysiltstriderplant" && item2.id == "bloodrootplant" ||
            item1.id == "bloodrootplant" && item2.id == "murkysiltstriderplant")
        {
            return murkySiltstriderBloodrootItems;
        }
        else if (item1.id == "murkysiltstriderplant" && item2.id == "divineneedleplant" ||
            item1.id == "divineneedleplant" && item2.id == "murkysiltstriderplant")
        {
            return murkySiltstriderDivineNeedleItems;
        }
        else if (item1.id == "murkysiltstriderplant" && item2.id == "heliotropeplant" ||
            item1.id == "heliotropeplant" && item2.id == "murkysiltstriderplant")
        {
            return murkySiltstriderHeliotropeItems;
        }
        else if (item1.id == "murkysiltstriderplant" && item2.id == "stormvineplant" ||
            item1.id == "stormvineplant" && item2.id == "murkysiltstriderplant")
        {
            return murkySiltstriderStormvineItems;
        }
        else if (item1.id == "murkysiltstriderplant" && item2.id == "brimstoneplant" ||
            item1.id == "brimstoneplant" && item2.id == "murkysiltstriderplant")
        {
            return murkySiltstriderBrimstoneItems;
        }
        else if (item1.id == "murkysiltstriderplant" && item2.id == "twilightfernplant" ||
            item1.id == "twilightfernplant" && item2.id == "murkysiltstriderplant")
        {
            return murkySiltstriderTwilightFernItems;
        }
        else if (item1.id == "murkysiltstriderplant" && item2.id == "aureateplant" ||
            item1.id == "aureateplant" && item2.id == "murkysiltstriderplant")
        {
            return murkySiltstriderAureateItems;
        }
        else if (item1.id == "murkysiltstriderplant" && item2.id == "boorishthymeplant" ||
            item1.id == "boorishthymeplant" && item2.id == "murkysiltstriderplant")
        {
            return murkySiltstriderBoorishThymeItems;
        }
        else if (item1.id == "murkysiltstriderplant" && item2.id == "brightflowerplant" ||
            item1.id == "brightflowerplant" && item2.id == "murkysiltstriderplant")
        {
            return murkySiltstriderBrightflowerItems;
        }
        else if (item1.id == "murkysiltstriderplant" && item2.id == "darkspinneretplant" ||
            item1.id == "darkspinneretplant" && item2.id == "murkysiltstriderplant")
        {
            return murkySiltstriderDarkspinneretItems;
        }
        else if (item1.id == "murkysiltstriderplant" && item2.id == "duskdendronplant" ||
            item1.id == "duskdendronplant" && item2.id == "murkysiltstriderplant")
        {
            return murkySiltstriderDuskDendronItems;
        }
        else if (item1.id == "murkysiltstriderplant" && item2.id == "harshsnapjawplant" ||
            item1.id == "harshsnapjawplant" && item2.id == "murkysiltstriderplant")
        {
            return murkySiltstriderHarshSnapjawItems;
        }
        else if (item1.id == "murkysiltstriderplant" && item2.id == "razorbackplant" ||
            item1.id == "razorbackplant" && item2.id == "murkysiltstriderplant")
        {
            return murkySiltstriderRazorbackItems;
        }
        else if (item1.id == "paleverrucaplant" && item2.id == "paleverrucaplant")
        {
            return paleVerrucaItems;
        }
        else if (item1.id == "paleverrucaplant" && item2.id == "dwarfsageplant" ||
            item1.id == "dwarfsageplant" && item2.id == "paleverrucaplant")
        {
            return paleVerrucaDwarfSageItems;
        }
        else if (item1.id == "paleverrucaplant" && item2.id == "lucidsprigplant" ||
            item1.id == "lucidsprigplant" && item2.id == "paleverrucaplant")
        {
            return paleVerrucaLucidSprigItems;
        }
        else if (item1.id == "paleverrucaplant" && item2.id == "cloudsprigplant" ||
            item1.id == "cloudsprigplant" && item2.id == "paleverrucaplant")
        {
            return paleVerrucaCloudSprigItems;
        }
        else if (item1.id == "paleverrucaplant" && item2.id == "grandtitianplant" ||
            item1.id == "grandtitianplant" && item2.id == "paleverrucaplant")
        {
            return paleVerrucaGrandTitianItems;
        }
        else if (item1.id == "paleverrucaplant" && item2.id == "ophidianeyeplant" ||
            item1.id == "ophidianeyeplant" && item2.id == "paleverrucaplant")
        {
            return paleVerrucaOphidianEyeItems;
        }
        else if (item1.id == "paleverrucaplant" && item2.id == "sunbloomplant" ||
            item1.id == "sunbloomplant" && item2.id == "paleverrucaplant")
        {
            return paleVerrucaSunbloomItems;
        }
        else if (item1.id == "paleverrucaplant" && item2.id == "bloodrootplant" ||
            item1.id == "bloodrootplant" && item2.id == "paleverrucaplant")
        {
            return paleVerrucaBloodrootItems;
        }
        else if (item1.id == "paleverrucaplant" && item2.id == "divineneedleplant" ||
            item1.id == "divineneedleplant" && item2.id == "paleverrucaplant")
        {
            return paleVerrucaDivineNeedleItems;
        }
        else if (item1.id == "paleverrucaplant" && item2.id == "heliotropeplant" ||
            item1.id == "heliotropeplant" && item2.id == "paleverrucaplant")
        {
            return paleVerrucaHeliotropeItems;
        }
        else if (item1.id == "paleverrucaplant" && item2.id == "stormvineplant" ||
            item1.id == "stormvineplant" && item2.id == "paleverrucaplant")
        {
            return paleVerrucaStormvineItems;
        }
        else if (item1.id == "paleverrucaplant" && item2.id == "brimstoneplant" ||
            item1.id == "brimstoneplant" && item2.id == "paleverrucaplant")
        {
            return paleVerrucaBrimstoneItems;
        }
        else if (item1.id == "paleverrucaplant" && item2.id == "twilightfernplant" ||
            item1.id == "twilightfernplant" && item2.id == "paleverrucaplant")
        {
            return paleVerrucaTwilightFernItems;
        }
        else if (item1.id == "paleverrucaplant" && item2.id == "aureateplant" ||
            item1.id == "aureateplant" && item2.id == "paleverrucaplant")
        {
            return paleVerrucaAureateItems;
        }
        else if (item1.id == "paleverrucaplant" && item2.id == "boorishthymeplant" ||
            item1.id == "boorishthymeplant" && item2.id == "paleverrucaplant")
        {
            return paleVerrucaBoorishThymeItems;
        }
        else if (item1.id == "paleverrucaplant" && item2.id == "brightflowerplant" ||
            item1.id == "brightflowerplant" && item2.id == "paleverrucaplant")
        {
            return paleVerrucaBrightflowerItems;
        }
        else if (item1.id == "paleverrucaplant" && item2.id == "darkspinneretplant" ||
            item1.id == "darkspinneretplant" && item2.id == "paleverrucaplant")
        {
            return paleVerrucaDarkspinneretItems;
        }
        else if (item1.id == "paleverrucaplant" && item2.id == "duskdendronplant" ||
            item1.id == "duskdendronplant" && item2.id == "paleverrucaplant")
        {
            return paleVerrucaDuskDendronItems;
        }
        else if (item1.id == "paleverrucaplant" && item2.id == "harshsnapjawplant" ||
            item1.id == "harshsnapjawplant" && item2.id == "paleverrucaplant")
        {
            return paleVerrucaHarshSnapjawItems;
        }
        else if (item1.id == "paleverrucaplant" && item2.id == "razorbackplant" ||
            item1.id == "razorbackplant" && item2.id == "paleverrucaplant")
        {
            return paleVerrucaRazorbackItems;
        }
        else if (item1.id == "paleverrucaplant" && item2.id == "murkysiltstriderplant" ||
            item1.id == "murkysiltstriderplant" && item2.id == "paleverrucaplant")
        {
            return paleVerrucaMurkySiltstriderItems;
        }
        else if (item1.id == "sanguinecloverplant" && item2.id == "sanguinecloverplant")
        {
            return sanguineCloverItems;
        }
        else if (item1.id == "sanguinecloverplant" && item2.id == "dwarfsageplant" ||
            item1.id == "dwarfsageplant" && item2.id == "sanguinecloverplant")
        {
            return sanguineCloverDwarfSageItems;
        }
        else if (item1.id == "sanguinecloverplant" && item2.id == "lucidsprigplant" ||
            item1.id == "lucidsprigplant" && item2.id == "sanguinecloverplant")
        {
            return sanguineCloverLucidSprigItems;
        }
        else if (item1.id == "sanguinecloverplant" && item2.id == "cloudsprigplant" ||
            item1.id == "cloudsprigplant" && item2.id == "sanguinecloverplant")
        {
            return sanguineCloverCloudSprigItems;
        }
        else if (item1.id == "sanguinecloverplant" && item2.id == "grandtitianplant" ||
            item1.id == "grandtitianplant" && item2.id == "sanguinecloverplant")
        {
            return sanguineCloverGrandTitianItems;
        }
        else if (item1.id == "sanguinecloverplant" && item2.id == "ophidianeyeplant" ||
            item1.id == "ophidianeyeplant" && item2.id == "sanguinecloverplant")
        {
            return sanguineCloverOphidianEyeItems;
        }
        else if (item1.id == "sanguinecloverplant" && item2.id == "sunbloomplant" ||
            item1.id == "sunbloomplant" && item2.id == "sanguinecloverplant")
        {
            return sanguineCloverSunbloomItems;
        }
        else if (item1.id == "sanguinecloverplant" && item2.id == "bloodrootplant" ||
            item1.id == "bloodrootplant" && item2.id == "sanguinecloverplant")
        {
            return sanguineCloverBloodrootItems;
        }
        else if (item1.id == "sanguinecloverplant" && item2.id == "divineneedleplant" ||
            item1.id == "divineneedleplant" && item2.id == "sanguinecloverplant")
        {
            return sanguineCloverDivineNeedleItems;
        }
        else if (item1.id == "sanguinecloverplant" && item2.id == "heliotropeplant" ||
            item1.id == "heliotropeplant" && item2.id == "sanguinecloverplant")
        {
            return sanguineCloverHeliotropeItems;
        }
        else if (item1.id == "sanguinecloverplant" && item2.id == "stormvineplant" ||
            item1.id == "stormvineplant" && item2.id == "sanguinecloverplant")
        {
            return sanguineCloverStormvineItems;
        }
        else if (item1.id == "sanguinecloverplant" && item2.id == "brimstoneplant" ||
            item1.id == "brimstoneplant" && item2.id == "sanguinecloverplant")
        {
            return sanguineCloverBrimstoneItems;
        }
        else if (item1.id == "sanguinecloverplant" && item2.id == "twilightfernplant" ||
            item1.id == "twilightfernplant" && item2.id == "sanguinecloverplant")
        {
            return sanguineCloverTwilightFernItems;
        }
        else if (item1.id == "sanguinecloverplant" && item2.id == "aureateplant" ||
            item1.id == "aureateplant" && item2.id == "sanguinecloverplant")
        {
            return sanguineCloverAureateItems;
        }
        else if (item1.id == "sanguinecloverplant" && item2.id == "boorishthymeplant" ||
            item1.id == "boorishthymeplant" && item2.id == "sanguinecloverplant")
        {
            return sanguineCloverBoorishThymeItems;
        }
        else if (item1.id == "sanguinecloverplant" && item2.id == "brightflowerplant" ||
            item1.id == "brightflowerplant" && item2.id == "sanguinecloverplant")
        {
            return sanguineCloverBrightflowerItems;
        }
        else if (item1.id == "sanguinecloverplant" && item2.id == "darkspinneretplant" ||
            item1.id == "darkspinneretplant" && item2.id == "sanguinecloverplant")
        {
            return sanguineCloverDarkspinneretItems;
        }
        else if (item1.id == "sanguinecloverplant" && item2.id == "duskdendronplant" ||
            item1.id == "duskdendronplant" && item2.id == "sanguinecloverplant")
        {
            return sanguineCloverDuskDendronItems;
        }
        else if (item1.id == "sanguinecloverplant" && item2.id == "harshsnapjawplant" ||
            item1.id == "harshsnapjawplant" && item2.id == "sanguinecloverplant")
        {
            return sanguineCloverHarshSnapjawItems;
        }
        else if (item1.id == "sanguinecloverplant" && item2.id == "razorbackplant" ||
            item1.id == "razorbackplant" && item2.id == "sanguinecloverplant")
        {
            return sanguineCloverRazorbackItems;
        }
        else if (item1.id == "sanguinecloverplant" && item2.id == "murkysiltstriderplant" ||
            item1.id == "murkysiltstriderplant" && item2.id == "sanguinecloverplant")
        {
            return sanguineCloverMurkySiltstriderItems;
        }
        else if (item1.id == "sanguinecloverplant" && item2.id == "paleverrucaplant" ||
            item1.id == "paleverrucaplant" && item2.id == "sanguinecloverplant")
        {
            return sanguineCloverPaleVerrucaItems;
        }
        else if (item1.id == "sunwornthistleplant" && item2.id == "sunwornthistleplant")
        {
            return sunwornThistleItems;
        }
        else if (item1.id == "sunwornthistleplant" && item2.id == "dwarfsageplant" ||
            item1.id == "dwarfsageplant" && item2.id == "sunwornthistleplant")
        {
            return sunwornThistleDwarfSageItems;
        }
        else if (item1.id == "sunwornthistleplant" && item2.id == "lucidsprigplant" ||
            item1.id == "lucidsprigplant" && item2.id == "sunwornthistleplant")
        {
            return sunwornThistleLucidSprigItems;
        }
        else if (item1.id == "sunwornthistleplant" && item2.id == "cloudsprigplant" ||
            item1.id == "cloudsprigplant" && item2.id == "sunwornthistleplant")
        {
            return sunwornThistleCloudSprigItems;
        }
        else if (item1.id == "sunwornthistleplant" && item2.id == "grandtitianplant" ||
            item1.id == "grandtitianplant" && item2.id == "sunwornthistleplant")
        {
            return sunwornThistleGrandTitianItems;
        }
        else if (item1.id == "sunwornthistleplant" && item2.id == "ophidianeyeplant" ||
            item1.id == "ophidianeyeplant" && item2.id == "sunwornthistleplant")
        {
            return sunwornThistleOphidianEyeItems;
        }
        else if (item1.id == "sunwornthistleplant" && item2.id == "sunbloomplant" ||
            item1.id == "sunbloomplant" && item2.id == "sunwornthistleplant")
        {
            return sunwornThistleSunbloomItems;
        }
        else if (item1.id == "sunwornthistleplant" && item2.id == "bloodrootplant" ||
            item1.id == "bloodrootplant" && item2.id == "sunwornthistleplant")
        {
            return sunwornThistleBloodrootItems;
        }
        else if (item1.id == "sunwornthistleplant" && item2.id == "divineneedleplant" ||
            item1.id == "divineneedleplant" && item2.id == "sunwornthistleplant")
        {
            return sunwornThistleDivineNeedleItems;
        }
        else if (item1.id == "sunwornthistleplant" && item2.id == "heliotropeplant" ||
            item1.id == "heliotropeplant" && item2.id == "sunwornthistleplant")
        {
            return sunwornThistleHeliotropeItems;
        }
        else if (item1.id == "sunwornthistleplant" && item2.id == "stormvineplant" ||
            item1.id == "stormvineplant" && item2.id == "sunwornthistleplant")
        {
            return sunwornThistleStormvineItems;
        }
        else if (item1.id == "sunwornthistleplant" && item2.id == "brimstoneplant" ||
            item1.id == "brimstoneplant" && item2.id == "sunwornthistleplant")
        {
            return sunwornThistleBrimstoneItems;
        }
        else if (item1.id == "sunwornthistleplant" && item2.id == "twilightfernplant" ||
            item1.id == "twilightfernplant" && item2.id == "sunwornthistleplant")
        {
            return sunwornThistleTwilightFernItems;
        }
        else if (item1.id == "sunwornthistleplant" && item2.id == "aureateplant" ||
            item1.id == "aureateplant" && item2.id == "sunwornthistleplant")
        {
            return sunwornThistleAureateItems;
        }
        else if (item1.id == "sunwornthistleplant" && item2.id == "boorishthymeplant" ||
            item1.id == "boorishthymeplant" && item2.id == "sunwornthistleplant")
        {
            return sunwornThistleBoorishThymeItems;
        }
        else if (item1.id == "sunwornthistleplant" && item2.id == "brightflowerplant" ||
            item1.id == "brightflowerplant" && item2.id == "sunwornthistleplant")
        {
            return sunwornThistleBrightflowerItems;
        }
        else if (item1.id == "sunwornthistleplant" && item2.id == "darkspinneretplant" ||
            item1.id == "darkspinneretplant" && item2.id == "sunwornthistleplant")
        {
            return sunwornThistleDarkspinneretItems;
        }
        else if (item1.id == "sunwornthistleplant" && item2.id == "duskdendronplant" ||
            item1.id == "duskdendronplant" && item2.id == "sunwornthistleplant")
        {
            return sunwornThistleDuskDendronItems;
        }
        else if (item1.id == "sunwornthistleplant" && item2.id == "harshsnapjawplant" ||
            item1.id == "harshsnapjawplant" && item2.id == "sunwornthistleplant")
        {
            return sunwornThistleHarshSnapjawItems;
        }
        else if (item1.id == "sunwornthistleplant" && item2.id == "razorbackplant" ||
            item1.id == "razorbackplant" && item2.id == "sunwornthistleplant")
        {
            return sunwornThistleRazorbackItems;
        }
        else if (item1.id == "sunwornthistleplant" && item2.id == "murkysiltstriderplant" ||
            item1.id == "murkysiltstriderplant" && item2.id == "sunwornthistleplant")
        {
            return sunwornThistleMurkySiltstriderItems;
        }
        else if (item1.id == "sunwornthistleplant" && item2.id == "paleverrucaplant" ||
            item1.id == "paleverrucaplant" && item2.id == "sunwornthistleplant")
        {
            return sunwornThistlePaleVerrucaItems;
        }
        else if (item1.id == "sunwornthistleplant" && item2.id == "sanguinecloverplant" ||
            item1.id == "sanguinecloverplant" && item2.id == "sunwornthistleplant")
        {
            return sunwornThistleSanguineCloverItems;
        }
        else if (item1.id == "thornedespritplant" && item2.id == "thornedespritplant")
        {
            return thornedEspritItems;
        }
        else if (item1.id == "thornedespritplant" && item2.id == "dwarfsageplant" ||
            item1.id == "dwarfsageplant" && item2.id == "thornedespritplant")
        {
            return thornedEspritDwarfSageItems;
        }
        else if (item1.id == "thornedespritplant" && item2.id == "lucidsprigplant" ||
            item1.id == "lucidsprigplant" && item2.id == "thornedespritplant")
        {
            return thornedEspritLucidSprigItems;
        }
        else if (item1.id == "thornedespritplant" && item2.id == "cloudsprigplant" ||
            item1.id == "cloudsprigplant" && item2.id == "thornedespritplant")
        {
            return thornedEspritCloudSprigItems;
        }
        else if (item1.id == "thornedespritplant" && item2.id == "grandtitianplant" ||
            item1.id == "grandtitianplant" && item2.id == "thornedespritplant")
        {
            return thornedEspritGrandTitianItems;
        }
        else if (item1.id == "thornedespritplant" && item2.id == "ophidianeyeplant" ||
            item1.id == "ophidianeyeplant" && item2.id == "thornedespritplant")
        {
            return thornedEspritOphidianEyeItems;
        }
        else if (item1.id == "thornedespritplant" && item2.id == "sunbloomplant" ||
            item1.id == "sunbloomplant" && item2.id == "thornedespritplant")
        {
            return thornedEspritSunbloomItems;
        }
        else if (item1.id == "thornedespritplant" && item2.id == "bloodrootplant" ||
            item1.id == "bloodrootplant" && item2.id == "thornedespritplant")
        {
            return thornedEspritBloodrootItems;
        }
        else if (item1.id == "thornedespritplant" && item2.id == "divineneedleplant" ||
            item1.id == "divineneedleplant" && item2.id == "thornedespritplant")
        {
            return thornedEspritDivineNeedleItems;
        }
        else if (item1.id == "thornedespritplant" && item2.id == "heliotropeplant" ||
            item1.id == "heliotropeplant" && item2.id == "thornedespritplant")
        {
            return thornedEspritHeliotropeItems;
        }
        else if (item1.id == "thornedespritplant" && item2.id == "stormvineplant" ||
            item1.id == "stormvineplant" && item2.id == "thornedespritplant")
        {
            return thornedEspritStormvineItems;
        }
        else if (item1.id == "thornedespritplant" && item2.id == "brimstoneplant" ||
            item1.id == "brimstoneplant" && item2.id == "thornedespritplant")
        {
            return thornedEspritBrimstoneItems;
        }
        else if (item1.id == "thornedespritplant" && item2.id == "twilightfernplant" ||
            item1.id == "twilightfernplant" && item2.id == "thornedespritplant")
        {
            return thornedEspritTwilightFernItems;
        }
        else if (item1.id == "thornedespritplant" && item2.id == "aureateplant" ||
            item1.id == "aureateplant" && item2.id == "thornedespritplant")
        {
            return thornedEspritAureateItems;
        }
        else if (item1.id == "thornedespritplant" && item2.id == "boorishthymeplant" ||
            item1.id == "boorishthymeplant" && item2.id == "thornedespritplant")
        {
            return thornedEspritBoorishThymeItems;
        }
        else if (item1.id == "thornedespritplant" && item2.id == "brightflowerplant" ||
            item1.id == "brightflowerplant" && item2.id == "thornedespritplant")
        {
            return thornedEspritBrightflowerItems;
        }
        else if (item1.id == "thornedespritplant" && item2.id == "darkspinneretplant" ||
            item1.id == "darkspinneretplant" && item2.id == "thornedespritplant")
        {
            return thornedEspritDarkspinneretItems;
        }
        else if (item1.id == "thornedespritplant" && item2.id == "duskdendronplant" ||
            item1.id == "duskdendronplant" && item2.id == "thornedespritplant")
        {
            return thornedEspritDuskDendronItems;
        }
        else if (item1.id == "thornedespritplant" && item2.id == "harshsnapjawplant" ||
            item1.id == "harshsnapjawplant" && item2.id == "thornedespritplant")
        {
            return thornedEspritHarshSnapjawItems;
        }
        else if (item1.id == "thornedespritplant" && item2.id == "razorbackplant" ||
            item1.id == "razorbackplant" && item2.id == "thornedespritplant")
        {
            return thornedEspritRazorbackItems;
        }
        else if (item1.id == "thornedespritplant" && item2.id == "murkysiltstriderplant" ||
            item1.id == "murkysiltstriderplant" && item2.id == "thornedespritplant")
        {
            return thornedEspritMurkySiltstriderItems;
        }
        else if (item1.id == "thornedespritplant" && item2.id == "paleverrucaplant" ||
            item1.id == "paleverrucaplant" && item2.id == "thornedespritplant")
        {
            return thornedEspritPaleVerrucaItems;
        }
        else if (item1.id == "thornedespritplant" && item2.id == "sanguinecloverplant" ||
            item1.id == "sanguinecloverplant" && item2.id == "thornedespritplant")
        {
            return thornedEspritSanguineCloverItems;
        }
        else if (item1.id == "thornedespritplant" && item2.id == "sunwornthistleplant" ||
            item1.id == "sunwornthistleplant" && item2.id == "thornedespritplant")
        {
            return thornedEspritSunwornThistleItems;
        }
        else if (item1.id == "waxylaurelplant" && item2.id == "waxylaurelplant")
        {
            return waxyLaurelItems;
        }
        else if (item1.id == "waxylaurelplant" && item2.id == "dwarfsageplant" ||
            item1.id == "dwarfsageplant" && item2.id == "waxylaurelplant")
        {
            return waxyLaurelDwarfSageItems;
        }
        else if (item1.id == "waxylaurelplant" && item2.id == "lucidsprigplant" ||
            item1.id == "lucidsprigplant" && item2.id == "waxylaurelplant")
        {
            return waxyLaurelLucidSprigItems;
        }
        else if (item1.id == "waxylaurelplant" && item2.id == "cloudsprigplant" ||
            item1.id == "cloudsprigplant" && item2.id == "waxylaurelplant")
        {
            return waxyLaurelCloudSprigItems;
        }
        else if (item1.id == "waxylaurelplant" && item2.id == "grandtitianplant" ||
            item1.id == "grandtitianplant" && item2.id == "waxylaurelplant")
        {
            return waxyLaurelGrandTitianItems;
        }
        else if (item1.id == "waxylaurelplant" && item2.id == "ophidianeyeplant" ||
            item1.id == "ophidianeyeplant" && item2.id == "waxylaurelplant")
        {
            return waxyLaurelOphidianEyeItems;
        }
        else if (item1.id == "waxylaurelplant" && item2.id == "sunbloomplant" ||
            item1.id == "sunbloomplant" && item2.id == "waxylaurelplant")
        {
            return waxyLaurelSunbloomItems;
        }
        else if (item1.id == "waxylaurelplant" && item2.id == "bloodrootplant" ||
            item1.id == "bloodrootplant" && item2.id == "waxylaurelplant")
        {
            return waxyLaurelBloodrootItems;
        }
        else if (item1.id == "waxylaurelplant" && item2.id == "divineneedleplant" ||
            item1.id == "divineneedleplant" && item2.id == "waxylaurelplant")
        {
            return waxyLaurelDivineNeedleItems;
        }
        else if (item1.id == "waxylaurelplant" && item2.id == "heliotropeplant" ||
            item1.id == "heliotropeplant" && item2.id == "waxylaurelplant")
        {
            return waxyLaurelHeliotropeItems;
        }
        else if (item1.id == "waxylaurelplant" && item2.id == "stormvineplant" ||
            item1.id == "stormvineplant" && item2.id == "waxylaurelplant")
        {
            return waxyLaurelStormvineItems;
        }
        else if (item1.id == "waxylaurelplant" && item2.id == "brimstoneplant" ||
            item1.id == "brimstoneplant" && item2.id == "waxylaurelplant")
        {
            return waxyLaurelBrimstoneItems;
        }
        else if (item1.id == "waxylaurelplant" && item2.id == "twilightfernplant" ||
            item1.id == "twilightfernplant" && item2.id == "waxylaurelplant")
        {
            return waxyLaurelTwilightFernItems;
        }
        else if (item1.id == "waxylaurelplant" && item2.id == "aureateplant" ||
            item1.id == "aureateplant" && item2.id == "waxylaurelplant")
        {
            return waxyLaurelAureateItems;
        }
        else if (item1.id == "waxylaurelplant" && item2.id == "boorishthymeplant" ||
            item1.id == "boorishthymeplant" && item2.id == "waxylaurelplant")
        {
            return waxyLaurelBoorishThymeItems;
        }
        else if (item1.id == "waxylaurelplant" && item2.id == "brightflowerplant" ||
            item1.id == "brightflowerplant" && item2.id == "waxylaurelplant")
        {
            return waxyLaurelBrightflowerItems;
        }
        else if (item1.id == "waxylaurelplant" && item2.id == "darkspinneretplant" ||
            item1.id == "darkspinneretplant" && item2.id == "waxylaurelplant")
        {
            return waxyLaurelDarkspinneretItems;
        }
        else if (item1.id == "waxylaurelplant" && item2.id == "duskdendronplant" ||
            item1.id == "duskdendronplant" && item2.id == "waxylaurelplant")
        {
            return waxyLaurelDuskDendronItems;
        }
        else if (item1.id == "waxylaurelplant" && item2.id == "harshsnapjawplant" ||
            item1.id == "harshsnapjawplant" && item2.id == "waxylaurelplant")
        {
            return waxyLaurelHarshSnapjawItems;
        }
        else if (item1.id == "waxylaurelplant" && item2.id == "razorbackplant" ||
            item1.id == "razorbackplant" && item2.id == "waxylaurelplant")
        {
            return waxyLaurelRazorbackItems;
        }
        else if (item1.id == "waxylaurelplant" && item2.id == "murkysiltstriderplant" ||
            item1.id == "murkysiltstriderplant" && item2.id == "waxylaurelplant")
        {
            return waxyLaurelMurkySiltstriderItems;
        }
        else if (item1.id == "waxylaurelplant" && item2.id == "paleverrucaplant" ||
            item1.id == "paleverrucaplant" && item2.id == "waxylaurelplant")
        {
            return waxyLaurelPaleVerrucaItems;
        }
        else if (item1.id == "waxylaurelplant" && item2.id == "sanguinecloverplant" ||
            item1.id == "sanguinecloverplant" && item2.id == "waxylaurelplant")
        {
            return waxyLaurelSanguineCloverItems;
        }
        else if (item1.id == "waxylaurelplant" && item2.id == "sunwornthistleplant" ||
            item1.id == "sunwornthistleplant" && item2.id == "waxylaurelplant")
        {
            return waxyLaurelSunwornThistleItems;
        }
        else if (item1.id == "waxylaurelplant" && item2.id == "thornedespritplant" ||
            item1.id == "thornedespritplant" && item2.id == "waxylaurelplant")
        {
            return waxyLaurelThornedEspritItems;
        } 
        return new List<Item>();
    }
}

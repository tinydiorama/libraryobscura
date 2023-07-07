using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarData : MonoBehaviour
{
    [Header("Glowwart and Glowwart")]
    public List<Item> glowWartItems;
    [Header("Glowwart and Sagemint")]
    public List<Item> glowWartSagemintItems;
    [Header("Sagemint and Sagemint")]
    public List<Item> sagemintItems;

    public List<Item> getSacrificeItems(Item item1, Item item2)
    {
        if ( item1.id == "glowwart" && item2.id == "glowwart" )
        {
            return glowWartItems;
        } else if (item1.id == "glowwart" && item2.id == "sagemint")
        {
            return glowWartSagemintItems;
        }
        else if (item1.id == "sagemint" && item2.id == "sagemint")
        {
            return sagemintItems;
        }
        return new List<Item>();
    }
}

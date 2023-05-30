using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuySellButton : MonoBehaviour
{
    public Item item;
    [SerializeField] public Image icon;
    [SerializeField] public TextMeshProUGUI itemName;
    [SerializeField] public TextMeshProUGUI count;
    [SerializeField] public TextMeshProUGUI cost;
}

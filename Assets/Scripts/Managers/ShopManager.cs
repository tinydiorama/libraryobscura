using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] public List<Item> shopItems;
    
    public static ShopManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("more than one shop manager");
        }
        instance = this;
    }

}

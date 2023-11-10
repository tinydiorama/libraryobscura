using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItemsManager : MonoBehaviour
{
    [SerializeField] private List<InteractableItem> itemsToCheck;
    public static InteractableItemsManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("more than one interactableItems manager");
        }
        instance = this;
    }

    public void resetItems()
    {
        foreach (InteractableItem item in itemsToCheck)
        {
            item.resetContainsItem();
        }
    }
}

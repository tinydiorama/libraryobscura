using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AltarUI : MonoBehaviour
{
    [Header("Altar Intro")]
    [SerializeField] private GameObject introTextContainer;
    [SerializeField] private TextMeshProUGUI introText1;
    [SerializeField] private TextMeshProUGUI introText2;

    [SerializeField] private GameObject cannotUseAltarPanel;

    [Header("Altar Sacrifice")]
    [SerializeField] private GameObject altarPanel;
    [SerializeField] private AltarItem item1;
    [SerializeField] private AltarItem item2;
    [SerializeField] private Button item1ButtonUp;
    [SerializeField] private Button item1ButtonDown;
    [SerializeField] private Button item2ButtonUp;
    [SerializeField] private Button item2ButtonDown;

    [Header("Altar GET")]
    [SerializeField] private GameObject altarGetPanel;
    [SerializeField] private GameObject altarItemList;
    [SerializeField] private GameObject altarItemPrefab;

    private TextMeshProUGUI text;
    private TextMeshProUGUI text2;

    [SerializeField] private AltarData altarData;

    public void showIntroMessage()
    {
        GameManager.GetInstance().isPaused = true;
        introTextContainer.SetActive(true);
        text = introText1.GetComponent<TextMeshProUGUI>();
        var color = text.color;
        var fadeincolor = color;
        fadeincolor.a = 1;
        LeanTween.value(introText1.gameObject, updateColorValueCallback, color, fadeincolor, 5f).setEase(LeanTweenType.easeInOutSine);
        text2 = introText2.GetComponent<TextMeshProUGUI>();
        LeanTween.value(introText2.gameObject, updateColorValueCallback2, color, fadeincolor, 5f).setEase(LeanTweenType.easeInOutSine).setDelay(1f);

        StartCoroutine(fadeOutText());
    }

    private IEnumerator fadeOutText()
    {
        yield return new WaitForSeconds(5f);
        var color = text.color;
        var fadeoutcolor = color;
        fadeoutcolor.a = 0;
        LeanTween.value(introText1.gameObject, updateColorValueCallback, color, fadeoutcolor, 5f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.value(introText2.gameObject, updateColorValueCallback2, color, fadeoutcolor, 5f).setEase(LeanTweenType.easeInOutSine).setOnComplete(() =>
        {
            introTextContainer.SetActive(true);
            StoryManager.instance.seenAltar = true;
            showAltar();
        });
    }

    public void showAltar()
    {
        InventoryManager inv = InventoryManager.instance;
        GameManager.GetInstance().isPaused = true;
        if ( inv.numItemsForSacrifice() < 2 ) // need 2 or more
        {
            cannotUseAltar();
        } else
        {
            altarPanel.SetActive(true);
            setupItems();
        }
    }

    public void setupItems()
    {
        InventoryManager inv = InventoryManager.instance;
        int count = 0;
        bool item1set = false;
        foreach( ItemSlot slot in inv.items )
        {
            if ( slot.item.canBeSacrificed ) // get the first item that can be sacrificed
            {
                if ( ! item1set )
                {
                    item1.altarItem = slot.item;
                    item1.itemImage.sprite = slot.item.icon;
                    item1.altarIndex = count;
                    item1set = true;
                    if (slot.count > 1)
                    {
                        item2.altarItem = slot.item;
                        item2.itemImage.sprite = slot.item.icon;
                        item2.altarIndex = count;
                        return;
                    }
                } else
                {
                    item2.altarItem = slot.item;
                    item2.itemImage.sprite = slot.item.icon;
                    item2.altarIndex = count;
                    return;
                }
            }
            count++;
        }
    }

    public void increaseItem(AltarItem itemToChange)
    {
        InventoryManager inv = InventoryManager.instance;
        while (true)
        {
            itemToChange.altarIndex++;
            if (itemToChange.altarIndex >= inv.items.Count)
            {
                itemToChange.altarIndex = 0;
            }
            if (inv.items[itemToChange.altarIndex].item.canBeSacrificed) // ensure the item can be sacrificed
            {
                // if my item is the same as the other item, there needs to be at least 2 to display it
                if ( itemToChange.otherAlterItem.altarItem.id == inv.items[itemToChange.altarIndex].item.id &&
                    inv.items[itemToChange.altarIndex].count >= 2)
                {
                    itemToChange.altarItem = inv.items[itemToChange.altarIndex].item;
                    itemToChange.itemImage.sprite = itemToChange.altarItem.icon;
                    itemToChange.itemText.text = itemToChange.altarItem.itemName;
                    break;
                } else if (itemToChange.otherAlterItem.altarItem.id != inv.items[itemToChange.altarIndex].item.id)
                {
                    itemToChange.altarItem = inv.items[itemToChange.altarIndex].item;
                    itemToChange.itemImage.sprite = itemToChange.altarItem.icon;
                    itemToChange.itemText.text = itemToChange.altarItem.itemName;
                    break;
                }
            }
        }
    }
    public void decrease(AltarItem itemToChange)
    {
        InventoryManager inv = InventoryManager.instance;
        while (true)
        {
            itemToChange.altarIndex--;
            if (itemToChange.altarIndex < 0)
            {
                itemToChange.altarIndex = inv.items.Count - 1;
            }
            if (inv.items[itemToChange.altarIndex].item.canBeSacrificed) // ensure the item can be sacrificed
            {
                // if my item is the same as the other item, there needs to be at least 2 to display it
                if (itemToChange.otherAlterItem.altarItem.id == inv.items[itemToChange.altarIndex].item.id &&
                    inv.items[itemToChange.altarIndex].count >= 2)
                {
                    itemToChange.altarItem = inv.items[itemToChange.altarIndex].item;
                    itemToChange.itemImage.sprite = itemToChange.altarItem.icon;
                    itemToChange.itemText.text = itemToChange.altarItem.itemName;
                    break;
                } else if (itemToChange.otherAlterItem.altarItem.id != inv.items[itemToChange.altarIndex].item.id)
                {
                    itemToChange.altarItem = inv.items[itemToChange.altarIndex].item;
                    itemToChange.itemImage.sprite = itemToChange.altarItem.icon;
                    itemToChange.itemText.text = itemToChange.altarItem.itemName;
                    break;
                }
            }
        }
    }

    public void makeTheSacrifice()
    {
        foreach (Transform child in altarItemList.transform)
        {
            Destroy(child.gameObject);
        }
        altarPanel.SetActive(false);
        // animation
        altarGetPanel.SetActive(true);
        InventoryManager inv = InventoryManager.instance;
        List<Item> itemsToGet = altarData.getSacrificeItems(item1.altarItem, item2.altarItem);
        inv.removeItem(item1.altarItem);
        inv.removeItem(item2.altarItem);
        foreach ( Item item in itemsToGet )
        {
            GameObject tempObj = Instantiate(altarItemPrefab, altarItemList.transform);
            tempObj.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = item.itemName;
            tempObj.transform.GetChild(1).GetComponent<Image>().sprite = item.icon;
            inv.addItem(item);
        }
    }

    public void closeGetSacrificeItems()
    {
        altarGetPanel.SetActive(false);
        GameManager.GetInstance().isPaused = false;
    }


    public void closeAltar()
    {
        GameManager.GetInstance().isPaused = false;
        altarPanel.SetActive(false);
    }

    public void cannotUseAltar()
    {
        GameManager.GetInstance().isPaused = true;
        cannotUseAltarPanel.SetActive(true);
    }

    public void closeCannotUse()
    {
        GameManager.GetInstance().isPaused = false;
        cannotUseAltarPanel.SetActive(false);
    }

    private void updateColorValueCallback(Color val)
    {
        text.color = val;
    }
    private void updateColorValueCallback2(Color val)
    {
        text2.color = val;
    }
}

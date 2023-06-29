using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuySellUI : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private GameObject cantAffordUI;
    [SerializeField] private GameObject buySellScrollContents;
    [SerializeField] private GameObject confirmPanel;
    [SerializeField] private GameObject thanksPanel;
    [SerializeField] private GameObject buyTab;
    [SerializeField] private GameObject sellTab;
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI thanksText;
    [SerializeField] private TextMeshProUGUI emptyText;

    [Header("Tab Settings")]
    [SerializeField] private Color activeColor;
    [SerializeField] private Color inactiveColor;
    [SerializeField] private Sprite activeSprite;

    [Header("Buy Sell Info")]
    [SerializeField] private GameObject buySellItemPrefab;

    [Header("Confirm Item")]
    [SerializeField] private TMP_InputField quantityInput;
    [SerializeField] private TextMeshProUGUI confirmButtonText;

    private int activePriceCheck;
    private Item activeItem;
    private int activeQuantity;
    private bool isBuying;
    private int numCanSell;

    public void showShop() // buy tab
    {
        gameObject.SetActive(true);
        GameManager gm = GameManager.GetInstance();
        gm.isPaused = true;
        InventoryManager inv = InventoryManager.instance;
        cantAffordUI.SetActive(false);
        title.text = "Order Catalogue";

        buyTab.GetComponent<Image>().color = activeColor;
        buyTab.GetComponent<Image>().sprite = activeSprite;
        sellTab.GetComponent<Image>().color = inactiveColor;
        sellTab.GetComponent<Image>().sprite = null;

        foreach (Transform child in buySellScrollContents.transform)
        {
            if (child.name != "NoThings")
            {
                Destroy(child.gameObject);
            }
        }
        if (ShopManager.instance.shopItems.Count > 0)
        {
            emptyText.gameObject.SetActive(false);
        }
        else
        {
            emptyText.gameObject.SetActive(true);
            emptyText.text = "You have no letters.";
        }
        foreach (Item shopItem in ShopManager.instance.shopItems)
        {
            GameObject buySellObject = Instantiate(buySellItemPrefab, buySellScrollContents.transform);
            BuySellItem buySellItem = buySellObject.GetComponent<BuySellItem>();
            buySellItem.item = shopItem;
            buySellItem.icon.sprite = shopItem.icon;
            buySellItem.itemName.text = shopItem.itemName;
            buySellItem.cost.text = shopItem.buyPrice.ToString();
            for (int i = 0; i < inv.items.Count; i++)
            {
                if (inv.items[i].item.id == shopItem.id)
                {
                    buySellItem.count.text = inv.items[i].count.ToString();
                    break;
                }
            }
            buySellItem.GetComponent<Button>().onClick.AddListener(delegate { buyItem(ref buySellItem); });
        }
        if (StoryManager.instance.sellAllowed)
        {
            sellTab.SetActive(true);
        }
        else
        {
            sellTab.SetActive(false);
        }
    }
    public void showSellTab() // sell tab
    {
        GameManager gm = GameManager.GetInstance();
        InventoryManager inventory = InventoryManager.instance;
        title.text = "Ship Items";

        sellTab.GetComponent<Image>().color = activeColor;
        sellTab.GetComponent<Image>().sprite = activeSprite;
        buyTab.GetComponent<Image>().color = inactiveColor;
        buyTab.GetComponent<Image>().sprite = null;

        foreach (Transform child in buySellScrollContents.transform)
        {
            if (child.name != "NoThings")
            {
                Destroy(child.gameObject);
            }
        }
        
        int numSellableItems = 0;
        foreach (ItemSlot itemSlot in inventory.items)
        {
            if ( itemSlot.item.sellable )
            {
                GameObject buySellObject = Instantiate(buySellItemPrefab, buySellScrollContents.transform);
                BuySellItem buySellItem = buySellObject.GetComponent<BuySellItem>();
                buySellItem.icon.sprite = itemSlot.item.icon;
                buySellItem.itemName.text = itemSlot.item.itemName;
                buySellItem.cost.text = itemSlot.item.sellPrice.ToString();
                buySellItem.count.text = itemSlot.count.ToString();
                ItemSlot tempItem = itemSlot;
                buySellItem.GetComponent<Button>().onClick.AddListener(delegate { sellItem(ref tempItem); });
                numSellableItems++;
            }
        }
        if (numSellableItems > 0)
        {
            emptyText.gameObject.SetActive(false);
        }
        else
        {
            emptyText.gameObject.SetActive(true);
            emptyText.text = "You have nothing to sell.";
        }
    }

    public void buyItem(ref BuySellItem buySellItem)
    {
        GameManager gm = GameManager.GetInstance();
        if (buySellItem.item.buyPrice <= InventoryManager.instance.money)
        {
            activePriceCheck = buySellItem.item.buyPrice;
            activeItem = buySellItem.item;
            activeQuantity = 1;
            quantityInput.text = activeQuantity.ToString();
            confirmPanel.SetActive(true);
            confirmButtonText.text = "Order for " + activePriceCheck.ToString();
            isBuying = true;
        }
        else
        {
            cantAffordUI.SetActive(true);
        }
    }
    public void sellItem(ref ItemSlot itemSlot)
    {
        activePriceCheck = itemSlot.item.sellPrice;
        activeItem = itemSlot.item;
        activeQuantity = 1;
        numCanSell = itemSlot.count;
        quantityInput.text = activeQuantity.ToString();
        confirmPanel.SetActive(true);
        confirmButtonText.text = "Sell for " + activePriceCheck.ToString();
        isBuying = false;
    }
    public void increaseQuantity()
    {
        GameManager gm = GameManager.GetInstance();
        if (isBuying) // buying
        {
            if ((activeQuantity + 1) * activePriceCheck <= InventoryManager.instance.money)
            {
                activeQuantity++;
            }
            confirmButtonText.text = "Order for " + (activePriceCheck * activeQuantity).ToString();
        }
        else // selling
        {
            if ((activeQuantity + 1) <= numCanSell)
            {
                activeQuantity++;
            }
            confirmButtonText.text = "Sell for " + (activePriceCheck * activeQuantity).ToString();
        }
        quantityInput.text = activeQuantity.ToString();
    }

    public void decreaseQuantity()
    {
        GameManager gm = GameManager.GetInstance();
        activeQuantity--;
        if (activeQuantity < 1)
        {
            activeQuantity = 1;
        }
        if (isBuying) // buying
        {
            confirmButtonText.text = "Order for " + (activePriceCheck * activeQuantity).ToString();
        }
        else // selling
        {
            confirmButtonText.text = "Sell for " + (activePriceCheck * activeQuantity).ToString();
        }
        quantityInput.text = activeQuantity.ToString();
    }

    public void confirmBuy()
    {
        GameManager gm = GameManager.GetInstance();
        InventoryManager inv = InventoryManager.instance;
        confirmPanel.SetActive(false);
        if (isBuying) // buying
        {
            inv.money -= activePriceCheck * activeQuantity;
            inv.moneySpentToday = activePriceCheck * activeQuantity;
            inv.addToOrder(activeItem, activeQuantity);
            thanksText.text = "Thank you for your order. You will receive it tomorrow.";
            thanksPanel.SetActive(true);
            showShop();
        }
        else
        {
            inv.numItemsSoldToday += activeQuantity;
            inv.numItemsSoldAllTime += activeQuantity;
            inv.moneyEarnedToday += activePriceCheck * activeQuantity;
            inv.addToSold(activeItem, activeQuantity);
            inv.removeItem(activeItem, activeQuantity);
            thanksText.text = "Thank you for shipping. We have collected the items and will send payment soon.";
            thanksPanel.SetActive(true);
            showSellTab();
        }
    }

    public void closeBuySell()
    {
        gameObject.SetActive(false);
        GameManager.GetInstance().isPaused = false;
    }
    public void cancelBuy()
    {
        confirmPanel.SetActive(false);
    }

    public void closeCantAfford()
    {
        cantAffordUI.SetActive(false);
    }
    public void closeThanks()
    {
        thanksPanel.SetActive(false);
    }
}

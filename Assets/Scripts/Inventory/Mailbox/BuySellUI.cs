using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuySellUI : MonoBehaviour
{
    [SerializeField] private GameObject notifications;
    [SerializeField] private GameObject buySellButtonPrefab;
    [SerializeField] private GameObject buySellButtonPanel;
    [SerializeField] private TextMeshProUGUI tabTitle;
    [SerializeField] private GameObject buyButton;
    [SerializeField] private GameObject sellButton;
    [SerializeField] private Color activeColor;
    [SerializeField] private Color inactiveColor;
    [SerializeField] private GameObject confirmWindow;
    [SerializeField] private GameObject thanksWindow;
    [SerializeField] private TextMeshProUGUI thanksText;
    [SerializeField] private GameObject cantBuyWindow;
    [SerializeField] private TMP_InputField quantityInput;
    [SerializeField] private TextMeshProUGUI buyButtonText;

    private GameManager gm;
    private int activePriceCheck;
    private Item activeItem;
    private int currentQuantity;
    private int numToSell;
    private bool buyingSelling; // true for buying, false for selling

    private void Start()
    {
        gm = GameManager.GetInstance();
    }

    public void showShop() // buy tab
    {
        gm = GameManager.GetInstance();
        cantBuyWindow.SetActive(false);
        tabTitle.text = "Order Catalogue";
        buyButton.GetComponent<Image>().color = activeColor;
        sellButton.GetComponent<Image>().color = inactiveColor;
        foreach (Transform child in buySellButtonPanel.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Item shopItem in gm.shopManager.shopItems)
        {
            GameObject buySellItem = Instantiate(buySellButtonPrefab, buySellButtonPanel.transform);
            BuySellButton buySellButton = buySellItem.GetComponent<BuySellButton>();
            buySellButton.item = shopItem;
            buySellButton.icon.sprite = shopItem.icon;
            buySellButton.itemName.text = shopItem.itemName;
            buySellButton.cost.text = shopItem.buyPrice.ToString();
            for ( int i = 0; i < gm.inventoryManager.items.Count; i++)
            {
                if (gm.inventoryManager.items[i].item.id == shopItem.id )
                {
                    buySellButton.count.text = gm.inventoryManager.items[i].count.ToString();
                    break;
                }
            }
            buySellButton.GetComponent<Button>().onClick.AddListener(delegate { buyItem(ref buySellButton); });
        }
        if (gm.cutsceneManager.sellAllowed)
        {
            sellButton.SetActive(true);
        } else
        {
            sellButton.SetActive(false);
        }
    }

    public void showSellTab() // sell tab
    {
        gm = GameManager.GetInstance();
        InventoryManager inventory = gm.inventoryManager;
        tabTitle.text = "Ship Items";
        sellButton.GetComponent<Image>().color = activeColor;
        buyButton.GetComponent<Image>().color = inactiveColor;
        foreach (Transform child in buySellButtonPanel.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (ItemSlot itemSlot in inventory.items)
        {
            GameObject buySellItem = Instantiate(buySellButtonPrefab, buySellButtonPanel.transform);
            BuySellButton buySellButton = buySellItem.GetComponent<BuySellButton>();
            buySellButton.icon.sprite = itemSlot.item.icon;
            buySellButton.itemName.text = itemSlot.item.itemName;
            buySellButton.cost.text = itemSlot.item.sellPrice.ToString();
            buySellButton.count.text = itemSlot.count.ToString();
            ItemSlot tempItem = itemSlot;
            buySellButton.GetComponent<Button>().onClick.AddListener(delegate { sellItem(ref tempItem); });
        }
    }

    public void buyItem( ref BuySellButton buySellButton)
    {
        gm = GameManager.GetInstance();
        if ( buySellButton.item.buyPrice <= gm.inventoryManager.money )
        {
            activePriceCheck = buySellButton.item.buyPrice;
            activeItem = buySellButton.item;
            currentQuantity = 1;
            quantityInput.text = currentQuantity.ToString();
            confirmWindow.SetActive(true);
            buyButtonText.text = "Order for " + activePriceCheck.ToString();
            buyingSelling = true;
        } else
        {
            cantBuyWindow.SetActive(true);
        }
    }

    public void sellItem(ref ItemSlot itemSlot)
    {
        activePriceCheck = itemSlot.item.sellPrice;
        activeItem = itemSlot.item;
        currentQuantity = 1;
        numToSell = itemSlot.count;
        quantityInput.text = currentQuantity.ToString();
        confirmWindow.SetActive(true);
        buyButtonText.text = "Sell for " + activePriceCheck.ToString();
        buyingSelling = false;
    }

    public void increaseQuantity()
    {
        gm = GameManager.GetInstance();
        if ( buyingSelling ) // buying
        {
            if ((currentQuantity + 1) * activePriceCheck <= gm.inventoryManager.money)
            {
                currentQuantity++;
            }
            buyButtonText.text = "Order for " + (activePriceCheck * currentQuantity).ToString();
        } else // selling
        {
            if ( (currentQuantity + 1) <= numToSell )
            {
                currentQuantity++;
            }
            buyButtonText.text = "Sell for " + (activePriceCheck * currentQuantity).ToString();
        }
        quantityInput.text = currentQuantity.ToString();
    }

    public void decreaseQuantity()
    {
        gm = GameManager.GetInstance();
        currentQuantity--;
        if (currentQuantity < 1)
        {
            currentQuantity = 1;
        }
        if (buyingSelling) // buying
        {
            buyButtonText.text = "Order for " + (activePriceCheck * currentQuantity).ToString();
        }
        else // selling
        {
            buyButtonText.text = "Sell for " + (activePriceCheck * currentQuantity).ToString();
        }
        quantityInput.text = currentQuantity.ToString();
    }

    public void cancelBuy()
    {
        confirmWindow.SetActive(false);
    }

    public void confirmBuy()
    {
        gm = GameManager.GetInstance();
        confirmWindow.SetActive(false);
        if ( buyingSelling ) // buying
        {
            gm.inventoryManager.money -= activePriceCheck * currentQuantity;
            gm.moneySpentToday = activePriceCheck * currentQuantity;
            gm.inventoryManager.addToOrder(activeItem, currentQuantity);
            thanksText.text = "Thank you for your order. You will receive it tomorrow.";
            thanksWindow.SetActive(true);
            showShop();
        } else
        {
            gm.soldToday = gm.soldToday + currentQuantity;
            gm.moneyEarnedToday += activePriceCheck * currentQuantity;
            gm.inventoryManager.removeItem(activeItem, currentQuantity);
            thanksText.text = "Thank you for shipping. We have collected the items and will send payment soon.";
            thanksWindow.SetActive(true);
            showSellTab();
        }
    }

    public void closeBuySell()
    {
        notifications.SetActive(false);
        gameObject.SetActive(false);
        gm.isPaused = false;
        gm.pauseShown = false;
    }
    
    public void closeCantBuy()
    {
        cantBuyWindow.SetActive(false);
    }

    public void closeThanks()
    {
        thanksWindow.SetActive(false);
    }
}

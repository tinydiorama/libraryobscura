using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[Serializable]
public class ItemSlot
{
    public Item item;
    public int count;
    public ItemSlot(Item itemToAdd, int countToAdd)
    {
        item = itemToAdd;
        count = countToAdd;
    }
}

[Serializable]
public class LetterSlot
{
    public Letter letter;
    public bool newLetter;

    public LetterSlot(Letter letterToAdd, bool isNew)
    {
        letter = letterToAdd;
        newLetter = isNew;
    }
}

[Serializable]
public class BookSlot
{
    public Book book;
    public bool newBook;

    public BookSlot(Book bookToAdd, bool isNew)
    {
        book = bookToAdd;
        newBook = isNew;
    }
}

public class InventoryManager : MonoBehaviour, iDataPersistence
{
    [SerializeField] public int money;
    [Header("HUD")]
    [SerializeField] private GameObject moneyObject;
    [SerializeField] private TextMeshProUGUI moneyText;
    [Header("Data")]
    [SerializeField] public List<LetterSlot> letters;
    [SerializeField] public List<Letter> letterDatabase;
    [SerializeField] public List<BookSlot> books;
    [SerializeField] public List<Book> booksDatabase;
    [SerializeField] public List<ItemSlot> items;
    [SerializeField] public List<Item> itemsDatabase;
    [SerializeField] public List<ItemSlot> itemsOrdered;
    [SerializeField] public List<ItemSlot> itemsSold;
    [Header("Buy Sell Information")]
    [SerializeField] public int moneySpentToday;
    [SerializeField] public int moneyEarnedToday;
    [SerializeField] public int numItemsSoldToday;
    [SerializeField] public int numItemsSoldAllTime;
    [SerializeField] private GameObject package;

    [SerializeField] private InventoryUI inventoryUI;
    public static InventoryManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("more than one inventory manager");
        }
        instance = this;
    }
    private void Start()
    {
        GameManager.GetInstance().onEndOfDay += processSaleData;
        GameManager.GetInstance().onStartNewDay += resetSaleData;
    }

    private void processSaleData()
    {
        StoryManager sm = StoryManager.instance;
        Package pckg = package.GetComponent<Package>();
        if ( itemsOrdered.Count > 0)
        {
            package.SetActive(true);
            foreach( ItemSlot slot in itemsOrdered )
            {
                pckg.itemsObtained.Add(new ItemSlot(slot.item, slot.count));
            }
            GameManager.GetInstance().showPackageInfo = true;
        }
        itemsOrdered.Clear();
        // sale data
        money += moneyEarnedToday;
        // setup books for # of items sold
        List<BookSlot> saleBooksGiven = sm.nightCheckBook();
        List<ItemSlot> saleItemGiven = sm.nightCheckItem();

        // process sale rewards
        if ( saleBooksGiven.Count > 0 || saleItemGiven.Count > 0 )
        {
            package.SetActive(true);
            if ( pckg.itemsObtained.Count > 0 )
            {
                for (int i = 0; i < saleItemGiven.Count; i++)
                {
                    pckg.itemsObtained.Add(saleItemGiven[i]); // add sale obtained items to bought items
                }
            } else
            {
                pckg.itemsObtained = saleItemGiven; // set items obtained straight up to sale items
            }

            pckg.booksObtained = saleBooksGiven;
        }
    }

    private void resetSaleData()
    {
        //hasPackageAtDoor = false;
        itemsOrdered.Clear();
        itemsSold.Clear();
        moneyEarnedToday = 0;
        moneySpentToday = 0;
        numItemsSoldToday = 0;
    }

    private void Update()
    {
        moneyText.text = money.ToString();
    }

    public void openInventory()
    {
        inventoryUI.showInventory();
    }

    public void closeInventory()
    {
        inventoryUI.hideInventory();
    }

    public void showMoneyHUD()
    {
        moneyObject.SetActive(true);
    }

    public bool containsLetter(string id)
    {
        foreach( LetterSlot slot in letters )
        {
            if ( slot.letter.id == id )
            {
                return true;
            }
        }
        return false;
    }
    public void addLetter(Letter letterToAdd)
    {
        letters.Add(new LetterSlot(letterToAdd, true));
    }

    public void addBook(Book bookToAdd)
    {
        books.Add(new BookSlot(bookToAdd, true));
    }

    public void addLetter(Letter letterToAdd, bool isNew)
    {
        letters.Add(new LetterSlot(letterToAdd, isNew));
    }

    public void addToOrder(Item itemToAdd, int count)
    {
        itemsOrdered.Add(new ItemSlot(itemToAdd, count));
    }
    public void addToSold(Item itemToAdd, int count)
    {
        itemsSold.Add(new ItemSlot(itemToAdd, count));
    }

    public void addItem(Item itemToAdd)
    {
        addItem(itemToAdd, 1);
    }

    public void addItem(Item itemToAdd, int count)
    {
        bool found = false;
        foreach (ItemSlot slot in items)
        {
            if (slot.item.id == itemToAdd.id) // same item, increase count
            {
                slot.count = slot.count + count;
                found = true;
            }
        }
        if ( ! found )
        {
            // could not find the item, so just add it
            items.Add(new ItemSlot(itemToAdd, count));
        }
    }

    public bool removeItem(Item itemToRemove)
    {
        return removeItem(itemToRemove, 1);
    }
    public bool removeItem(Item itemToRemove, int count)
    {
        int index = 0;
        foreach (ItemSlot slot in items) // why didn't I just use a for loop? why didn't YO MOMMA just use a for loop
        {
            if (slot.item.id == itemToRemove.id) // found item
            {
                // need to check if we can remove the count
                if ( count < slot.count ) // can just decrement count
                {
                    slot.count = slot.count - count;
                    return true;
                } else if ( count == slot.count ) // remove entire item
                {
                    items.RemoveAt(index);
                    return true;
                } else // can't remove
                {
                    return false;
                }
            }
            index++;
        }
        return false;
    }

    public int numSold(string itemId)
    {
        foreach (ItemSlot slot in itemsSold)
        {
            if ( slot.item.id == itemId)
            {
                return slot.count;
            }
        }
        return -1;
    }

    public int numItemsForSacrifice()
    {
        int numItems = 0;
        foreach (ItemSlot slot in items)
        {
            if ( slot.item.canBeSacrificed )
            {
                numItems = numItems + slot.count;
            }
        }
        return numItems;
    }

    public void LoadData(GameData data)
    {
        foreach (Letter dbLetter in letterDatabase)
        {
            if (data.letters.ContainsKey(dbLetter.id))
            {
                bool isNew;
                data.letters.TryGetValue(dbLetter.id, out isNew);
                letters.Add(new LetterSlot(dbLetter, isNew));
            }
        }
        foreach (Book dbBook in booksDatabase)
        {
            if (data.books.ContainsKey(dbBook.id))
            {
                bool isNew;
                data.books.TryGetValue(dbBook.id, out isNew);
                books.Add(new BookSlot(dbBook, isNew));
            }
        }
        foreach (Item dbItem in itemsDatabase)
        {
            if (data.items.ContainsKey(dbItem.id))
            {
                int count;
                data.items.TryGetValue(dbItem.id, out count);
                items.Add(new ItemSlot(dbItem, count));
            }
            if ( data.saleItems.ContainsKey(dbItem.id))
            {
                int count;
                data.saleItems.TryGetValue(dbItem.id, out count);
                itemsSold.Add(new ItemSlot(dbItem, count));
            }
        }
        this.money = data.money;
        this.numItemsSoldAllTime = data.numItemsSoldAllTime;
    }

    public void SaveData(ref GameData data)
    {
        foreach (LetterSlot slot in letters)
        {
            if (data.letters.ContainsKey(slot.letter.id))
            {
                data.letters.Remove(slot.letter.id);
            }
            data.letters.Add(slot.letter.id, slot.newLetter);
        }
        if (letters.Count == 0)
        {
            data.letters.Clear();
        }
        foreach (BookSlot slot in books)
        {
            if (data.books.ContainsKey(slot.book.id))
            {
                data.books.Remove(slot.book.id);
            }
            data.books.Add(slot.book.id, slot.newBook);
        }
        if (books.Count == 0)
        {
            data.books.Clear();
        }
        foreach (ItemSlot slot in items)
        {
            if (data.items.ContainsKey(slot.item.id))
            {
                data.items.Remove(slot.item.id);
            }
            data.items.Add(slot.item.id, slot.count);
        }
        if (items.Count == 0)
        {
            data.items.Clear();
        }
        foreach (ItemSlot slot in itemsSold)
        {
            if (data.saleItems.ContainsKey(slot.item.id))
            {
                data.saleItems.Remove(slot.item.id);
            }
            data.saleItems.Add(slot.item.id, slot.count);
        }
        if (itemsSold.Count == 0)
        {
            data.saleItems.Clear();
        }
        data.money = this.money;
        data.numItemsSoldAllTime = this.numItemsSoldAllTime;
    }
}

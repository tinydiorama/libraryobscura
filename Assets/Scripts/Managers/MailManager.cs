using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailManager : MonoBehaviour, iDataPersistence
{
    public bool hasNewMail;
    public bool showAlert;
    public List<Letter> newLetters;
    public List<Book> newBooks;
    public List<Item> newItems;
    public static MailManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void addNewLetter(Letter letterToAdd)
    {
        if ( ! newLetters.Contains(letterToAdd) )
        {
            newLetters.Add(letterToAdd);
        }
    }
    public void addNewBook(Book bookToAdd)
    {
        if (!newBooks.Contains(bookToAdd))
        {
            newBooks.Add(bookToAdd);
        }
    }

    public void clearLetters()
    {
        newLetters.Clear();
    }
    public void clearBooks()
    {
        newBooks.Clear();
    }
    public void clearItems()
    {
        newItems.Clear();
    }

    public void LoadData(GameData data)
    {
        GameManager gm = GameManager.GetInstance();

        if (StoryManager.instance.mailboxInteract1)
        {
            newLetters.Clear();
            newBooks.Clear();
            newItems.Clear();
        }

        InventoryManager inv = InventoryManager.instance;
        foreach (Letter dbLetter in inv.letterDatabase)
        {
            if (data.mailboxLetters.Contains(dbLetter.id))
            {
                newLetters.Add(dbLetter);
            }
        }
        foreach (Book dbBook in inv.booksDatabase)
        {
            if (data.mailboxBooks.Contains(dbBook.id))
            {
                newBooks.Add(dbBook);
            }
        }
        foreach (string itemId in data.mailboxItems)
        {
            foreach (Item dbItem in inv.itemsDatabase)
            {
                if (itemId == dbItem.id)
                {
                    newItems.Add(dbItem);
                }
            }
        }
        this.hasNewMail = data.hasNewMail;
    }

    public void SaveData(ref GameData data)
    {
        GameManager gm = GameManager.GetInstance();

        // clear existing mail
        data.hasNewMail = hasNewMail;
        data.mailboxLetters.Clear();
        data.mailboxBooks.Clear();
        data.mailboxItems.Clear();
        foreach (Letter dbLetter in newLetters)
        {
            data.mailboxLetters.Add(dbLetter.id);
        }
        foreach (Book dbBook in newBooks)
        {
            data.mailboxBooks.Add(dbBook.id);
        }
        foreach (Item dbItem in newItems)
        {
            data.mailboxItems.Add(dbItem.id);
        }
    }
}

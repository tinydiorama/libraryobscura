using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEditor.Progress;

public class MailManager : MonoBehaviour, iDataPersistence
{
    public bool hasNewMail;
    public List<Letter> newLetters;
    public List<Book> newBooks;
    public List<Item> newItems;

    public void addNewLetter(Letter letterToAdd)
    {
        newLetters.Add(letterToAdd);
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

        if ( gm.cutsceneManager.mailboxInteract1 )
        {
            hasNewMail = data.hasNewMail;
            newLetters.Clear();
            newBooks.Clear();
            newItems.Clear();
        }

        foreach (Letter dbLetter in gm.inventoryManager.letterDatabase)
        {
            if (data.mailboxLetters.Contains(dbLetter.id))
            {
                newLetters.Add(dbLetter);
            }
        }
        foreach (Book dbBook in gm.inventoryManager.booksDatabase)
        {
            if (data.mailboxBooks.Contains(dbBook.id))
            {
                newBooks.Add(dbBook);
            }
        }
        foreach(string itemId in data.mailboxItems)
        {
            foreach (Item dbItem in gm.inventoryManager.itemsDatabase)
            {
                if ( itemId == dbItem.id )
                {
                    newItems.Add(dbItem);
                }
            }
        }
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

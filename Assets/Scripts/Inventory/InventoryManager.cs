using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour, iDataPersistence
{
    [SerializeField] public List<LetterSlot> letters;
    [SerializeField] public List<Letter> letterDatabase;
    [SerializeField] public List<BookSlot> books;
    [SerializeField] public List<Book> booksDatabase;
    [SerializeField] public List<ItemSlot> items;
    [SerializeField] public List<Item> itemsOrdered;
    [SerializeField] public List<Item> itemsDatabase;
    public int money;

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
        for ( int i = 0; i < count; i++ )
        {
            itemsOrdered.Add(itemToAdd);
        }
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
        }
        this.money = data.money;
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
        data.money = this.money;
    }
}

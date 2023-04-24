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
    [SerializeField] public List<Item> itemsDatabase;

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
        foreach (BookSlot slot in books)
        {
            if (data.books.ContainsKey(slot.book.id))
            {
                data.books.Remove(slot.book.id);
            }
            data.books.Add(slot.book.id, slot.newBook);
        }
        foreach (ItemSlot slot in items)
        {
            if (data.items.ContainsKey(slot.item.id))
            {
                data.items.Remove(slot.item.id);
            }
            data.items.Add(slot.item.id, slot.count);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailManager : MonoBehaviour
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
}

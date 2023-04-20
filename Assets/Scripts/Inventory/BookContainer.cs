using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
public class BookContainer : MonoBehaviour
{
    [SerializeField] private Inventory inventoryPanel;
    [SerializeField] private GameObject bookPanel;
    [SerializeField] private GameObject bookPrefab;
    [SerializeField] private GameObject bookCloseup;
    [SerializeField] private TextMeshProUGUI bookBodyText1;
    [SerializeField] private TextMeshProUGUI bookBodyText2;

    private GameManager gm;
    private void Start()
    {
        gm = GameManager.GetInstance();
    }

    public void ShowBooks()
    {
        foreach (Transform child in bookPanel.transform)
        {
            Destroy(child.gameObject);
        }
        if (gm == null)
        {
            gm = GameManager.GetInstance();
        }
        for (int i = 0; i < gm.books.Count; i++)
        {
            GameObject bookInstance = Instantiate(bookPrefab, bookPanel.transform);
            bookInstance.GetComponent<BookUI>().bookTitleAuthor.text = gm.books[i].book.title + " by " + gm.books[i].book.author;
            if (gm.books[i].newBook)
            {
                bookInstance.GetComponent<BookUI>().newIcon.SetActive(true);
            }
            else
            {
                bookInstance.GetComponent<BookUI>().newIcon.SetActive(false);
            }
            BookSlot tempBook = gm.books[i];
            bookInstance.GetComponent<Button>().onClick.AddListener(delegate { showBookCloseup(ref tempBook); });
        }
    }

    public void showBookCloseup(ref BookSlot bookToShow)
    {
        bookToShow.newBook = false;
        inventoryPanel.hidePanels();
        bookBodyText1.text = bookToShow.book.page1;
        bookBodyText2.text = bookToShow.book.page2;
        bookCloseup.SetActive(true);
    }

    public void closeBookCloseup()
    {
        bookCloseup.SetActive(false);
        inventoryPanel.showBooksPanel();
    }

    public void addBook(Book bookToAdd)
    {
        if (gm == null)
        {
            gm = GameManager.GetInstance();
        }
        gm.books.Add(new BookSlot(bookToAdd, true));
    }
}

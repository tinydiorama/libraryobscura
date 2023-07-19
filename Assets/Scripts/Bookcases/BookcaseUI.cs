using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BookcaseUI : MonoBehaviour
{
    [Header("Book Select Fields")]
    [SerializeField] private GameObject bookSelectPanel;
    [SerializeField] private GameObject bookSelectList;
    [SerializeField] private GameObject noThings;
    [SerializeField] private GameObject bookSelectPrefab;

    [Header("Book Read Fields")]
    [SerializeField] private GameObject bookReadPanel;
    [SerializeField] private GameObject bookReadList;

    [Header("Book Closeup Fields")]
    [SerializeField] private TextMeshProUGUI bookBodyText1;
    [SerializeField] private TextMeshProUGUI bookBodyText2;
    [SerializeField] private GameObject bookCloseup;


    public void showBookSelectUI()
    {
        bookSelectPanel.SetActive(true);

        foreach (Transform child in bookSelectList.transform)
        {
            if (child.name != "NoThings")
            {
                Destroy(child.gameObject);
            }
        }
        GameManager gm = GameManager.GetInstance();
        InventoryManager invManage = InventoryManager.instance;
        if (invManage.books.Count > 0)
        {
            noThings.SetActive(false);
        }
        else
        {
            noThings.SetActive(true);
        }
        for (int i = 0; i < invManage.books.Count; i++)
        {
            GameObject bookInstance = Instantiate(bookSelectPrefab, bookSelectList.transform);
            bookInstance.GetComponent<BookUI>().bookTitle.text = invManage.books[i].book.title;
            bookInstance.GetComponent<BookUI>().bookAuthor.text = "by " + invManage.books[i].book.author;
            if (invManage.books[i].newBook)
            {
                bookInstance.GetComponent<BookUI>().newIcon.SetActive(true);
            }
            else
            {
                bookInstance.GetComponent<BookUI>().newIcon.SetActive(false);
            }
            BookSlot tempBook = invManage.books[i];
            // TODO what happens when selecting a book
        }
    }

    public void closeBookSelectUI()
    {
        bookSelectPanel.SetActive(false);
    }

    public void showBookReadUI()
    {
        // TODO show books that can be read at this bookshelf
        //bookInstance.GetComponent<Button>().onClick.AddListener(delegate { showBookCloseup(ref tempBook); });
        bookReadPanel.SetActive(true);
    }
    public void closeBookReadUI()
    {
        bookReadPanel.SetActive(false);
    }

    public void showBookCloseup(ref BookSlot bookToShow)
    {
        bookToShow.newBook = false;
        closeBookReadUI();
        bookBodyText1.text = bookToShow.book.page1;
        bookBodyText2.text = bookToShow.book.page2;
        bookCloseup.SetActive(true);
    }

    public void closeBookCloseup()
    {
        bookCloseup.SetActive(false);
        showBookReadUI();
    }
}

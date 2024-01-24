using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BookcaseUI : MonoBehaviour
{
    [SerializeField] private GameObject overlay;

    [Header("Book Select Fields")]
    [SerializeField] private GameObject bookSelectPanel;
    [SerializeField] private GameObject bookSelectList;
    [SerializeField] private GameObject noThings;
    [SerializeField] private GameObject bookSelectPrefab;

    [Header("Book Read Fields")]
    [SerializeField] private GameObject bookReadPanel;
    [SerializeField] private GameObject bookReadList;
    [SerializeField] private GameObject noBooksToRead;

    [Header("Book Closeup Fields")]
    [SerializeField] private Image bookCover;
    [SerializeField] private Image bookBodyText1;
    [SerializeField] private TextMeshProUGUI bookBodyText2;
    [SerializeField] private GameObject bookCloseup;

    private List<Book> referenceBooks;
    private List<Book> currentBooksToRead;
    public BookSlot selectedBook;
    public GameObject referenceObject;

    private bool showingBookSelect;
    private bool showingBooktoRead;

    private void Update()
    {
        if ( showingBookSelect )
        {
            if (InputManager.GetInstance().GetConfirmPressed())
            {
                placeBook();
            } else if ( InputManager.GetInstance().GetClosePressed() )
            {
                closeBookSelectUI();
            }
        } else if ( showingBooktoRead )
        {
            if (InputManager.GetInstance().GetClosePressed())
            {
                closeBookReadUI();
            }
        }
    }

    public void showBookSelectUI(GameObject refObj)
    {
        GameManager.GetInstance().isPaused = true;
        referenceObject = refObj;
        overlay.SetActive(true);
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

            // TODO: bookInstance doesn't have a bookUI on it yet
            bookInstance.GetComponent<BookUI>().bookTitle.text = invManage.books[i].book.title;
            bookInstance.GetComponent<BookUI>().bookAuthor.text = "by " + invManage.books[i].book.author;
            BookSlot tempBook = invManage.books[i];
            bookInstance.GetComponent<Button>().onClick.AddListener(delegate
            {
                selectBook(ref tempBook);
            });
            if ( i == 0 ) // select first book
            {
                selectBook(ref tempBook);
                EventSystem.current.SetSelectedGameObject(bookInstance);
            }
        }
        StartCoroutine(enableShowBookSelect());
    }
    private IEnumerator enableShowBookSelect()
    {
        yield return new WaitForSeconds(0.2f);
        showingBookSelect = true;
    }
    private IEnumerator disableShowBookSelect()
    {
        yield return new WaitForSeconds(0.2f);
        showingBookSelect = false;
    }

    public void selectBook(ref BookSlot bookToPlace)
    {
        selectedBook = bookToPlace;
    }

    public void placeBook()
    {
        selectedBook.placement = referenceObject.GetComponent<Bookcase>().bookcasePlacementText;
        referenceObject.GetComponent<Bookcase>().books.Add(selectedBook.book);
        closeBookSelectUI();
        StartCoroutine(disableShowBookSelect());
        showBookReadUI(referenceObject.GetComponent<Bookcase>().books);
    }

    public void closeBookSelectUI()
    {
        GameManager.GetInstance().isPaused = false;
        overlay.SetActive(false);
        bookSelectPanel.SetActive(false);
        StartCoroutine(disableShowBookSelect());
    }

    public void showBookReadUI( List<Book> booksToRead )
    {
        GameManager.GetInstance().isPaused = true;
        overlay.SetActive(true);
        currentBooksToRead = booksToRead;
        foreach (Transform child in bookReadList.transform)
        {
            if (child.name != "NoThings")
            {
                Destroy(child.gameObject);
            }
        }
        if ( currentBooksToRead.Count > 0 )
        {
            noBooksToRead.SetActive(false);
        } else
        {
            noBooksToRead.SetActive(true);
        }
        for (int i = 0; i < currentBooksToRead.Count; i++)
        {
            GameObject bookInstance = Instantiate(bookSelectPrefab, bookReadList.transform);
            bookInstance.GetComponent<BookUI>().bookTitle.text = currentBooksToRead[i].title;
            bookInstance.GetComponent<BookUI>().bookAuthor.text = "by " + currentBooksToRead[i].author;
            Book tempBook = currentBooksToRead[i];
            bookInstance.GetComponent<Button>().onClick.AddListener(delegate
            {
                showBookCloseup(ref tempBook);
            });
        }
        StartCoroutine(enableShowBookReadUI());
        bookReadPanel.SetActive(true);
    }
    public void closeBookReadUI()
    {
        GameManager.GetInstance().isPaused = false;
        overlay.SetActive(false);
        bookReadPanel.SetActive(false);
        StartCoroutine(disableShowBookReadUI());
    }
    private IEnumerator enableShowBookReadUI()
    {
        yield return new WaitForSeconds(0.2f);
        showingBooktoRead = true;
    }
    private IEnumerator disableShowBookReadUI()
    {
        yield return new WaitForSeconds(0.2f);
        showingBooktoRead = false;
    }

    public void showBookCloseup(ref Book bookToShow)
    {
        closeBookReadUI();
        GameManager.GetInstance().isPaused = true;
        overlay.SetActive(true);
        bookCover.color = bookToShow.bookColor;
        bookBodyText1.sprite = bookToShow.page1;
        bookBodyText2.text = bookToShow.page2;
        bookCloseup.SetActive(true);
    }

    public void closeBookCloseup()
    {
        GameManager.GetInstance().isPaused = false;
        overlay.SetActive(false);
        bookCloseup.SetActive(false);
        showBookReadUI(currentBooksToRead);
    }
}

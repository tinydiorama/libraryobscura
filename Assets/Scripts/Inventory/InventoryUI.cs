using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject panelContents;
    [SerializeField] private GameObject lettersButton;
    [SerializeField] private GameObject booksButton;
    [SerializeField] private GameObject itemsButton;
    [SerializeField] private GameObject buttonsContainer;
    [SerializeField] private Color activeColor;
    [SerializeField] private Color inactiveColor;

    [Header("Prefabs")]
    [SerializeField] private GameObject lettersPrefab;
    [SerializeField] private GameObject booksPrefab;
    [SerializeField] private GameObject itemsPrefab;

    [Header("Book Fields")]
    [SerializeField] private TextMeshProUGUI bookBodyText1;
    [SerializeField] private TextMeshProUGUI bookBodyText2;
    [SerializeField] private GameObject bookCloseup;

    [Header("Letter Fields")]
    [SerializeField] private GameObject lettersCloseup;

    [Header("First Encounter")]
    [SerializeField] private MailboxUI mailboxUI;

    public void showInventory()
    {
        gameObject.SetActive(true);
        inventoryInitialize();
    }
    public void hideInventory()
    {
        gameObject.SetActive(false);
    }

    public void inventoryInitialize()
    {
        showLettersPanel();
    }

    public void hidePanels()
    {
        panel.SetActive(false);
        lettersCloseup.SetActive(false);
        buttonsContainer.SetActive(false);
    }

    public void showLettersPanel()
    {
        panel.SetActive(true);
        lettersCloseup.SetActive(false);
        buttonsContainer.SetActive(true);

        lettersButton.GetComponent<Image>().color = activeColor;
        booksButton.GetComponent<Image>().color = inactiveColor;
        itemsButton.GetComponent<Image>().color = inactiveColor;
        showLetters();
    }
    public void showBooksPanel()
    {
        panel.SetActive(true);
        lettersCloseup.SetActive(false);
        buttonsContainer.SetActive(true);

        lettersButton.GetComponent<Image>().color = inactiveColor;
        booksButton.GetComponent<Image>().color = activeColor;
        itemsButton.GetComponent<Image>().color = inactiveColor;
        showBooks();
    }
    public void showSeedsPanel()
    {
        panel.SetActive(true);
        lettersCloseup.SetActive(false);
        buttonsContainer.SetActive(true);

        lettersButton.GetComponent<Image>().color = inactiveColor;
        booksButton.GetComponent<Image>().color = inactiveColor;
        itemsButton.GetComponent<Image>().color = activeColor;
        showItems();
    }

    public void showLetterCloseup(ref LetterSlot letterToShow)
    {
        if (letterToShow.letter.id == "letter2")
        {
            StoryManager.instance.buyAllowed = true;
            InventoryManager.instance.showMoneyHUD();
            InventoryManager.instance.money = 20;
        }

        letterToShow.newLetter = false;
        hidePanels();
        lettersCloseup.SetActive(true);

        lettersCloseup.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = letterToShow.letter.body;
    }

    public void showBookCloseup(ref BookSlot bookToShow)
    {
        bookToShow.newBook = false;
        hidePanels();
        bookBodyText1.text = bookToShow.book.page1;
        bookBodyText2.text = bookToShow.book.page2;
        bookCloseup.SetActive(true);
    }

    public void closeBookCloseup()
    {
        bookCloseup.SetActive(false);
        showBooksPanel();
    }

    public void closeLetterCloseup()
    {
        GameManager gm = GameManager.GetInstance();
        StoryManager sm = StoryManager.instance;
        MailManager mm = MailManager.instance;
        InventoryManager inv = InventoryManager.instance;

        // for the first mailbox interaction
        if (! sm.mailboxInteract1)
        {
            sm.mailboxInteract1 = true;
            lettersCloseup.SetActive(false);
            for (int i = 0; i < mm.newLetters.Count; i++)
            {
                inv.addLetter(mm.newLetters[i]);
            }
            mm.clearLetters();

            mailboxUI.showReceivedMail();
        }
        else
        {
            lettersCloseup.SetActive(false);
            showLettersPanel();
        }
    }

    private void showLetters()
    {
        foreach (Transform child in panelContents.transform)
        {
            Destroy(child.gameObject);
        }
        GameManager gm = GameManager.GetInstance();
        InventoryManager invManage = InventoryManager.instance;
        for (int i = 0; i < invManage.letters.Count; i++)
        {
            GameObject letterInstance = Instantiate(lettersPrefab, panelContents.transform);
            letterInstance.GetComponent<LetterUI>().letterSubject.text = invManage.letters[i].letter.subject;
            if (invManage.letters[i].newLetter)
            {
                letterInstance.GetComponent<LetterUI>().newIcon.SetActive(true);
            }
            else
            {
                letterInstance.GetComponent<LetterUI>().newIcon.SetActive(false);
            }
            LetterSlot tempLetter = invManage.letters[i];
            letterInstance.GetComponent<Button>().onClick.AddListener(delegate { showLetterCloseup(ref tempLetter); });
        }
    }

    private void showBooks()
    {
        foreach (Transform child in panelContents.transform)
        {
            Destroy(child.gameObject);
        }
        GameManager gm = GameManager.GetInstance();
        InventoryManager invManage = InventoryManager.instance;
        for (int i = 0; i < invManage.books.Count; i++)
        {
            GameObject bookInstance = Instantiate(booksPrefab, panelContents.transform);
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
            bookInstance.GetComponent<Button>().onClick.AddListener(delegate { showBookCloseup(ref tempBook); });
        }
    }

    private void showItems()
    {
        foreach (Transform child in panelContents.transform)
        {
            Destroy(child.gameObject);
        }
        GameManager gm = GameManager.GetInstance();
        InventoryManager invManage = InventoryManager.instance;
        for (int i = 0; i < invManage.items.Count; i++)
        {
            GameObject itemInstance = Instantiate(itemsPrefab, panelContents.transform);
            itemInstance.GetComponent<ItemUI>().itemName.text = invManage.items[i].item.itemName;
            itemInstance.GetComponent<ItemUI>().count.text = invManage.items[i].count.ToString();
            itemInstance.GetComponent<ItemUI>().icon.sprite = invManage.items[i].item.icon;
        }
    }
}

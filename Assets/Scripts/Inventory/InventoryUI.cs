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
    [SerializeField] private TextMeshProUGUI noThingsText;
    [SerializeField] private Color activeColor;
    [SerializeField] private Color inactiveColor;
    [SerializeField] private Sprite activeSprite;

    [Header("Prefabs")]
    [SerializeField] private GameObject lettersPrefab;
    [SerializeField] private GameObject booksPrefab;
    [SerializeField] private GameObject itemsPrefab;

    [Header("Letter Fields")]
    [SerializeField] private GameObject lettersCloseup;
    [SerializeField] private GameObject lettersCloseupImageGray;
    [SerializeField] private GameObject lettersCloseupImageTan;

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
        lettersButton.GetComponent<Image>().sprite = activeSprite;
        booksButton.GetComponent<Image>().sprite = null;
        itemsButton.GetComponent<Image>().sprite = null;
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
        lettersButton.GetComponent<Image>().sprite = null;
        booksButton.GetComponent<Image>().sprite = activeSprite;
        itemsButton.GetComponent<Image>().sprite = null;
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
        lettersButton.GetComponent<Image>().sprite = null;
        booksButton.GetComponent<Image>().sprite = null;
        itemsButton.GetComponent<Image>().sprite = activeSprite;
        showItems();
    }

    public void showLetterCloseup(ref LetterSlot letterToShow)
    {
        if (letterToShow.letter.id == "letter2")
        {
            StoryManager.instance.buyAllowed = true;
            StoryManager.instance.sellAllowed = true;
            InventoryManager.instance.showMoneyHUD();
            InventoryManager.instance.money = 20;
        }

        letterToShow.newLetter = false;
        hidePanels();
        if ( letterToShow.letter.letterBGtan )
        {
            lettersCloseupImageTan.SetActive(true);
            lettersCloseupImageGray.SetActive(false);
        } else
        {
            lettersCloseupImageTan.SetActive(false);
            lettersCloseupImageGray.SetActive(true);
        }
        lettersCloseup.SetActive(true);

        lettersCloseup.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = letterToShow.letter.body;
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
            hideInventory();
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
            if (child.name != "NoThings")
            {
                Destroy(child.gameObject);
            }
        }
        GameManager gm = GameManager.GetInstance();
        InventoryManager invManage = InventoryManager.instance;
        if (invManage.letters.Count > 0 )
        {
            noThingsText.gameObject.SetActive(false);
        } else
        {
            noThingsText.gameObject.SetActive(true);
            noThingsText.text = "You have no letters.";
        }
        for (int i = invManage.letters.Count - 1; i >= 0; i--) // showing the letters in reverse order
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
            if (child.name != "NoThings")
            {
                Destroy(child.gameObject);
            }
        }
        GameManager gm = GameManager.GetInstance();
        InventoryManager invManage = InventoryManager.instance;
        if (invManage.books.Count > 0)
        {
            noThingsText.gameObject.SetActive(false);
        }
        else
        {
            noThingsText.gameObject.SetActive(true);
            noThingsText.text = "You have no books.";
        }
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
            //bookInstance.GetComponent<Button>().onClick.AddListener(delegate { showBookCloseup(ref tempBook); });
        }
    }

    private void showItems()
    {
        foreach (Transform child in panelContents.transform)
        {
            if (child.name != "NoThings")
            {
                Destroy(child.gameObject);
            }
        }
        GameManager gm = GameManager.GetInstance();
        InventoryManager invManage = InventoryManager.instance;
        if (invManage.items.Count > 0)
        {
            noThingsText.gameObject.SetActive(false);
        }
        else
        {
            noThingsText.gameObject.SetActive(true);
            noThingsText.text = "You have no items.";
        }
        for (int i = 0; i < invManage.items.Count; i++)
        {
            GameObject itemInstance = Instantiate(itemsPrefab, panelContents.transform);
            itemInstance.GetComponent<ItemUI>().itemName.text = invManage.items[i].item.itemName;
            itemInstance.GetComponent<ItemUI>().count.text = invManage.items[i].count.ToString();
            itemInstance.GetComponent<ItemUI>().icon.sprite = invManage.items[i].item.icon;
        }
    }
}

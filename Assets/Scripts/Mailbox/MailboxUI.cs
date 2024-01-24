using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UI;

public class MailboxUI : MonoBehaviour 
{
    [SerializeField] private GameObject receivedMailPanel;
    [SerializeField] private GameObject newLetterPrefab;
    [SerializeField] private GameObject newBookPrefab;
    [SerializeField] private GameObject newItemPrefab;

    private GameManager gm;

    private void Update()
    {
        if (InputManager.GetInstance().GetConfirmPressed())
        {
            getReceivedMail();
        }
    }

    public void showReceivedMail()
    {
        gm = GameManager.GetInstance();
        gameObject.SetActive(true);
        gm.isPaused = true;

        MailManager manager = MailManager.instance;
        // New Letters
        for (int i = 0; i < manager.newLetters.Count; i++)
        {
            GameObject newLetterInstance = Instantiate(newLetterPrefab, receivedMailPanel.transform);
            newLetterInstance.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = manager.newLetters[i].subject;
        }
        // New Books
        for (int i = 0; i < manager.newBooks.Count; i++)
        {
            GameObject newBookInstance = Instantiate(newBookPrefab, receivedMailPanel.transform);
            newBookInstance.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = manager.newBooks[i].title;
        }
        // New Items
        for (int i = 0; i < manager.newItems.Count; i++)
        {
            GameObject newLetterInstance = Instantiate(newLetterPrefab, receivedMailPanel.transform);
            newLetterInstance.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = manager.newItems[i].itemName;
            newLetterInstance.transform.GetChild(1).GetComponent<Image>().sprite = manager.newItems[i].icon;
        }

        manager.hasNewMail = false;
    }

    public void getReceivedMail()
    {
        gm = GameManager.GetInstance();
        MailManager manager = MailManager.instance;
        InventoryManager inv = InventoryManager.instance;
        foreach (Transform child in receivedMailPanel.transform)
        {
            Destroy(child.gameObject);
        }
        for (int i = 0; i < manager.newLetters.Count; i++)
        {
            inv.addLetter(manager.newLetters[i]);
        }
        for (int i = 0; i < manager.newBooks.Count; i++)
        {
            inv.addBook(manager.newBooks[i]);
        }
        for (int i = 0; i < manager.newItems.Count; i++)
        {
            inv.addItem(manager.newItems[i]);
        }
        manager.clearLetters();
        manager.clearBooks();
        manager.clearItems();
        manager.hasNewMail = false;
        gm.isPaused = false;

        gameObject.SetActive(false);
    }
}

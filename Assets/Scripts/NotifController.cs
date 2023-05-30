using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotifController : MonoBehaviour
{
    [SerializeField] private BuySellUI buySell;
    [SerializeField] private GameObject notifications;
    [SerializeField] private GameObject notifContainer;
    [SerializeField] private GameObject noNotif;
    [SerializeField] private GameObject notifContentPanel;
    [SerializeField] private TextMeshProUGUI closeText;
    [SerializeField] private GameObject newLetterPrefab;
    [SerializeField] private GameObject newBookPrefab;
    [SerializeField] private GameObject newItemPrefab;
    [SerializeField] private LetterContainer letterContainer;

    private GameManager gm;

    private void Start()
    {
        gm = GameManager.GetInstance();
    }
    public void showNotifications()
    {
        if (gm.mailManager.hasNewMail)
        {
            MailManager manager = gm.mailManager;
            noNotif.SetActive(false);
            for (int i = 0; i < manager.newLetters.Count; i++)
            {
                GameObject newLetterInstance = Instantiate(newLetterPrefab, notifContentPanel.transform);
                newLetterInstance.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = manager.newLetters[i].subject;
            }
            for (int i = 0; i < manager.newBooks.Count; i++)
            {
                GameObject newLetterInstance = Instantiate(newLetterPrefab, notifContentPanel.transform);
                newLetterInstance.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = manager.newBooks[i].title;
            }
            for (int i = 0; i < manager.newItems.Count; i++)
            {
                GameObject newLetterInstance = Instantiate(newLetterPrefab, notifContentPanel.transform);
                newLetterInstance.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = manager.newItems[i].itemName;
                newLetterInstance.transform.GetChild(1).GetComponent<Image>().sprite = manager.newItems[i].icon;
            }
            closeText.text = "Get all";
            manager.hasNewMail = false;
            notifContainer.SetActive(true);
        }
        else
        {
            // show buy sell window
            /*noNotif.SetActive(true);
            closeText.text = "Close";*/
            buySell.gameObject.SetActive(true);
            buySell.showShop();
        }
        notifications.SetActive(true);
    }

    public void closeMailNotif()
    {
        notifications.SetActive(false);
        notifContainer.SetActive(false);
        for (int i = 0; i < gm.mailManager.newLetters.Count; i++)
        {
            gm.inventoryManager.addLetter(gm.mailManager.newLetters[i]);
        }
        for ( int i = 0; i < gm.mailManager.newItems.Count; i++ )
        {
            gm.inventoryManager.addItem(gm.mailManager.newItems[i]);
        }
        gm.mailManager.clearLetters();
        gm.mailManager.hasNewMail = false;
        gm.isPaused = false;
        gm.pauseShown = false;
    }
}

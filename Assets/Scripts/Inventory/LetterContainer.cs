using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class LetterSlot
{
    public Letter letter;
    public bool newLetter;

    public LetterSlot(Letter letterToAdd, bool isNew)
    {
        letter = letterToAdd;
        newLetter = isNew;
    }
}
public class LetterContainer : MonoBehaviour
{
    [SerializeField] private Inventory inventoryPanel;
    [SerializeField] private GameObject letterPanel;
    [SerializeField] private GameObject letterPrefab;
    [SerializeField] private GameObject letterCloseup;
    [SerializeField] private TextMeshProUGUI letterBodyText;

    [SerializeField] private NotifController notifController;

    private GameManager gm;

    private void Start()
    {
        gm = GameManager.GetInstance();
    }

    public void ShowLetters()
    {
        foreach (Transform child in letterPanel.transform)
        {
            Destroy(child.gameObject);
        }
        if ( gm == null )
        {
            gm = GameManager.GetInstance();
        }
        InventoryManager invManage = gm.inventoryManager;
        for ( int i = 0; i < gm.inventoryManager.letters.Count; i++ )
        {
            GameObject letterInstance = Instantiate(letterPrefab, letterPanel.transform);
            letterInstance.GetComponent<LetterUI>().letterSubject.text = invManage.letters[i].letter.subject;
            if (invManage.letters[i].newLetter)
            {
                letterInstance.GetComponent<LetterUI>().newIcon.SetActive(true);
            } else
            {
                letterInstance.GetComponent<LetterUI>().newIcon.SetActive(false);
            }
            LetterSlot tempLetter = invManage.letters[i];
            letterInstance.GetComponent<Button>().onClick.AddListener(delegate { showLetterCloseup(ref tempLetter); });
        }
    }

    public void showLetterCloseup(ref LetterSlot letterToShow)
    {
        letterToShow.newLetter = false;
        inventoryPanel.hidePanels();
        letterBodyText.text = letterToShow.letter.body;
        letterCloseup.SetActive(true);
    }

    public void closeLetterCloseup()
    {
        if (gm == null)
        {
            gm = GameManager.GetInstance();
        }
        if (!gm.cutsceneManager.mailboxInteract1)
        {
            gm.cutsceneManager.mailboxInteract1 = true;
            letterBodyText.text = "";
            letterCloseup.SetActive(false);
            for (int i = 0; i < gm.mailManager.newLetters.Count; i++)
            {
                gm.inventoryManager.addLetter(gm.mailManager.newLetters[i]);
            }
            gm.mailManager.clearLetters();
            notifController.showNotifications();
            inventoryPanel.hidePanels();
            inventoryPanel.gameObject.SetActive(false);
        } else
        {
            letterCloseup.SetActive(false);
            inventoryPanel.showLettersPanel();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MailboxInteract : Interactable
{
    [SerializeField] private GameObject alert;
    [SerializeField] private GameObject notifications;
    [SerializeField] private GameObject mailNotifications;
    [SerializeField] private GameObject noMailNotif;
    [SerializeField] private GameObject notifContentPanel;
    [SerializeField] private TextMeshProUGUI closeText;

    [SerializeField] private GameObject newLetterPrefab;    
    
    [SerializeField] private LetterContainer letterContainer;

    /* for initial cutscene */
    [SerializeField] private Inventory inv;

    private GameManager gm;

    private void Start()
    {
        gm = GameManager.GetInstance();
    }

    private void Update()
    {
        if ( gm.mailManager.hasNewMail )
        {
            alert.SetActive(true);
        } else
        {
            alert.SetActive(false);
        }
    }

    public override IEnumerator Interact(PlayerController player)
    {
        gm.isPaused = true;
        if ( ! gm.cutsceneManager.mailboxInteract1 ) // have never interacted with the mailbox before
        {
            notifications.SetActive(false);
            mailNotifications.SetActive(false);
            inv.gameObject.SetActive(true);
            gm.pauseShown = true;
            letterContainer.addLetter(gm.mailManager.newLetters[0]);
            inv.showLetterCloseup(gm.mailManager.newLetters[0]);
            gm.mailManager.clearLetters();
            gm.mailManager.hasNewMail = false;
        } else
        {
            if (gm.mailManager.hasNewMail)
            {
                noMailNotif.SetActive(false);
                for (int i = 0; i < gm.mailManager.newLetters.Count; i++)
                {
                    GameObject newLetterInstance = Instantiate(newLetterPrefab, notifContentPanel.transform);
                }
                closeText.text = "Get all";
            }
            else
            {
                noMailNotif.SetActive(true);
                closeText.text = "Close";
            }
            notifications.SetActive(true);
            mailNotifications.SetActive(true);
        }
        yield return new WaitForSeconds(0.2f);
        player.GetComponent<PlayerInteractController>().isInteracting = false;
    }

    public void closeMailNotif()
    {
        notifications.SetActive(false);
        mailNotifications.SetActive(false);
        for (int i = 0; i < gm.mailManager.newLetters.Count; i++)
        {
            letterContainer.addLetter(gm.mailManager.newLetters[i]);
        }
        gm.mailManager.clearLetters();
        gm.mailManager.hasNewMail = false;
        gm.isPaused = false;
    }
}

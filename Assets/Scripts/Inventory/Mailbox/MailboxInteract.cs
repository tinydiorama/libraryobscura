using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MailboxInteract : Interactable
{
    [SerializeField] private GameObject alert;

    [SerializeField] private NotifController notifController;

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
            inv.gameObject.SetActive(true);
            gm.pauseShown = true;
            Letter tempLetter = gm.mailManager.newLetters[0];
            inv.showLetterCloseup(tempLetter);
        } else
        {
            //TODO need to save/load/set the current letters sitting in the mailbox at any given day
            notifController.showNotifications();
        }
        yield return new WaitForSeconds(0.2f);
        player.GetComponent<PlayerInteractController>().isInteracting = false;
    }
}

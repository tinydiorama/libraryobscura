using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailboxInteract : Interactable
{
    [SerializeField] private GameObject alert;
    [SerializeField] private InventoryUI inventoryUI;
    [SerializeField] private MailboxUI mailboxUI;
    [SerializeField] private BuySellUI buySellUI;

    private void LateUpdate()
    {

        if (MailManager.instance.hasNewMail)
        {
            alert.SetActive(true);
        }
        else
        {
            alert.SetActive(false);
        }
    }

    public override void interact()
    {
        if (! StoryManager.instance.mailboxInteract1) // have never interacted with the mailbox before
        {
            inventoryUI.gameObject.SetActive(true);
            GameManager.GetInstance().showPauseMenu();
            LetterSlot tempLetter = new LetterSlot(MailManager.instance.newLetters[0], false);
            inventoryUI.showLetterCloseup(ref tempLetter);
        }
        else
        {
            if ( MailManager.instance.hasNewMail )
            {
                mailboxUI.showReceivedMail();
            } else if ( StoryManager.instance.buyAllowed )
            {
                buySellUI.showShop();
            }
        }
    }
}

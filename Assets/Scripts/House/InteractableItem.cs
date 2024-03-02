using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class InteractableItem : Interactable
{
    [Range(1, 10)]
    [SerializeField] private int randomChance;
    [SerializeField] private GameObject alertBubble;

    [SerializeField] private TextAsset somethingisHere;
    [SerializeField] private TextAsset dialogToShow;
    [SerializeField] private int maxMoneyAmount;
    [SerializeField] private List<Item> potentialItems;
    [SerializeField] private bool obtainMoney;
    [SerializeField] private Sprite moneyImage;

    [SerializeField] private GameObject notifications;
    [SerializeField] private GameObject notificationPrefab;

    private bool hasItem;

    private void Start()
    {
        hasItem = false;
        resetContainsItem();
    }

    public override void interact()
    {
        if ( hasItem )
        {
            // obtain item
            DialogueManager.GetInstance().EnterDialogueMode(somethingisHere);

            if ( obtainMoney )
            {
                float moneyObtained = Random.Range(5, maxMoneyAmount);
                moneyObtained = 5 * (int)System.Math.Round(moneyObtained / 5.0);
                addNotification("Got " + moneyObtained.ToString() + " drobles!", moneyImage, true);
                InventoryManager.instance.money += (int)moneyObtained;
            } else
            {
                int itemToObtain = Random.Range(0, potentialItems.Count);
                Item itemObtained = potentialItems[itemToObtain];
                addNotification("Found a " + itemObtained.itemName, itemObtained.icon, true);
                InventoryManager.instance.addItem(itemObtained);

            }
            alertBubble.SetActive(false);
            hasItem = false;
        } else
        {
            DialogueManager.GetInstance().EnterDialogueMode(dialogToShow);
        }
    }

    private void addNotification(string message, Sprite img, bool shouldSparkle)
    {
        GameObject notification = Instantiate(notificationPrefab, notifications.transform);
        Notification currNotif = notification.GetComponent<Notification>();
        currNotif.message.text = message;
        if (img != null)
        {
            currNotif.image.sprite = img;
        }
        if (shouldSparkle)
        {
            currNotif.sparkles.SetActive(true);
        }
        else
        {
            currNotif.sparkles.SetActive(false);
        }

        StartCoroutine(closeNotification(notification));
    }

    private IEnumerator closeNotification(GameObject notification)
    {
        yield return new WaitForSeconds(4f);
        notification.SetActive(false);
        Destroy(notification);
    }

    public void resetContainsItem()
    {
        int currentChance = Random.Range(1, 10);
        if (currentChance <= randomChance && StoryManager.instance.sellAllowed) // success
        {
            hasItem = true;
            alertBubble.SetActive(true);
        }
        else
        {  // failure 
            hasItem = false;
            alertBubble.SetActive(false);
        }
    }
}

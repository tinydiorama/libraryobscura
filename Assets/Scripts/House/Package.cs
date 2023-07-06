using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class Package : Interactable
{
    [SerializeField] private GameObject sparkles;
    [SerializeField] private GameObject packageSpriteBox;
    [SerializeField] private GameObject notificationsPanel;
    [SerializeField] private GameObject notificationPrefab;
    [SerializeField] private Sprite bookIcon;

    public List<ItemSlot> itemsObtained;
    public List<BookSlot> booksObtained;

    public override void interact()
    {
        sparkles.SetActive(false);
        Animator anim = packageSpriteBox.GetComponent<Animator>();
        anim.SetBool("Animate", true);
        foreach (ItemSlot slot in itemsObtained)
        {
            InventoryManager.instance.addItem(slot.item, slot.count);
            GameObject notification = Instantiate(notificationPrefab, notificationsPanel.transform);
            Notification currNotif = notification.GetComponent<Notification>();
            currNotif.message.text = "Item received: " + slot.item.itemName + "! x" + slot.count.ToString();
            currNotif.image.sprite = slot.item.icon;
            currNotif.sparkles.SetActive(true);
        }
        foreach (BookSlot slot in booksObtained)
        {
            InventoryManager.instance.addBook(slot.book);
            GameObject notification = Instantiate(notificationPrefab, notificationsPanel.transform);
            Notification currNotif = notification.GetComponent<Notification>();
            currNotif.message.text = "Book received: " + slot.book.title + "!";
            currNotif.image.sprite = bookIcon;
            currNotif.sparkles.SetActive(true);
        }
        itemsObtained.Clear();
        booksObtained.Clear();
        StartCoroutine(cleanup());
    }

    private IEnumerator cleanup()
    {
        yield return new WaitForSeconds(4f);
        packageSpriteBox.SetActive(false);
        gameObject.SetActive(false);
        foreach (Transform child in notificationsPanel.transform)
        {
            Destroy(child.gameObject);
        }
    }
}

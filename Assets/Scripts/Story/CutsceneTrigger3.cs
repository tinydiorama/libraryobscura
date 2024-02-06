using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneTrigger3 : MonoBehaviour
{
    [SerializeField] private GameObject notifications;
    [SerializeField] private GameObject notificationPrefab;
    [SerializeField] private Sprite img;

    private bool canShowNotif;

    private void Update()
    {
        InventoryManager inv = InventoryManager.instance;
        if ( canShowNotif )
        {

            if (inv.containsLetter("2newlibrarian") )
            {
                GameObject notification = Instantiate(notificationPrefab, notifications.transform);
                Notification currNotif = notification.GetComponent<Notification>();
                currNotif.message.text = "You can view letters with Tab.";
                currNotif.image.sprite = img;
                currNotif.sparkles.SetActive(false);
                StartCoroutine(closeNotification(notification));

                StoryManager.instance.cutscene3Triggered = true;
                canShowNotif = false;
            }
        }
    }

    private IEnumerator closeNotification(GameObject notification)
    {
        yield return new WaitForSeconds(4f);
        notification.SetActive(false);
        Destroy(notification);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!StoryManager.instance.cutscene3Triggered && collision.gameObject.tag == "Player")
        {
            canShowNotif = true;
        }
    }
}

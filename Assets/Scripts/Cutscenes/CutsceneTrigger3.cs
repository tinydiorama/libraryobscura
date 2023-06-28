using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class CutsceneTrigger3 : MonoBehaviour
{
    [SerializeField] private GameObject notifications;
    [SerializeField] private GameObject notificationPrefab;
    [SerializeField] private Sprite img;

    private GameManager gm;
    private bool canShowNotif;

    private void Start()
    {
        gm = GameManager.GetInstance();
    }

    private void Update()
    {
        if ( canShowNotif )
        {

            if ( gm.inventoryManager.containsLetter("letter2") )
            {
                GameObject notification = Instantiate(notificationPrefab, notifications.transform);
                GardenNotification currNotif = notification.GetComponent<GardenNotification>();
                currNotif.message.text = "You can open your inventory and view letters with Tab.";
                currNotif.image.sprite = img;
                currNotif.sparkles.SetActive(false);
                StartCoroutine(closeNotification(notification));

                gm.cutsceneManager.cutscene3Triggered = true;
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
        if (!gm.cutsceneManager.cutscene3Triggered && collision.gameObject.tag == "Player")
        {
            canShowNotif = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BedController : Interactable
{
    [SerializeField] private GameObject notifications;
    [SerializeField] private GameObject bedConfirmNotif;
    [SerializeField] private TextMeshProUGUI timeText;

    private GameManager gm;
    private PlayerController thePlayer;

    private void Start()
    {
        gm = GameManager.GetInstance();
    }
    public override IEnumerator Interact(PlayerController player)
    {
        timeText.text = gm.dayTime.getTime();
        notifications.SetActive(true);
        bedConfirmNotif.SetActive(true);
        thePlayer = player;
        yield return new WaitForSeconds(0.2f);
    }

    public void cancelSleep()
    {
        notifications.SetActive(false);
        bedConfirmNotif.SetActive(false);
        thePlayer.GetComponent<PlayerInteractController>().isInteracting = false;
    }

    public void sleep()
    {
        gm.dayTime.NextDay();
        notifications.SetActive(false);
        bedConfirmNotif.SetActive(false);
        thePlayer.GetComponent<PlayerInteractController>().isInteracting = false;
    }
}

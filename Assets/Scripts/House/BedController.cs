using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BedController : MonoBehaviour
{
    [SerializeField] private GameObject notifications;
    [SerializeField] private GameObject bedConfirmNotif;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextAsset finishExploringFirst;

    private GameManager gm;
    private bool playerInRange;

    private void Awake()
    {
        playerInRange = false;
    }

    private void Start()
    {
        gm = GameManager.GetInstance();
    }

    private void Update()
    {
        gm = GameManager.GetInstance();
        if (playerInRange && !gm.isPaused && ! gm.disableInteractions)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if ( ! gm.cutsceneManager.cutscene2Triggered )
                {
                    DialogueManager.GetInstance().EnterDialogueMode(finishExploringFirst);
                } else
                {
                    timeText.text = gm.dayTime.getTime();
                    notifications.SetActive(true);
                    bedConfirmNotif.SetActive(true);
                    gm.isPaused = true;
                    gm.pauseShown = true;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }

    public void cancelSleep()
    {
        notifications.SetActive(false);
        bedConfirmNotif.SetActive(false);
        gm.isPaused = false;
        gm.pauseShown = false;
    }

    public void sleep()
    {
        gm.nextDayCleanup();
        notifications.SetActive(false);
        bedConfirmNotif.SetActive(false);
        gm.isPaused = false;
        gm.pauseShown = false;
    }
}

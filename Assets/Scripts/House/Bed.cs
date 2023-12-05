using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bed : MonoBehaviour
{
    [SerializeField] private GameObject bedConfirmPanel;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextAsset finishExploringFirst;

    private bool playerInRange;

    private void Awake()
    {
        playerInRange = false;
    }

    private void Update()
    {
        GameManager gm = GameManager.GetInstance();
        if (playerInRange && !gm.isPaused && !gm.isInteractionsDisabled)
        {
            if (InputManager.GetInstance().GetInteractPressed())
            {
                if (! StoryManager.instance.cutscene2Triggered || ! InventoryManager.instance.containsLetter("letter1"))
                {
                    DialogueManager.GetInstance().EnterDialogueMode(finishExploringFirst);
                }
                else
                {
                    timeText.text = DayTimeController.instance.getTime();
                    bedConfirmPanel.SetActive(true);
                    gm.isPaused = true;
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
        GameManager gm = GameManager.GetInstance();
        bedConfirmPanel.SetActive(false);
        gm.isPaused = false;
    }

    public void sleep()
    {
        GameManager gm = GameManager.GetInstance();
        gm.nextDay();
        bedConfirmPanel.SetActive(false);
        gm.isPaused = false;
    }
}

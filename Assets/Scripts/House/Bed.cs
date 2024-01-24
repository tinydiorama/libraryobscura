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
    private bool bedUIshown;

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
                    StartCoroutine(enableButtons());
                }
            }
        }
    }

    private IEnumerator enableButtons()
    {
        yield return new WaitForSeconds(0.2f);
        bedUIshown = true;
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
        bedUIshown = false;
        GameManager gm = GameManager.GetInstance();
        bedConfirmPanel.SetActive(false);
        StartCoroutine(unPause());
    }

    public void sleep()
    {
        bedUIshown = false;
        GameManager gm = GameManager.GetInstance();
        gm.nextDay();
        bedConfirmPanel.SetActive(false);
        gm.isPaused = false;
    }

    private IEnumerator unPause()
    {
        GameManager gm = GameManager.GetInstance();
        yield return new WaitForSeconds(0.2f);
        gm.isPaused = false;
    }
}

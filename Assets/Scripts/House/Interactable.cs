using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] private TextAsset tooDarkToSee;

    private bool playerInRange;
    private GameManager gm;

    private void Awake()
    {
        playerInRange = false;
    }

    private void Update()
    {
        gm = GameManager.GetInstance();
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying && !gm.isInteractionsDisabled)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (DayTimeController.instance.isTooDark())
                {
                    DialogueManager.GetInstance().EnterDialogueMode(tooDarkToSee);
                }
                else
                {
                    PlayerManager.instance.GetComponent<PlayerPlatformerController>().stopPlayer();
                    interact();
                }
            }
        }
    }

    public abstract void interact();

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
}

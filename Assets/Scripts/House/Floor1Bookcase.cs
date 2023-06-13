using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor1Bookcase : MonoBehaviour
{
    [SerializeField] private TextAsset bookcaseText1;
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
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying && ! gm.disableInteractions)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (gm.dayTime.isTooDark())
                {
                    DialogueManager.GetInstance().EnterDialogueMode(tooDarkToSee);
                }
                else
                {
                    DialogueManager.GetInstance().EnterDialogueMode(bookcaseText1);
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
}

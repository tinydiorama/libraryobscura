using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGate : MonoBehaviour 
{
    [SerializeField] private TextAsset gateText;
    [SerializeField] private AudioClip gateLockedClip;
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
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if ( DayTimeController.instance.isTooDark() )
                {
                    DialogueManager.GetInstance().EnterDialogueMode(tooDarkToSee);
                } else
                {
                    AudioManager.GetInstance().playSFX(gateLockedClip);
                    DialogueManager.GetInstance().EnterDialogueMode(gateText);
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

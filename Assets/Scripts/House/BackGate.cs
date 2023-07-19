using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGate : MonoBehaviour
{
    [SerializeField] private TextAsset gateText;
    [SerializeField] private AudioClip gateLockedClip;
    [SerializeField] private AudioClip gateUnlockedClip;
    [SerializeField] private TextAsset tooDarkToSee;
    [SerializeField] private Sprite gateUnlocked;

    private bool playerInRange;
    private GameManager gm;

    private void Awake()
    {
        playerInRange = false;
    }

    private void Update()
    {
        gm = GameManager.GetInstance();
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying && ! StoryManager.instance.backgateUnlocked)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if ( DayTimeController.instance.isTooDark() )
                {
                    DialogueManager.GetInstance().EnterDialogueMode(tooDarkToSee);
                } else
                {
                    if ( InventoryManager.instance.containsItem("backgatekey"))
                    {
                        GetComponent<SpriteRenderer>().sprite = gateUnlocked;
                        AudioManager.GetInstance().playSFX(gateUnlockedClip);
                        StoryManager.instance.backgateUnlocked = true;
                        transform.GetChild(0).gameObject.SetActive(false);
                        GetComponent<HighlightShowController>().disableHighlight();
                    } else
                    {
                        AudioManager.GetInstance().playSFX(gateLockedClip);
                        DialogueManager.GetInstance().EnterDialogueMode(gateText);
                    }
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

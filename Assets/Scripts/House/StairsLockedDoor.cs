using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsLockedDoor : MonoBehaviour
{
    [SerializeField] private TextAsset staircaseLocked;
    [SerializeField] private TextAsset tooDarkToSee;
    [SerializeField] private AudioClip doorUnlockedClip;
    [SerializeField] private GameObject colliderObj;
    [SerializeField] private HouseController houseController;

    private bool playerInRange;
    private GameManager gm;

    private void Awake()
    {
        playerInRange = false;
    }

    private void Update()
    {
        gm = GameManager.GetInstance();
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying && !StoryManager.instance.floor2Unlocked)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (DayTimeController.instance.isTooDark())
                {
                    DialogueManager.GetInstance().EnterDialogueMode(tooDarkToSee);
                }
                else
                {
                    if (InventoryManager.instance.containsItem("upstairskey"))
                    {
                        colliderObj.SetActive(false);
                        AudioManager.GetInstance().playSFX(doorUnlockedClip);
                        StoryManager.instance.floor2Unlocked = true;
                        GetComponent<HighlightShowController>().disableHighlight();
                        houseController.unlockLibrary();
                    } else
                    {
                        DialogueManager.GetInstance().EnterDialogueMode(staircaseLocked);
                    }
                }
            }
        }
    }

    public void unlockLibrary()
    {
        colliderObj.SetActive(false);
        GetComponent<HighlightShowController>().disableHighlight();
        houseController.addLibrary();
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

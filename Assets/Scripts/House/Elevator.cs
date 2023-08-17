using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] private int floorNum;
    [SerializeField] private GameObject floor2Collider;
    [SerializeField] private Vector3 startPos;
    [SerializeField] private Vector3 floor1Pos = new Vector3(18.44929f, -2.79659f, 0);
    [SerializeField] private Vector3 floor2Pos = new Vector3(18.44929f, 0.2506582f, 0);
    [SerializeField] private Vector3 floor3Pos;
    [SerializeField] private bool startOpen;

    [SerializeField] private TextAsset staircaseLocked;
    [SerializeField] private AudioClip doorUnlockedClip;
    [SerializeField] private HouseController houseController;

    [SerializeField] private GameObject[] elevatorShafts;
    [SerializeField] private GameObject[] elevators;

    private bool playerInRange;
    private GameManager gm;
    private GameObject player;
    private int floorToGoTo;

    private void Awake()
    {
        playerInRange = false;
    }

    private void Start()
    {
        if (startOpen)
        {
            transform.GetChild(0).GetComponent<Animator>().SetBool("DoorStartOpen", true);
        }
    }

    private void Update()
    {
        gm = GameManager.GetInstance();
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying && !gm.isInteractionsDisabled)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PlayerManager.instance.GetComponent<PlayerPlatformerController>().stopPlayer();
                gm.isPaused = true;
                interact();
            }
        }
    }

    public void interact()
    {
        transform.GetChild(0).GetComponent<Animator>().SetBool("DoorStartOpen", false);
        StartCoroutine(finishOpeningDoor());
    }

    private IEnumerator finishOpeningDoor()
    {
        yield return new WaitForSeconds(1f);
        transform.GetChild(0).GetComponent<Animator>().SetBool("CloseDoor", true);
        StartCoroutine(runElevator());
    }

    private IEnumerator runElevator()
    {
        yield return new WaitForSeconds(1f);
        transform.GetChild(0).GetComponent<Animator>().SetBool("CloseDoor", false);
        StoryManager sm = StoryManager.instance;
        if (InventoryManager.instance.containsItem("upstairskey"))
        {
            if (!sm.floor2Unlocked)
            {
                AudioManager.GetInstance().playSFX(doorUnlockedClip);
                sm.floor2Unlocked = true;
                houseController.unlockLibrary();
            }

            foreach (GameObject elevatorShaft in elevatorShafts)
            {
                Vector3 pos;
                pos = elevatorShaft.transform.localPosition;
                pos.z = -1.42f;
                elevatorShaft.transform.localPosition = pos;
            }
            if (StoryManager.instance.floor3Unlocked)
            {
                // show elevator UI and pick a floor and handle all that
            }
            else
            {
                // just go to floor 2
                //floor2Collider.SetActive(false);
                if (floorNum == 0) // go up
                {
                    floorToGoTo = 1;
                    StartCoroutine(MoveOverSeconds(player, floor2Pos, 5f));
                    StartCoroutine(resetElevatorPos());
                }
                else // if floorNum == 1 go down
                {
                    floorToGoTo = 0;
                    StartCoroutine(MoveOverSeconds(player, floor1Pos, 5f));
                    StartCoroutine(resetElevatorPos());
                }
            }
        }
        else
        {
            DialogueManager.GetInstance().EnterDialogueMode(staircaseLocked);
        }
    }

    IEnumerator resetElevatorPos()
    {
        yield return new WaitForSeconds(1.2f);
        elevators[floorToGoTo].transform.GetChild(0).GetComponent<Animator>().SetBool("OpenDoor", true);
        floor2Collider.SetActive(true);
        gm.isPaused = false;
        foreach (GameObject elevatorShaft in elevatorShafts)
        {
            Vector3 pos;
            pos = elevatorShaft.transform.localPosition;
            pos.z = -1.40f;
            elevatorShaft.transform.localPosition = pos;
        }
        StartCoroutine(finishOpeningNewFloorDoor());
    }
    IEnumerator finishOpeningNewFloorDoor()
    {
        yield return new WaitForSeconds(1f);
        elevators[floorToGoTo].transform.GetChild(0).GetComponent<Animator>().SetBool("OpenDoor", false);
    }

    IEnumerator MoveOverSeconds(GameObject obj, Vector3 target, float speed)
    {
        Vector3 startPosition = obj.transform.position;
        float time = 0f;

        while (obj.transform.position != target)
        {
            obj.transform.position = Vector3.Lerp(startPosition, target, (time / Vector3.Distance(startPosition, target)) * speed);
            time += Time.deltaTime;
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = true;
            player = collider.gameObject;
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

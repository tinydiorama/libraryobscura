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


    [SerializeField] private GameObject[] elevatorShafts;

    private bool playerInRange;
    private GameManager gm;
    private GameObject player;

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
                PlayerManager.instance.GetComponent<PlayerPlatformerController>().stopPlayer();
                interact();
            }
        }
    }

    public void interact()
    {
        transform.GetChild(0).GetComponent<Animator>().SetBool("CloseDoor", true);
        floor2Collider.SetActive(false);

        foreach ( GameObject elevatorShaft in elevatorShafts )
        {
            Vector3 pos;
            pos = elevatorShaft.transform.localPosition;
            pos.z = -1.42f;
            elevatorShaft.transform.localPosition = pos;
        }
        if ( StoryManager.instance.floor3Unlocked )
        {
            // show elevator UI and pick a floor and handle all that
        } else
        {
            // just go to floor 2
            gm.isPaused = true;
            if ( floorNum == 0 ) // go up
            {
                StartCoroutine(MoveOverSeconds(player, floor2Pos, 5f));
            } else // if floorNum == 1 go down
            {
                StartCoroutine(MoveOverSeconds(player, floor1Pos, 5f));
            }
        }

    }

    public void resetElevatorPos()
    {
        floor2Collider.SetActive(true);
        gm.isPaused = false;
        foreach (GameObject elevatorShaft in elevatorShafts)
        {
            Vector3 pos;
            pos = elevatorShaft.transform.localPosition;
            pos.z = -1.40f;
            Debug.Log(pos);
            elevatorShaft.transform.localPosition = pos;
        }
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
        resetElevatorPos();
    }
}

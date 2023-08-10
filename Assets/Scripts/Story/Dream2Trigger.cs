using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dream2Trigger : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cutsceneCam;
    public CinemachineVirtualCamera mainCam;

    private GameManager gm;
    private bool playerInRange;
    private GameObject player;

    private void Awake()
    {
        playerInRange = false;
    }

    private void Update()
    {
        gm = GameManager.GetInstance();
        if (playerInRange)
        {
            StartCoroutine(animateTrigger());
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
    private IEnumerator animateTrigger()
    {
        player.GetComponent<Animator>().SetBool("Falling", true);
        gm.isPaused = true;
        yield return new WaitForSeconds(1.5f);
        gm.showNightFade();
        StartCoroutine(cleanupTrigger());
    }

    private IEnumerator cleanupTrigger()
    {
        yield return new WaitForSeconds(2.5f);
        cutsceneCam.gameObject.SetActive(false);
        mainCam.gameObject.SetActive(true);
        player.GetComponent<Animator>().SetBool("Falling", false);
        CutsceneManager.instance.cleanupCutscene();
    }
}

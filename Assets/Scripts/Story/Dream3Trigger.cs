using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dream3Trigger : MonoBehaviour
{
    [SerializeField] private AudioClip boom;
    [SerializeField] private CinemachineVirtualCamera cutsceneCam;
    public CinemachineVirtualCamera mainCam;
    [SerializeField] private GameObject altarObject;

    private GameManager gm;
    private bool playerInRange;
    private GameObject player;

    private void Update()
    {
        gm = GameManager.GetInstance();
        if (playerInRange)
        {
            gm.isPaused = true;
            StartCoroutine(showAltar());
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

    private IEnumerator showAltar()
    {
        altarObject.SetActive(true);
        AudioManager.GetInstance().playSFX(boom);
        player.GetComponent<PlayerPlatformerController>().stopPlayer();
        yield return new WaitForSeconds(3f);
        gm.showNightFade();
        StartCoroutine(cleanupTrigger());
    }

    private IEnumerator cleanupTrigger()
    {
        yield return new WaitForSeconds(2.5f);
        cutsceneCam.gameObject.SetActive(false);
        mainCam.gameObject.SetActive(true);
        player.GetComponent<PlayerPlatformerController>().loudFootsteps = false;
        CutsceneManager.instance.cleanupCutscene();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dream1Trigger : MonoBehaviour {
    [SerializeField] private AudioClip boom;
    [SerializeField] private Dream1Manager dh;

    [SerializeField] private AudioSource whine;
    [SerializeField] private AudioSource knock;

    private GameManager gm;
    private bool playerInRange;

    private void Awake()
    {
        playerInRange = false;
    }

    private void Update()
    {
        gm = GameManager.GetInstance();
        if (playerInRange)
        {
            gm.showNightFadeAbrupt();
            whine.Stop();
            knock.Stop();
            AudioManager.GetInstance().playSFX(boom);
            CutsceneManager.instance.cleanupCutscene();
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

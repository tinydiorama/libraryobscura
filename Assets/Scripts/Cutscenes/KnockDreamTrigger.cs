using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockDreamTrigger : MonoBehaviour
{
    [SerializeField] private GameObject cutToBlack;
    [SerializeField] private GameObject fadeToNightDay;
    [SerializeField] private AudioClip boom;
    [SerializeField] private DreamHelper dh;

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
            fadeToNightDay.GetComponent<Animator>().speed = 1f;
            cutToBlack.SetActive(true);
            fadeToNightDay.SetActive(true);
            whine.Stop();
            knock.Stop();
            AudioManager.GetInstance().playSFX(boom);
            StartCoroutine(endTheDream());
        }
    }

    private IEnumerator endTheDream()
    {
        yield return new WaitForSeconds(1f);
        cutToBlack.SetActive(false);
        dh.endDream1();
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

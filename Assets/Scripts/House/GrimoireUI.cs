using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrimoireUI : MonoBehaviour
{


    private GameManager gm;
    private bool playerInRange;

    private void Awake()
    {
        playerInRange = false;
    }

    private void Update()
    {
        gm = GameManager.GetInstance();
        if (playerInRange && !gm.isPaused)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("grimoire activate!");
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

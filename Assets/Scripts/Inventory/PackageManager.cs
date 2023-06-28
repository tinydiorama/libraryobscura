using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageManager : MonoBehaviour
{
    [SerializeField] private TextAsset tooDarkToSee;
    public List<Item> itemsObtained;
    public List<Book> booksObtained;

    private GameManager gm;
    private bool playerInRange;

    private void Awake()
    {
        playerInRange = false;
    }

    private void Update()
    {
        gm = GameManager.GetInstance();
        if (playerInRange && !gm.isPaused && !gm.disableInteractions)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
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

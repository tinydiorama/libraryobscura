using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteractController : MonoBehaviour
{
    //[SerializeField] float offsetDistance = 1f;
    //[SerializeField] float interactableArea = 1.2f;
    private PlayerController player;
    private Rigidbody2D rb;
    [SerializeField] public bool isInteracting;

    private bool canInteract;
    private Collider2D currentCollider;
    private GameManager gm;

    private void Awake()
    {
        player = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        gm = GameManager.GetInstance();
    }

    private void Update()
    {
        if ( ! gm.isPaused )
        {
            if (Input.GetKey(KeyCode.E) && canInteract == true)
            {
                Interact();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Interactable hit = collision.GetComponent<Interactable>();
        if (hit != null && isInteracting == false)
        {
            canInteract = true;
            currentCollider = collision;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canInteract = false;
    }

    private void Interact()
    {
        if (isInteracting == false)
        {
            isInteracting = true;
            StartCoroutine(currentCollider.GetComponent<Interactable>().Interact(player));
        }
    }
}

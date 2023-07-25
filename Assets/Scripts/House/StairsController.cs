using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StairsController : MonoBehaviour
{
    [SerializeField] private GameObject stairsCollider;
    [SerializeField] private GameObject stairsOverlay;

    public bool upPressed;
    public bool playerInFront;
    public bool isInAir;

    PlayerManager player;
    PlayerPlatformerController playerPlatformer;

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerManager.instance;
        playerPlatformer = player.GetComponent<PlayerPlatformerController>();

        playerPlatformer.onJump += hasJumped;
        playerPlatformer.onLand += hasLanded;
    }

    // Update is called once per frame
    void Update()
    {
        if ( ! playerInFront && ! playerPlatformer.facingRight)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                upPressed = true;
            }
            else if (Input.GetKeyUp(KeyCode.W) )
            {
                upPressed = false;
            }
        }

        if (upPressed )
        {
            stairsCollider.SetActive(true);
            stairsOverlay.SetActive(true);
        }
        else
        {
            stairsCollider.SetActive(false);
            stairsOverlay.SetActive(false);
        }
    }

    private void hasJumped()
    {
        if (!playerPlatformer.facingRight && !playerInFront)
        {
            upPressed = true;
        }
    }
    private void hasLanded()
    {
        upPressed = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            playerInFront = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            playerInFront = false;
            upPressed = false;
        }
    }
}

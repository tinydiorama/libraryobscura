using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StairsController : MonoBehaviour
{
    [SerializeField] private GameObject stairsCollider;
    [SerializeField] private GameObject stairsOverlay;

    private bool upPressed;
    private bool stayPressed;
    private bool playerInFront;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ( ! playerInFront )
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                upPressed = true;
            }
            else if (Input.GetKeyUp(KeyCode.W))
            {
                upPressed = false;
            }
        }

        if (upPressed)
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

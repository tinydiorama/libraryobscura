using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightController : MonoBehaviour
{
    [SerializeField] private Sprite highlightSprite;
    [SerializeField] private Sprite normalSprite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.name == "Player" )
        {
            this.GetComponent<SpriteRenderer>().sprite = highlightSprite;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            this.GetComponent<SpriteRenderer>().sprite = normalSprite;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailboxHighlight : HighlightController {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player" && (GameManager.GetInstance().mailManager.hasNewMail || GameManager.GetInstance().cutsceneManager.buyAllowed))
        {
            this.GetComponent<SpriteRenderer>().sprite = highlightSprite;
        }
    }
}

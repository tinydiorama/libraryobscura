using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightShowController : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToShow;
    private bool highlightEnabled = true;

    public void disableHighlight()
    {
        highlightEnabled = false;
    }

    public void enableHighlight()
    {
        highlightEnabled = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player" && highlightEnabled)
        {
            foreach ( GameObject go in objectsToShow)
            {
                go.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            hideHighlight();
        }
    }

    public void hideHighlight()
    {
        foreach (GameObject go in objectsToShow)
        {
            go.SetActive(false);
        }
    }
}

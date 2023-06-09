using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighlightShowController : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToShow;
    [SerializeField] private GameObject canvasToRedraw;
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
            if ( canvasToRedraw != null )
            {
                RefreshLayoutGroupsImmediateAndRecursive();
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



    public void RefreshLayoutGroupsImmediateAndRecursive()
    {
        GameObject root = canvasToRedraw;
        if (canvasToRedraw != null)
        {
            foreach (var layoutGroup in root.GetComponentsInChildren<LayoutGroup>())
            {
                LayoutRebuilder.ForceRebuildLayoutImmediate(layoutGroup.GetComponent<RectTransform>());
            }
        }
    }
}

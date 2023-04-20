using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GardenPlot : Interactable
{
    [SerializeField] private Sprite tilledSprite;
    [SerializeField] private Sprite wateredSoil;
    [SerializeField] private TextMeshProUGUI promptText;
    [SerializeField] private SpriteRenderer sr;

    private int state;
    private bool watered;

    public override IEnumerator Interact(PlayerController player)
    {
        if (state > 0 && !watered)
        {
            Debug.Log("watering");
            watered = true;
            sr.sprite = wateredSoil;
            promptText.text = "Plant";
        }
        else if (sr.sprite == null && state == 0)
        {
            Debug.Log("tilling");
            sr.sprite = tilledSprite;
            state = 1;
            promptText.text = "Water";
        } else if ( state == 1 && watered )
        {
            // plant
            GetComponent<HighlightShowController>().disableHighlight();
            GetComponent<HighlightShowController>().hideHighlight();
        }
        yield return new WaitForSeconds(0.2f);
        resetInteraction(player);
    }
}

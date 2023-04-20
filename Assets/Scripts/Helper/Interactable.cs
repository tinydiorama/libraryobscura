using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public virtual IEnumerator Interact(PlayerController player)
    {
        yield break;
    }

    public void resetInteraction(PlayerController player)
    {
        player.GetComponent<PlayerInteractController>().isInteracting = false;
    }
}

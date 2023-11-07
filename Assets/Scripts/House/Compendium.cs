using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compendium : Interactable
{
    [SerializeField] private CompendiumUI compendiumUI;

    public override void interact()
    {
        compendiumUI.gameObject.SetActive(true);
        compendiumUI.startCompendium();
    }
}

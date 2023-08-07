using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottles : Interactable
{
    [SerializeField] private TextAsset bottlesText1;

    public override void interact()
    {
        DialogueManager.GetInstance().EnterDialogueMode(bottlesText1);
    }
}

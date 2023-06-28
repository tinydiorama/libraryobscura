using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : Interactable{
    [SerializeField] private TextAsset clockText1;

    public override void interact()
    {
        DialogueManager.GetInstance().EnterDialogueMode(clockText1);
    }
}

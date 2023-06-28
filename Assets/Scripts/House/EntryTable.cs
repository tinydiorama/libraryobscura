using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryTable : Interactable {
    [SerializeField] private TextAsset entryText1;

    public override void interact()
    {
        DialogueManager.GetInstance().EnterDialogueMode(entryText1);
    }
}

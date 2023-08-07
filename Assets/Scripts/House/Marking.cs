using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marking : Interactable{
    [SerializeField] private TextAsset markingText1;

    public override void interact()
    {
        DialogueManager.GetInstance().EnterDialogueMode(markingText1);
    }
}

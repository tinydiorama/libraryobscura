using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor1Bookcase : Interactable
{
    [SerializeField] private TextAsset bookcaseText1;

    public override void interact()
    {
        DialogueManager.GetInstance().EnterDialogueMode(bookcaseText1);
    }

}

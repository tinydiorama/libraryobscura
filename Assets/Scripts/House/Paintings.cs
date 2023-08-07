using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paintings : Interactable{
    [SerializeField] private TextAsset paintingsText1;

    public override void interact()
    {
        DialogueManager.GetInstance().EnterDialogueMode(paintingsText1);
    }
}

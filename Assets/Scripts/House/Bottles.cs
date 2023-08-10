using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottles : Interactable
{
    [SerializeField] private TextAsset bottlesText1;
    [SerializeField] private TextAsset bottlesText2;

    public override void interact()
    {
        StoryManager sm = StoryManager.instance;
        if ( ! sm.dream1Triggered )
        {
            DialogueManager.GetInstance().EnterDialogueMode(bottlesText1);
        } else if (sm.dream1Triggered && !sm.dream2Triggered)
        {
            DialogueManager.GetInstance().EnterDialogueMode(bottlesText2);
        }
    }
}

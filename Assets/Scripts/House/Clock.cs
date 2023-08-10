using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : Interactable{
    [SerializeField] private TextAsset clockText1;
    [SerializeField] private TextAsset clockText2;

    public override void interact()
    {
        StoryManager sm = StoryManager.instance;
        if (!sm.dream1Triggered)
        {
            DialogueManager.GetInstance().EnterDialogueMode(clockText1);
        }
        else if (sm.dream1Triggered && !sm.dream2Triggered)
        {
            DialogueManager.GetInstance().EnterDialogueMode(clockText2);
        }
    }
}

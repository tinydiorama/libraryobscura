using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marking : Interactable{
    [SerializeField] private TextAsset markingText1;
    [SerializeField] private TextAsset markingText2;

    public override void interact()
    {
        StoryManager sm = StoryManager.instance;
        if (!sm.dream1Triggered)
        {
            DialogueManager.GetInstance().EnterDialogueMode(markingText1);
        }
        else if (sm.dream1Triggered && !sm.dream2Triggered)
        {
            DialogueManager.GetInstance().EnterDialogueMode(markingText2);
        }
    }
}

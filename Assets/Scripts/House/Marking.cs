using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marking : Interactable{
    [SerializeField] private TextAsset markingText1;
    [SerializeField] private TextAsset markingText2;
    [SerializeField] private TextAsset markingText3;
    [SerializeField] private TextAsset markingText4;
    [SerializeField] private TextAsset markingText5;

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
        else if (sm.dream2Triggered && !sm.dream3Triggered)
        {
            DialogueManager.GetInstance().EnterDialogueMode(markingText3);
        }
        else if (sm.dream3Triggered && !sm.dream4Triggered)
        {
            DialogueManager.GetInstance().EnterDialogueMode(markingText4);
        }
        else if (sm.dream4Triggered)
        {
            DialogueManager.GetInstance().EnterDialogueMode(markingText5);
        }
    }
}

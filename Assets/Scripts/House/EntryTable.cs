using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryTable : Interactable {
    [SerializeField] private TextAsset entryText1;
    [SerializeField] private TextAsset entryText2;

    public override void interact()
    {
        StoryManager sm = StoryManager.instance;
        if (!sm.dream1Triggered)
        {
            DialogueManager.GetInstance().EnterDialogueMode(entryText1);
        }
        else if (sm.dream1Triggered && !sm.dream2Triggered)
        {
            DialogueManager.GetInstance().EnterDialogueMode(entryText2);
        }
    }
}

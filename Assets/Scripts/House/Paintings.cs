using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paintings : Interactable{
    [SerializeField] private TextAsset paintingsText1;
    [SerializeField] private TextAsset paintingsText2;

    public override void interact()
    {
        StoryManager sm = StoryManager.instance;
        if (!sm.dream1Triggered)
        {
            DialogueManager.GetInstance().EnterDialogueMode(paintingsText1);
        }
        else if (sm.dream1Triggered && !sm.dream2Triggered)
        {
            DialogueManager.GetInstance().EnterDialogueMode(paintingsText2);
        }
    }
}

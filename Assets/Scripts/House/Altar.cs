using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Altar : Interactable
{
    [SerializeField] private AltarUI altarUI;
    public override void interact()
    {
        StoryManager sm = StoryManager.instance;
        if (sm.seenAltar == false)
        {
            altarUI.showIntroMessage();
        } else
        {
            altarUI.showAltar();
        }
        GetComponent<HighlightShowController>().hideHighlight();
    }
}

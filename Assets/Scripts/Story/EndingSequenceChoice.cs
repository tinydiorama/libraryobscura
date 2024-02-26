using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EndingSequenceChoice : MonoBehaviour
{
    [SerializeField] private GameObject choicePanel;
    [SerializeField] private Item panaceaItem;
    [SerializeField] private EndingSequenceLetter endingLetter;
    [SerializeField] private Button firstButton;

    [SerializeField] private string Xtext1;
    [SerializeField] private string Xtext2;
    [SerializeField] private string Friendtext1;
    [SerializeField] private string Friendtext2;

    private StoryManager sm;
    private int endingChoice;

    // Start is called before the first frame update
    void Start()
    {
        sm = StoryManager.instance;
        endingChoice = 0;
        EventSystem.current.SetSelectedGameObject(firstButton.gameObject);
    }

    public void setChoice(int choice)
    {
        endingChoice = choice;
    }

    public void submitChoice()
    {
        sm = StoryManager.instance;

        choicePanel.SetActive(false);
        InventoryManager.instance.removeItem(panaceaItem);

        if (endingChoice == 0 )
        {
            sm.endingChoiceMade = true;
            sm.xChoice = true;
            endingLetter.showEndingTextLetter(Xtext1, Xtext2);
        } else if (endingChoice == 1 )
        {
            sm.endingChoiceMade = true;
            sm.friendChoice = true;
            endingLetter.showEndingTextLetter(Friendtext1, Friendtext2);
        }
    }

    public void cancelChoice()
    {
        choicePanel.SetActive(false);
    }
}

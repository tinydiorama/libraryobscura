using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bookcase : Interactable
{
    [SerializeField] private TextAsset bookcaseText1;
    [SerializeField] private int numPossibleBooks = 1;
    [SerializeField] private BookcaseUI bookcaseUI;
    [SerializeField] public string bookcasePlacementText;

    public List<Book> books;

    public override void interact()
    {
        if (StoryManager.instance.allowBooks)
        {
            if (books.Count < numPossibleBooks) // still room in bookcase
            {
                bookcaseUI.showBookSelectUI(this.gameObject);
            }
            else // no room in bookcase
            {
                bookcaseUI.showBookReadUI(books);
            }
        }
        else
        {
            DialogueManager.GetInstance().EnterDialogueMode(bookcaseText1);
        }
    }
}

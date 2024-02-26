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
        int numNonPlacedBooks = 0; 
        InventoryManager invManage = InventoryManager.instance;
        for (int i = 0; i < invManage.books.Count; i++)
        {
            if (invManage.books[i].placement == "") // this book hasn't been placed yet
            {
                numNonPlacedBooks++;
            }
        }
        
        if (StoryManager.instance.allowBooks)
        {
            if (books.Count < numPossibleBooks && numNonPlacedBooks > 0) // still room in bookcase AND there's a nonplaced book in inventory
            {
                bookcaseUI.showBookSelectUI(this.gameObject, numPossibleBooks);
            }
            else // no room in bookcase
            {
                bookcaseUI.showBookReadUI(books, numPossibleBooks);
            }
        }
        else
        {
            DialogueManager.GetInstance().EnterDialogueMode(bookcaseText1);
        }
    }
}

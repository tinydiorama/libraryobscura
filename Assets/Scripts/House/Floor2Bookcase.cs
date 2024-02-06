using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor2Bookcase : Bookcase, iDataPersistence
{
    public void LoadData(GameData data)
    {
        InventoryManager inv = InventoryManager.instance;
        foreach (Book dbBook in inv.booksDatabase)
        {
            if (data.floor2Bookcase.Contains(dbBook.id))
            {
                books.Add(dbBook);
            }
        }
    }

    public void SaveData(ref GameData data)
    {
        data.floor2Bookcase.Clear();

        foreach (Book dbBook in books)
        {
            data.floor2Bookcase.Add(dbBook.id);
        }
    }
}

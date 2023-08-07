using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Book")]
public class Book : ScriptableObject
{
    public string id;
    public string title;
    public string author;
    public Color bookColor;

    public Sprite page1;

    [TextArea(5, 10)]
    public string page2;

    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }
}

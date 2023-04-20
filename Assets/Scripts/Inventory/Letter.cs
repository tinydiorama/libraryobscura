using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Letter")]
public class Letter : ScriptableObject
{
    public string id;
    public string from;
    public string subject;

    [TextArea(5, 10)]
    public string body;

    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }
}

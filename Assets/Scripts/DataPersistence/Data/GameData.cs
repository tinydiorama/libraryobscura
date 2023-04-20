using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GameData
{
    public int days;
    public SerializedDictionary<string, bool> letters;
    public SerializedDictionary<string, bool> books;

    // the values defined in this constructor are the default values
    // default values on new game
    public GameData()
    {
        this.days = 0;
        this.letters = new SerializedDictionary<string, bool>();
        this.books = new SerializedDictionary<string, bool>();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GameData
{
    public int days;
    public SerializedDictionary<string, bool> letters;
    public SerializedDictionary<string, bool> books;
    public SerializedDictionary<string, int> items;

    // farm
    public List<string> seedId;
    public List<int> state;
    public List<bool> watered;

    // cutscene
    public bool initialMailbox;
    public bool cutscene1triggered;

    // the values defined in this constructor are the default values
    // default values on new game
    public GameData()
    {
        this.days = 0;
        this.letters = new SerializedDictionary<string, bool>();
        this.books = new SerializedDictionary<string, bool>();
        this.items = new SerializedDictionary<string, int>();

        seedId = new List<string>();
        state = new List<int>();
        watered = new List<bool>();

        initialMailbox = false;
        cutscene1triggered = false;
    }
}

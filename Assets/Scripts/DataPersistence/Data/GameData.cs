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
    public SerializedDictionary<string, bool> grimoire;

    // cutscene
    public bool initialMailbox;
    public bool cutscene0triggered;
    public bool cutscene1triggered;
    public bool cutscene2triggered;
    public bool buyAllowed;
    public bool sellAllowed;

    // current mailbox
    public bool hasNewMail;
    public List<string> mailboxLetters;
    public List<string> mailboxBooks;
    public List<string> mailboxItems;

    // the values defined in this constructor are the default values
    // default values on new game
    public GameData()
    {
        this.days = 0;
        this.letters = new SerializedDictionary<string, bool>();
        this.books = new SerializedDictionary<string, bool>();
        this.items = new SerializedDictionary<string, int>();

        this.seedId = new List<string>();
        this.state = new List<int>();
        this.watered = new List<bool>();
        this.grimoire = new SerializedDictionary<string, bool>();

        this.initialMailbox = false;
        this.cutscene0triggered = false;
        this.cutscene1triggered = false;
        this.cutscene2triggered = false;
        this.buyAllowed = false;
        this.sellAllowed = false;

        this.hasNewMail = false;
        this.mailboxLetters = new List<string>();
        this.mailboxBooks = new List<string>();
        this.mailboxItems = new List<string>();
    }
}

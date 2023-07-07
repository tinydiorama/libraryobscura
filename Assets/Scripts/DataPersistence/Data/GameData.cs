using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GameData
{
    public int days;
    public SerializableDictionary<string, bool> letters;
    public SerializableDictionary<string, bool> books;
    public SerializableDictionary<string, int> items;
    public int money;
    public int numItemsSoldAllTime;

    // farm
    public List<string> seedId;
    public List<int> state;
    public List<bool> watered;

    // cutscene/story
    public bool initialMailbox;
    public bool cutscene0triggered;
    public bool cutscene1triggered;
    public bool cutscene2triggered;
    public bool cutscene3triggered;
    public bool buyAllowed;
    public bool sellAllowed;
    public bool dream1triggered;
    public bool seenAltar;
    public SerializableDictionary<string, int> saleItems;

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
        this.money = 0;
        this.numItemsSoldAllTime = 0;
        this.letters = new SerializableDictionary<string, bool>();
        this.books = new SerializableDictionary<string, bool>();
        this.items = new SerializableDictionary<string, int>();

        this.seedId = new List<string>();
        this.state = new List<int>();
        this.watered = new List<bool>();

        this.initialMailbox = false;
        this.cutscene0triggered = false;
        this.cutscene1triggered = false;
        this.cutscene2triggered = false;
        this.cutscene3triggered = false;
        this.buyAllowed = false;
        this.sellAllowed = false;
        this.dream1triggered = false;
        this.seenAltar = false;
        this.saleItems = new SerializableDictionary<string, int>();

        this.hasNewMail = false;
        this.mailboxLetters = new List<string>();
        this.mailboxBooks = new List<string>();
        this.mailboxItems = new List<string>();
    }
}

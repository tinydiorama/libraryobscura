using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GameData
{
    public int days;
    public int lastLetterReceivedDay;
    public SerializableDictionary<string, bool> letters;
    public SerializableDictionary<string, string> books;
    public SerializableDictionary<string, int> items;
    public SerializableDictionary<string, bool> collection;
    public int money;
    public int numItemsSoldAllTime;
    public string lucidity;

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
    public bool dream2triggered;
    public bool dream3triggered;
    public bool seenAltar;
    public bool backgateUnlocked;
    public bool allowBooks;
    public bool floor2Unlocked;
    public bool floor2StudyUnlocked;
    public bool floor3Unlocked;
    public bool floor4Unlocked;
    public SerializableDictionary<string, int> saleItems;
    public SerializableDictionary<string, string> booksOrdered;
    public SerializableDictionary<string, int> itemsOrdered;

    // current mailbox
    public bool hasNewMail;
    public List<string> mailboxLetters;
    public List<string> mailboxBooks;
    public List<string> mailboxItems;

    // bookcases
    public List<string> floor1Bookcase;
    public List<string> floor2Bookcase;

    // the values defined in this constructor are the default values
    // default values on new game
    public GameData()
    {
        this.days = 0;
        this.lastLetterReceivedDay = 0;
        this.money = 0;
        this.numItemsSoldAllTime = 0;
        this.letters = new SerializableDictionary<string, bool>();
        this.books = new SerializableDictionary<string, string>();
        this.items = new SerializableDictionary<string, int>();
        this.collection = new SerializableDictionary<string, bool>();
        this.lucidity = "Clear";

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
        this.dream2triggered = false;
        this.dream3triggered = false;
        this.seenAltar = false;
        this.backgateUnlocked = false;
        this.allowBooks = false;
        this.floor2Unlocked = false;
        this.floor2StudyUnlocked = false;
        this.floor3Unlocked = false;
        this.floor4Unlocked = false;
        this.saleItems = new SerializableDictionary<string, int>();
        this.booksOrdered = new SerializableDictionary<string, string>();
        this.itemsOrdered = new SerializableDictionary<string, int>();

        this.hasNewMail = false;
        this.mailboxLetters = new List<string>();
        this.mailboxBooks = new List<string>();
        this.mailboxItems = new List<string>();

        this.floor1Bookcase = new List<string>();
        this.floor2Bookcase = new List<string>();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GameData
{
    public int days;
    public Dictionary<string, bool> letters;
    public Dictionary<string, bool> books;
    public Dictionary<string, int> items;
    public int money;
    public int numItemsSoldAllTime;

    // farm
    public List<string> seedId;
    public List<int> state;
    public List<bool> watered;

    // cutscene
    public bool initialMailbox;
    public bool cutscene0triggered;
    public bool cutscene1triggered;
    public bool cutscene2triggered;
    public bool cutscene3triggered;
    public bool buyAllowed;
    public bool sellAllowed;
    public bool dream1triggered;

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
        this.letters = new Dictionary<string, bool>();
        this.books = new Dictionary<string, bool>();
        this.items = new Dictionary<string, int>();

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

        this.hasNewMail = false;
        this.mailboxLetters = new List<string>();
        this.mailboxBooks = new List<string>();
        this.mailboxItems = new List<string>();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour, iDataPersistence
{
    public bool cutscene0Triggered;
    public bool cutscene1Triggered;
    public bool cutscene2Triggered;
    public bool cutscene3Triggered;
    public bool dream1Triggered;
    public bool dream2Triggered;
    public bool mailboxInteract1;
    public bool buyAllowed;
    public bool sellAllowed;
    public bool seenAltar;
    public bool allowBooks;
    public bool backgateUnlocked;
    public bool floor2Unlocked;
    public int lastLetterReceivedDay;
    public string lucidity;

    [Header("Story Objects")]
    [SerializeField] private GameObject figure;
    [SerializeField] private GameObject backgate;
    [SerializeField] private StairsLockedDoor upstairsTrigger;
    [SerializeField] private Sprite backgateOpenedSprite;
    [SerializeField] private StoryData data;

    [Header("Dream Managers")]
    [SerializeField] private Dream1Manager dream1Manager;

    public static StoryManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        GameManager.GetInstance().onEndOfDay += advanceStory;

        MailManager mm = MailManager.instance;
        InventoryManager inv = InventoryManager.instance;
        if ( cutscene0Triggered == false )
        {
            mm.addNewLetter(data.day1Letter);
            foreach (Item seed in data.day1Seeds)
            {
                mm.newItems.Add(seed);
            }
            mm.hasNewMail = true;
        }
    }

    private void advanceStory()
    {
        MailManager mm = MailManager.instance;
        InventoryManager inv = InventoryManager.instance;
        DayTimeController dayTime = DayTimeController.instance;
        if (dream1Triggered == true && dream2Triggered == false )
        {
            lucidity = "Uncertain";
        }

        if ( ! mm.hasNewMail ) // only put mail in if there's not already current mail
        {
            if (dayTime.days == 1) // day 1 (really day 2) gives you a new letter and 2 new seeds
            {
                mm.addNewLetter(data.day2Letter);
                foreach (Item seed in data.day2Seeds)
                {
                    mm.newItems.Add(seed);
                }
                mm.hasNewMail = true;
                lastLetterReceivedDay = dayTime.days;
            }
            else if (inv.containsLetter("letter2") && !inv.containsLetter("letter3")
                && inv.numSold() >= 1) // after you've received the day 2 letter & sold ANYTHING
            {
                foreach (Letter letter in data.day3Letters)
                {
                    mm.addNewLetter(letter);
                }
                mm.addNewBook(data.day3Book);
                allowBooks = true;
                mm.hasNewMail = true;
                lastLetterReceivedDay = dayTime.days;
            }
            else if (inv.containsLetter("letter4") && !inv.containsLetter("letter5"))
            {
                mm.addNewLetter(data.day4Letter);
                mm.newItems.Add(data.day4Key);
                mm.hasNewMail = true;
                lastLetterReceivedDay = dayTime.days;
            } else if (inv.containsLetter("letter5") && !inv.containsLetter("letter6") 
                && (dayTime.days - lastLetterReceivedDay >= 2))
            {
                mm.addNewLetter(data.day5Letter);
                lastLetterReceivedDay = dayTime.days;
                mm.hasNewMail = true;
            } else if (inv.containsLetter("letter6") && !inv.containsLetter("letter7")
                && inv.numSold("cloudsprigplant") >= 1)
            {
                mm.addNewLetter(data.day6Letter);
                mm.hasNewMail = true;
                lastLetterReceivedDay = dayTime.days;
            } else if (inv.containsLetter("letter7") && !inv.containsLetter("letter8"))
            {
                mm.addNewLetter(data.day7Letter);
                mm.hasNewMail = true;
                mm.addNewBook(data.day7Book);
                lastLetterReceivedDay = dayTime.days;
            }
            else if (inv.containsLetter("letter8") && !inv.containsLetter("letter9"))
            {
                foreach (Letter letter in data.day10Letters)
                {
                    mm.addNewLetter(letter);
                }
                mm.hasNewMail = true;
                mm.newItems.Add(data.day10Key);
                lastLetterReceivedDay = dayTime.days;
            }
            else if (inv.containsLetter("letter10") && !inv.containsLetter("letter11")
                && inv.numSold() >= 10)
            {
                mm.addNewLetter(data.day11Letter);
                mm.hasNewMail = true;
                lastLetterReceivedDay = dayTime.days;
            }
            else if (inv.containsLetter("letter11") && !inv.containsLetter("letter12"))
            {
                mm.addNewLetter(data.day12Letter);
                mm.addNewBook(data.day12Book);
                mm.hasNewMail = true;
                lastLetterReceivedDay = dayTime.days;
            }
        }
    }

    // check what sale rewards to give
    public List<BookSlot> nightCheckBook()
    {

        return new List<BookSlot>();
    }
    public List<ItemSlot> nightCheckItem()
    {

        return new List<ItemSlot>();
    }

    public void LoadData(GameData data)
    {
        this.mailboxInteract1 = data.initialMailbox;
        this.cutscene0Triggered = data.cutscene0triggered;
        this.cutscene1Triggered = data.cutscene1triggered;
        this.cutscene2Triggered = data.cutscene2triggered;
        this.cutscene3Triggered = data.cutscene3triggered;
        this.buyAllowed = data.buyAllowed;
        this.sellAllowed = data.sellAllowed;
        this.dream1Triggered = data.dream1triggered;
        this.dream2Triggered = data.dream2triggered;
        this.seenAltar = data.seenAltar;
        this.lastLetterReceivedDay = data.lastLetterReceivedDay;
        this.lucidity = data.lucidity;
        this.allowBooks = data.allowBooks;
        this.floor2Unlocked = data.floor2Unlocked;
        this.backgateUnlocked = data.backgateUnlocked;

        if (figure != null)
        {
            if (this.cutscene2Triggered)
            {
                figure.SetActive(false);
            }
            else
            {
                figure.SetActive(true);
            }
        }

        if ( backgate != null )
        {
            if ( this.backgateUnlocked )
            {
                backgate.GetComponent<SpriteRenderer>().sprite = backgateOpenedSprite;
                backgate.transform.GetChild(0).gameObject.SetActive(false);
                backgate.GetComponent<HighlightShowController>().disableHighlight();
            }
        }
        if (upstairsTrigger != null && this.floor2Unlocked )
        {
            upstairsTrigger.unlockLibrary();
        }
        if (this.buyAllowed)
        {
            InventoryManager.instance.showMoneyHUD();
        }
    }

    public void SaveData(ref GameData data)
    {
        data.initialMailbox = this.mailboxInteract1;
        data.cutscene0triggered = this.cutscene0Triggered;
        data.cutscene1triggered = this.cutscene1Triggered;
        data.cutscene2triggered = this.cutscene2Triggered;
        data.cutscene3triggered = this.cutscene3Triggered;
        data.buyAllowed = this.buyAllowed;
        data.sellAllowed = this.sellAllowed;
        data.dream1triggered = this.dream1Triggered;
        data.dream2triggered = this.dream2Triggered;
        data.seenAltar = this.seenAltar;
        data.lastLetterReceivedDay = this.lastLetterReceivedDay;
        data.lucidity = this.lucidity;
        data.backgateUnlocked = this.backgateUnlocked;
        data.allowBooks = this.allowBooks;
        data.floor2Unlocked = this.floor2Unlocked;
    }
}

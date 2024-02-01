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
    public bool floor2StudyUnlocked;
    public bool floor3Unlocked;
    public bool floor4Unlocked;
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
        CollectionManager cm = CollectionManager.instance;

        int numDiscovered = cm.getAllDiscovered();

        if (dream1Triggered == true && dream2Triggered == false )
        {
            lucidity = "Uncertain";
        }

        if ( ! mm.hasNewMail ) // only put mail in if there's not already current mail
        {
            if (dayTime.days == 1) // day 1 (really day 2) gives you a new letter and 2 new seeds
            {
                mm.addNewLetter(data.phase2Letter);
                foreach (Item seed in data.phase2Seeds)
                {
                    mm.newItems.Add(seed);
                }
                mm.hasNewMail = true;
                lastLetterReceivedDay = dayTime.days;
            }
            else if (dream1Triggered && inv.containsLetter("2newlibrarian") && !inv.containsLetter("3wizenedgardener"))
            {
                foreach (Letter letter in data.phase3Letters)
                {
                    mm.addNewLetter(letter);
                }
                mm.addNewBook(data.phase3Book);
                allowBooks = true;
                mm.hasNewMail = true;
                lastLetterReceivedDay = dayTime.days;
            }
            else if (inv.containsLetter("4kindlytraveler") && !inv.containsLetter("5bookkeeper"))
            {
                foreach (Letter letter in data.phase4Letters)
                {
                    mm.addNewLetter(letter);
                }
                mm.newItems.Add(data.phase4Key);
                mm.hasNewMail = true;
                lastLetterReceivedDay = dayTime.days;
            }

            /* x path */
            if ( inv.containsLetter("5bookkeeper") && ! inv.containsLetter("x1youmusthurry")
                && inv.numItemsSoldAllTime > 1 )
            {
                mm.addNewLetter(data.x1Letter);
                mm.hasNewMail = true;
                lastLetterReceivedDay = dayTime.days;
            } else if (inv.containsLetter("x1youmusthurry") && !inv.containsLetter("x2imsorry"))
            {
                mm.addNewLetter(data.x2Letter);
                mm.hasNewMail = true;
                lastLetterReceivedDay = dayTime.days;
            } else if (inv.containsLetter("x2imsorry") && !inv.containsLetter("x3hopeless")
                && inv.numItemsSoldAllTime > 5)
            {
                mm.addNewLetter(data.x3Letter);
                mm.hasNewMail = true;
                lastLetterReceivedDay = dayTime.days;
            } else if (inv.containsLetter("x3hopeless") && !inv.containsLetter("x4churchlyvisitors"))
            {
                mm.addNewLetter(data.x4Letter);
                mm.hasNewMail = true;
                lastLetterReceivedDay = dayTime.days;
            } else if (inv.containsLetter("x4churchlyvisitors") && !inv.containsLetter("x5vicaroverseers")
                && inv.numItemsSoldAllTime > 10)
            {
                mm.addNewLetter(data.x5Letter);
                mm.hasNewMail = true;
                lastLetterReceivedDay = dayTime.days;
            } else if (inv.containsLetter("x5vicaroverseers") && !inv.containsLetter("x6strangebedfellows"))
            {
                mm.addNewLetter(data.x6Letter);
                mm.hasNewMail = true;
                lastLetterReceivedDay = dayTime.days;
            }

            /* friend path */
            if (inv.containsLetter("5bookkeeper") && !inv.containsLetter("f1breakthrough")
                && numDiscovered > 3)
            {
                mm.addNewLetter(data.f1Letter);
                mm.hasNewMail = true;
                lastLetterReceivedDay = dayTime.days;
            }
            else if (inv.containsLetter("f1breakthrough") && !inv.containsLetter("f2anotherboonforyou"))
            {
                mm.addNewLetter(data.f2Letter);
                mm.hasNewMail = true;
                lastLetterReceivedDay = dayTime.days;
            }
            else if (inv.containsLetter("f2anotherboonforyou") && !inv.containsLetter("f3myresearch")
                && numDiscovered > 4)
            {
                mm.addNewLetter(data.f3Letter);
                mm.hasNewMail = true;
                lastLetterReceivedDay = dayTime.days;
            }
            else if (inv.containsLetter("f3myresearch") && !inv.containsLetter("f4helpfultidings"))
            {
                mm.addNewLetter(data.f4Letter);
                mm.hasNewMail = true;
                lastLetterReceivedDay = dayTime.days;
            }
            else if (inv.containsLetter("f4helpfultidings") && !inv.containsLetter("f5humblebeginnings")
                && numDiscovered > 5)
            {
                mm.addNewLetter(data.f5Letter);
                mm.hasNewMail = true;
                lastLetterReceivedDay = dayTime.days;
            }
            else if (inv.containsLetter("f5humblebeginnings") && !inv.containsLetter("f6finedining"))
            {
                mm.addNewLetter(data.f6Letter);
                mm.hasNewMail = true;
                lastLetterReceivedDay = dayTime.days;
            }

            /*else if (inv.containsLetter("5bookkeeper") && !inv.containsLetter("letter6") 
                && (dayTime.days - lastLetterReceivedDay >= 2))
            {
                mm.addNewLetter(data.day5Letter);
                mm.addNewLetter(data.day6Letter);
                lastLetterReceivedDay = dayTime.days;
                mm.hasNewMail = true;
            } */

            /*if (inv.containsLetter("letter6") && !inv.containsLetter("letter7")
                && inv.numSold("cloudsprigplant") >= 1)
            {
                mm.addNewLetter(data.day7Letter);
                mm.hasNewMail = true;
                lastLetterReceivedDay = dayTime.days;
                // miro point
            } */
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
        this.floor2StudyUnlocked = data.floor2StudyUnlocked;
        this.floor3Unlocked = data.floor3Unlocked;
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
        data.floor2StudyUnlocked = this.floor2StudyUnlocked;
        data.floor3Unlocked = this.floor3Unlocked;
    }
}

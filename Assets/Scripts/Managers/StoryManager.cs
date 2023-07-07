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
    public bool mailboxInteract1;
    public bool buyAllowed;
    public bool sellAllowed;
    public bool seenAltar;

    [SerializeField] private GameObject figure;
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
        if (DayTimeController.instance.days == 1) // day 1 (really day 2) gives you a new letter and 2 new seeds
        {
            mm.addNewLetter(data.day2Letter);
            foreach (Item seed in data.day2Seeds)
            {
                mm.newItems.Add(seed);
            }
            mm.hasNewMail = true;
        }
        else if (inv.containsLetter("letter2") && ! inv.containsLetter("letter3")
            && inv.numSold("glowwartplant") >= 3) // after you've received the day 2 letter & sold 3 glowwart
        {
            mm.addNewLetter(data.day3Letter);
            mm.newItems.Add(data.day3Key);
            mm.hasNewMail = true;
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
        this.seenAltar = data.seenAltar;

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
        data.seenAltar = this.seenAltar;
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private Animator nightFade;
    [SerializeField] private FarmController farm;
    [SerializeField] private GameObject moneyContainer;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private DayTransitionHelper dayTransitionHelper;
    [SerializeField] private DreamHelper dreamHelper;

    public CutsceneManager cutsceneManager;
    public CutsceneData cutsceneData;
    public MailManager mailManager;
    public DayTimeController dayTime;
    public InventoryManager inventoryManager;
    public ShopManager shopManager;
    public GrimoireController grimoireManager;
    public GameObject player;
    public bool isPaused;
    public bool isStopTime;
    public bool pauseShown;
    public int money;
    public int soldToday;
    public bool disableInteractions;

    private float m_CurrentClipLength;

    private static GameManager instance;

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

    private void Update()
    {
        if (Input.GetKey(KeyCode.Tab) ) 
        {
            if ( pauseShown )
            {
                StartCoroutine(hidePauseMenu());
            } else
            {
                if ( ! isPaused && ! disableInteractions)
                {
                    StartCoroutine(showPauseMenu());
                }
            }
        }
        moneyText.text = money.ToString();
    }

    public void showMoneyUI()
    {
        moneyContainer.SetActive(true);
    }

    public static GameManager GetInstance()
    {
        return instance;
    }

    public void nextDayCleanup()
    {
        isPaused = true;
        nightFade.gameObject.SetActive(true);
        AnimatorClipInfo[] animController = nightFade.GetCurrentAnimatorClipInfo(0);

        m_CurrentClipLength = animController[0].clip.length;
        AudioManager.GetInstance().FadeOutMusic();

        StartCoroutine(processDay());
    }

    IEnumerator processDay()
    {
        yield return new WaitForSeconds(m_CurrentClipLength);
        nightFade.SetBool("NightFaded", true);

        // process things
        dayTime.NextDay();
        farm.advanceSeeds();
        processDataforDay();

        // Saves the game
        //DataPersistenceManager.instance.SaveGame();
        if ( dayTime.days == 2 ) // do the dream instead
        {
            dreamHelper.setupDream1();
            nightFade.GetComponent<Animator>().speed = 0.2f;
            m_CurrentClipLength = m_CurrentClipLength / 0.2f;
            StartCoroutine(startNewDay());
        } else
        {
            dayTransitionHelper.showItems();
            AudioManager.GetInstance().ChangeSong();
        }
        //StartCoroutine(startNewDay());
    }

    public IEnumerator startNewDay()
    {
        soldToday = 0;
        nightFade.SetBool("FadeToDay", true);
        yield return new WaitForSeconds(m_CurrentClipLength);
        nightFade.gameObject.SetActive(false);
        dayTransitionHelper.hideItems();
        isPaused = false;
        nightFade.GetComponent<Animator>().speed = 1f;
    }

    IEnumerator showPauseMenu()
    {
        yield return new WaitForSeconds(0.3f);
        isPaused = true;
        pauseShown = true;
        pauseMenu.SetActive(true);
        pauseMenu.GetComponent<Inventory>().inventoryInitialize();
    }

    IEnumerator hidePauseMenu()
    {
        yield return new WaitForSeconds(0.3f);
        isPaused = false;
        pauseShown = false;
        pauseMenu.SetActive(false);
    }

    private void processDataforDay()
    {
        if ( dayTime.days == 1 ) // day 1 (really day 2) gives you a new letter and 2 new seeds
        {
            mailManager.addNewLetter(cutsceneData.day2Letter);
            foreach( Item seed in cutsceneData.day2Seeds )
            {
                mailManager.newItems.Add(seed);
            }
            mailManager.hasNewMail = true;
        } else if ( dayTime.days == 2 )
        {

        }
    }
}

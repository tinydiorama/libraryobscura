using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private Animator nightFade;
    [SerializeField] private FarmController farm;

    public CutsceneManager cutsceneManager;
    public CutsceneData cutsceneData;
    public MailManager mailManager;
    public DayTimeController dayTime;
    public InventoryManager inventoryManager;
    public ShopManager shopManager;
    public bool isPaused;
    public bool pauseShown;
    public int money;

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
                if ( ! isPaused )
                {
                    StartCoroutine(showPauseMenu());
                }
            }
        }
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
        DataPersistenceManager.instance.SaveGame();
        nightFade.SetBool("FadeToDay", true);
        StartCoroutine(startNewDay());
    }

    IEnumerator startNewDay()
    {
        isPaused = false;
        AudioManager.GetInstance().ChangeSong();
        yield return new WaitForSeconds(m_CurrentClipLength);
        nightFade.gameObject.SetActive(false);
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
        }
    }
}

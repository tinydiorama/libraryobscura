using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private DayTransitionHelper dayTransition;
    [SerializeField] private GameObject nightFade;
    [SerializeField] private bool saveAtNight;

    public bool isPaused;
    public bool isStopTime;
    public bool isInteractionsDisabled;
    private bool pauseMenuShown;

    public bool showPackageInfo;

    private static GameManager instance;
    

    public event UnityAction onEndOfDay;
    public event UnityAction onStartNewDay;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    public static GameManager GetInstance()
    {
        return instance;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            if (pauseMenuShown)
            {
                StartCoroutine(hidePauseMenu());
            }
            else
            {
                if (! isPaused && ! isInteractionsDisabled)
                {
                    StartCoroutine(showPauseMenu());
                }
            }
        }
    }

    public IEnumerator showPauseMenu()
    {
        yield return new WaitForSeconds(0.3f);
        isPaused = true;
        pauseMenuShown = true;
        InventoryManager.instance.openInventory();
    }

    public IEnumerator hidePauseMenu()
    {
        yield return new WaitForSeconds(0.3f);
        isPaused = false;
        pauseMenuShown = false;
        InventoryManager.instance.closeInventory();
    }

    public void nextDay()
    {
        isPaused = true;
        showNightFade();
        StartCoroutine(processDay());
    }

    private IEnumerator processDay()
    {
        DayTimeController.instance.NextDay();
        yield return new WaitForSeconds(2f);
        onEndOfDay?.Invoke();

        // Saves the game
        if ( saveAtNight )
        {
            DataPersistenceManager.instance.SaveGame();
        }

        // nighttime activities :)
        if (InventoryManager.instance.containsLetter("letter2") && ! StoryManager.instance.dream1Triggered) // do the dream instead
        {
            CutsceneManager.instance.loadCutscene1();
        }
        else
        {
            dayTransition.showItems(showPackageInfo);
        }
    }

    public void showNightFade()
    {
        dayTransition.showOverlay();
    }

    public void showNightFadeAbrupt()
    {
        dayTransition.showOverlayAbrupt();
    }

    public void hideNightFade()
    {
        dayTransition.hideOverlay();
    }

    public IEnumerator startNewDay()
    {
        onStartNewDay?.Invoke();
        AudioManager.GetInstance().ChangeSong();
        dayTransition.hideOverlay();
        yield return new WaitForSeconds(1f);
        isPaused = false;
    }
}

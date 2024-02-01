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
    [SerializeField] private GameObject hud;
    public bool saveAtNight;

    public bool isPaused;
    public bool isStopTime;
    public bool isInteractionsDisabled;
    public bool pauseMenuShown;

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
        if (InputManager.GetInstance().GetMenuPressed())
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
        hud.SetActive(false);
        showNightFade();
        AudioManager.GetInstance().FadeOutMusic();
        StartCoroutine(processDay());
    }

    private IEnumerator processDay()
    {
        InventoryManager inv = InventoryManager.instance;
        DayTimeController.instance.NextDay();
        yield return new WaitForSeconds(2f);
        onEndOfDay?.Invoke();

        // nighttime activities :)
        if (inv.containsLetter("2newlibrarian") && !StoryManager.instance.dream1Triggered
            && inv.itemsOrdered.Count == 0) // do the dream instead
        {
            CutsceneManager.instance.loadCutscene1();
            StoryManager.instance.dream1Triggered = true;
        } else if (inv.containsLetter("x6strangebedfellows") && inv.containsLetter("f6finedining")
            && ! StoryManager.instance.dream2Triggered)
        {
            CutsceneManager.instance.loadCutscene2();
            StoryManager.instance.dream2Triggered = true;
        }
        else
        {
            dayTransition.showItems(showPackageInfo);
        }

        // Saves the game
        if ( saveAtNight )
        {
            DataPersistenceManager.instance.SaveGame();
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
        hud.SetActive(true);
        onStartNewDay?.Invoke();
        AudioManager.GetInstance().ChangeSong();
        dayTransition.hideOverlay();
        InteractableItemsManager.instance.resetItems();
        yield return new WaitForSeconds(1f);
        isPaused = false;
    }
}

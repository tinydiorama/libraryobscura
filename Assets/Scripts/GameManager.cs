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
    public bool isInteractionsDisabled;
    private bool pauseMenuShown;

    private static GameManager instance;
    

    public event UnityAction onEndOfDay;
    public event UnityAction onStartNewDay;

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
        nightFade.SetActive(true);
        LeanTween.alpha(nightFade.GetComponent<RectTransform>(), 1, 2f).setEase(LeanTweenType.easeInOutSine);
        AudioManager.GetInstance().FadeOutMusic();

        StartCoroutine(processDay());
    }

    private IEnumerator processDay()
    {
        yield return new WaitForSeconds(1f);
        DayTimeController.instance.NextDay();
        yield return new WaitForSeconds(1f);
        onEndOfDay?.Invoke();

        // Saves the game
        if ( saveAtNight )
        {
            DataPersistenceManager.instance.SaveGame();
        }
        /*if (inventoryManager.containsLetter("letter2") && !cutsceneManager.dream1Triggered) // do the dream instead
        {
            dreamHelper.setupDream1();
            nightFade.GetComponent<Animator>().speed = 0.2f;
            m_CurrentClipLength = m_CurrentClipLength / 0.2f;
            StartCoroutine(startDream1());
        }
        else
        {*/
            dayTransition.showItems(false);
            AudioManager.GetInstance().ChangeSong();
        //}
    }

    public IEnumerator startNewDay()
    {
        onStartNewDay?.Invoke();
        LeanTween.alpha(nightFade.GetComponent<RectTransform>(), 0, 2f).setEase(LeanTweenType.easeInOutSine);
        yield return new WaitForSeconds(2f);
        nightFade.gameObject.SetActive(false);
        dayTransition.hideItems();
        isPaused = false;
    }
}

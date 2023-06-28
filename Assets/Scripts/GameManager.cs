using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public bool isPaused;
    public bool isInteractionsDisabled;
    private bool pauseMenuShown;

    private static GameManager instance;
    

    public static UnityAction onPaused;
    //onPaused?.Invoke();

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

    public void nextDayCleanup()
    {
        Debug.Log("cleanup");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    public CutsceneManager cutsceneManager;
    public MailManager mailManager;
    public DayTimeController dayTime;
    public InventoryManager inventoryManager;
    public bool isPaused;
    public bool pauseShown;

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
}

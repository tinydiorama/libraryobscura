using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DayTransitionHelper : MonoBehaviour
{
    [SerializeField] private GameObject[] itemsToShow;
    [SerializeField] private GameObject nightFadeOverlay;
    [SerializeField] private TextMeshProUGUI dayText;
    [SerializeField] private TextMeshProUGUI soldItems;
    [SerializeField] private TextMeshProUGUI booksObtained;
    [SerializeField] private TextMeshProUGUI plantsDiscovered;
    [SerializeField] private TextMeshProUGUI lucidityText;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI moneyChange;
    [SerializeField] private GameObject packageAvailable;
    [SerializeField] private GameObject continueButton;
    [SerializeField] private AudioClip thumpSound;

    private float timeBetween = 1f;
    private float showItemTime;
    private bool canContinue;

    private float desiredAlpha;
    private float currentAlpha;
    private float timeToFade;


    private void Update()
    {
        if ( canContinue )
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                canContinue = false;
                StartCoroutine(GameManager.GetInstance().startNewDay());
            }
        }

        nightFadeOverlay.GetComponent<CanvasGroup>().alpha = currentAlpha;
        if ( currentAlpha != desiredAlpha )
        {
            currentAlpha = Mathf.MoveTowards(currentAlpha, desiredAlpha, timeToFade * Time.deltaTime);
        } else if ( currentAlpha == desiredAlpha && currentAlpha == 0f )
        {
            nightFadeOverlay.SetActive(false); // hide it
        }
    }

    public void showItems(bool hasPackageAtDoor)
    {
        GameManager gm = GameManager.GetInstance();
        InventoryManager inv = InventoryManager.instance;
        gm.isPaused = true;
        // update all the text
        dayText.text = (DayTimeController.instance.days).ToString();
        soldItems.text = inv.numItemsSoldToday.ToString();
        booksObtained.text = InventoryManager.instance.books.Count.ToString();
        plantsDiscovered.text = "0";
        //grimoireFilled.text = gm.grimoireManager.numItemsDiscovered().ToString();
        lucidityText.text = "Clear";
        moneyText.text = InventoryManager.instance.money.ToString();
        
        if ( inv.moneyEarnedToday - inv.moneySpentToday < 0 )
        {
            moneyChange.text = (inv.moneyEarnedToday - inv.moneySpentToday).ToString();
        } else 
        {
            moneyChange.text = "+" + (inv.moneyEarnedToday - inv.moneySpentToday).ToString();
        }

        foreach ( GameObject item in itemsToShow )
        {
            StartCoroutine(showItem(item));
        }
        if (hasPackageAtDoor)
        {
            StartCoroutine(showItem(packageAvailable));
        }
        StartCoroutine(showItem(continueButton));
    }

    public void showOverlay()
    {
        nightFadeOverlay.SetActive(true);
        timeToFade = 0.5f;
        desiredAlpha = 1f;
    }

    public void showOverlayAbrupt()
    {
        nightFadeOverlay.SetActive(true);
        desiredAlpha = 1f;
        currentAlpha = 1f;
        nightFadeOverlay.GetComponent<CanvasGroup>().alpha = 1f;
    }

    public void hideOverlay()
    {
        timeToFade = 0.5f;
        desiredAlpha = 0;
        foreach (GameObject item in itemsToShow)
        { 
            item.SetActive(false);

        }
        continueButton.SetActive(false);
        showItemTime = 0;
    }

    IEnumerator showItem(GameObject item)
    {
        showItemTime += timeBetween;
        yield return new WaitForSeconds(showItemTime);
        item.SetActive(true);
        if ( item.name == "ContinueArrow" )
        {
            canContinue = true;
        } else
        {
            AudioManager.GetInstance().playSFX(thumpSound);
        }
    }
}

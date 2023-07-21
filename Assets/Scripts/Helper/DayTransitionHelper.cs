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
    [SerializeField] private GameObject saveGameText;

    private float timeBetween = 1f;
    private float showItemTime;
    private float currentMoneyVal;
    private bool canContinue;
    private bool showMoneyCounter;

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
        currentMoneyVal = 0;
        GameManager gm = GameManager.GetInstance();
        InventoryManager inv = InventoryManager.instance;
        gm.isPaused = true;
        // update all the text
        dayText.text = (DayTimeController.instance.days).ToString();
        soldItems.text = inv.numItemsSoldToday.ToString();
        booksObtained.text = inv.books.Count.ToString();
        plantsDiscovered.text = CollectionManager.instance.getAllDiscovered().ToString();
        lucidityText.text = StoryManager.instance.lucidity;
        if ( inv.moneyEarnedToday > 0 ) // if you earned money, show the prev amount so we can count up
        {
            moneyText.text = (inv.money - inv.moneyEarnedToday).ToString();
            currentMoneyVal = inv.money - inv.moneyEarnedToday;
        } else
        {
            moneyText.text = inv.money.ToString();
            currentMoneyVal = inv.money;
        }


        if ( inv.moneyEarnedToday - inv.moneySpentToday < 0 )
        {
            moneyChange.text = (inv.moneyEarnedToday - inv.moneySpentToday).ToString();
            showMoneyCounter = false;
        } else 
        {
            moneyChange.text = "+" + (inv.moneyEarnedToday - inv.moneySpentToday).ToString();
            showMoneyCounter = true;
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
        packageAvailable.SetActive(false);
        continueButton.SetActive(false);
        showItemTime = 0;
    }

    IEnumerator showItem(GameObject item)
    {
        showItemTime += timeBetween;
        yield return new WaitForSeconds(showItemTime);
        item.SetActive(true);
        if ( item.name == "MoneyItem" && showMoneyCounter)
        {
            StartCoroutine(CountUpToTarget(moneyText, InventoryManager.instance.money));
        }
        if ( item.name == "ContinueArrow" )
        {
            canContinue = true;
            if (GameManager.GetInstance().saveAtNight)
            {
                saveGameText.SetActive(true);
                StartCoroutine(hideSaveGameText());
            }
        } else
        {
            AudioManager.GetInstance().playSFX(thumpSound);
        }
    }

    IEnumerator CountUpToTarget(TextMeshProUGUI field, int target)
    {
        while (currentMoneyVal < target)
        {
            currentMoneyVal += (target / (2f / Time.deltaTime));
            currentMoneyVal = Mathf.Clamp(currentMoneyVal, 0, target);
            field.text = Mathf.Ceil(currentMoneyVal).ToString();
            yield return null;
        }
    }

    IEnumerator hideSaveGameText()
    {
        yield return new WaitForSeconds(2f);
        saveGameText.SetActive(false);
    }
}

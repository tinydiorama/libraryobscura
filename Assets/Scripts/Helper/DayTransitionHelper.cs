using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DayTransitionHelper : MonoBehaviour
{
    [SerializeField] private GameObject[] itemsToShow;
    [SerializeField] private TextMeshProUGUI dayText;
    [SerializeField] private TextMeshProUGUI soldItems;
    [SerializeField] private TextMeshProUGUI booksObtained;
    [SerializeField] private TextMeshProUGUI grimoireFilled;
    [SerializeField] private TextMeshProUGUI lucidityText;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private GameObject continueButton;
    [SerializeField] private AudioClip thumpSound;

    private float timeBetween = 1f;
    private float showItemTime;
    private bool canContinue;

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
    }

    public void showItems()
    {
        GameManager gm = GameManager.GetInstance();
        gm.isPaused = true;
        // update all the text
        dayText.text = gm.dayTime.days.ToString();
        soldItems.text = gm.soldToday.ToString();
        booksObtained.text = gm.inventoryManager.books.Count.ToString();
        grimoireFilled.text = gm.grimoireManager.numItemsDiscovered().ToString();
        lucidityText.text = "Clear";
        moneyText.text = gm.money.ToString();

        foreach ( GameObject item in itemsToShow )
        {
            StartCoroutine(showItem(item));
        }
        StartCoroutine(showItem(continueButton));
    }

    public void hideItems()
    {
        foreach (GameObject item in itemsToShow)
        {
            item.SetActive(false);
        }
        continueButton.SetActive(false);
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

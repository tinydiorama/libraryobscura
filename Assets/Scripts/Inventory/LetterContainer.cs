using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class LetterSlot
{
    public Letter letter;
    public bool newLetter;

    public LetterSlot(Letter letterToAdd, bool isNew)
    {
        letter = letterToAdd;
        newLetter = isNew;
    }
}
public class LetterContainer : MonoBehaviour
{
    [SerializeField] private Inventory inventoryPanel;
    [SerializeField] private GameObject letterPanel;
    [SerializeField] private GameObject letterPrefab;
    [SerializeField] private GameObject letterCloseup;
    [SerializeField] private TextMeshProUGUI letterBodyText;

    private GameManager gm;

    private void Start()
    {
        gm = GameManager.GetInstance();
    }

    public void ShowLetters()
    {
        foreach (Transform child in letterPanel.transform)
        {
            Destroy(child.gameObject);
        }
        if ( gm == null )
        {
            gm = GameManager.GetInstance();
        }
        for ( int i = 0; i < gm.letters.Count; i++ )
        {
            GameObject letterInstance = Instantiate(letterPrefab, letterPanel.transform);
            letterInstance.GetComponent<LetterUI>().letterSubject.text = gm.letters[i].letter.subject;
            if (gm.letters[i].newLetter)
            {
                letterInstance.GetComponent<LetterUI>().newIcon.SetActive(true);
            } else
            {
                letterInstance.GetComponent<LetterUI>().newIcon.SetActive(false);
            }
            LetterSlot tempLetter = gm.letters[i];
            letterInstance.GetComponent<Button>().onClick.AddListener(delegate { showLetterCloseup(ref tempLetter); });
        }
    }

    public void showLetterCloseup(ref LetterSlot letterToShow)
    {
        letterToShow.newLetter = false;
        inventoryPanel.hidePanels();
        letterBodyText.text = letterToShow.letter.body;
        letterCloseup.SetActive(true);
    }

    public void closeLetterCloseup()
    {
        letterCloseup.SetActive(false);
        inventoryPanel.showLettersPanel();
    }

    public void addLetter(Letter letterToAdd)
    {
        if ( gm == null )
        {
            gm = GameManager.GetInstance();
        }
        gm.letters.Add(new LetterSlot(letterToAdd, true));
    }

    public void addLetter(Letter letterToAdd, bool isNew)
    {
        if (gm == null)
        {
            gm = GameManager.GetInstance();
        }
        gm.letters.Add(new LetterSlot(letterToAdd, isNew));
    }
}

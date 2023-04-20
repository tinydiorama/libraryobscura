using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject lettersPanel;
    [SerializeField] private GameObject booksPanel;
    [SerializeField] private GameObject seedsPanel;
    [SerializeField] private GameObject lettersCloseup;
    [SerializeField] private GameObject lettersButton;
    [SerializeField] private GameObject booksButton;
    [SerializeField] private GameObject seedsButton;
    [SerializeField] private Color activeColor;
    [SerializeField] private Color inactiveColor;
    [SerializeField] private GameObject buttonsContainer;

    public void inventoryInitialize()
    {
        showLettersPanel();
    }

    public void hidePanels()
    {
        booksPanel.SetActive(false);
        seedsPanel.SetActive(false);
        lettersPanel.SetActive(false);
        lettersCloseup.SetActive(false);
        buttonsContainer.SetActive(false);
    }

    public void showLettersPanel()
    {
        booksPanel.SetActive(false);
        seedsPanel.SetActive(false);
        lettersPanel.SetActive(true);
        lettersCloseup.SetActive(false);
        buttonsContainer.SetActive(true);

        lettersButton.GetComponent<Image>().color = activeColor;
        booksButton.GetComponent<Image>().color = inactiveColor;
        seedsButton.GetComponent<Image>().color = inactiveColor;
        lettersPanel.GetComponent<LetterContainer>().ShowLetters();
    }
    public void showBooksPanel()
    {
        lettersPanel.SetActive(false);
        seedsPanel.SetActive(false);
        booksPanel.SetActive(true);
        lettersCloseup.SetActive(false);
        buttonsContainer.SetActive(true);

        lettersButton.GetComponent<Image>().color = inactiveColor;
        booksButton.GetComponent<Image>().color = activeColor;
        seedsButton.GetComponent<Image>().color = inactiveColor;
        booksPanel.GetComponent<BookContainer>().ShowBooks();
    }
    public void showSeedsPanel()
    {
        booksPanel.SetActive(false);
        lettersPanel.SetActive(false);
        seedsPanel.SetActive(true);
        lettersCloseup.SetActive(false);
        buttonsContainer.SetActive(true);

        lettersButton.GetComponent<Image>().color = inactiveColor;
        booksButton.GetComponent<Image>().color = inactiveColor;
        seedsButton.GetComponent<Image>().color = activeColor;
        seedsPanel.GetComponent<ItemContainer>().ShowItems();
    }
}

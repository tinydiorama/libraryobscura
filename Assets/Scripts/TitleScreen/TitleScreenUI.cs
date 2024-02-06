using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreenUI : MonoBehaviour
{
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button continueButton;
    [SerializeField] private GameObject newGameConfirmPanel;

    public LevelLoader loader;

    private void Awake()
    {
        loader = LevelLoader.instance;
    }

    private void Start()
    {
        if ( ! DataPersistenceManager.instance.HasGameData() )
        {
            continueButton.gameObject.SetActive(false);
        } 
    }

    public void NewGame()
    {
        disableButtons();
        DataPersistenceManager.instance.NewGame();
        DataPersistenceManager.instance.SaveGame();
        loader.LoadLevel((int)SceneIndexes.MAIN_WORLD);
    }

    public void showConfirmNewGame()
    {
        if ( DataPersistenceManager.instance.HasGameData())
        { // show confirm panel
            newGameConfirmPanel.SetActive(true);
        } else
        { // can go straight to creating a new game because there's no game data already
            NewGame();
        }
    }

    public void hideConfirmNewGame()
    {
        newGameConfirmPanel.SetActive(false);
    }

    public void ContinueGame()
    {
        disableButtons();
        loader.LoadLevel((int)SceneIndexes.MAIN_WORLD, new Vector2(27.45f, -0.71316f));
    }

    public void QuitGame()
    {
        disableButtons();
        Application.Quit();
    }

    private void disableButtons()
    {
        newGameButton.interactable = false;
        continueButton.interactable = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreenUI : MonoBehaviour
{
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button continueButton;

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
        loader.LoadLevel((int)SceneIndexes.MAIN_WORLD);
    }

    public void ContinueGame()
    {
        disableButtons();
        loader.LoadLevel((int)SceneIndexes.MAIN_WORLD);
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

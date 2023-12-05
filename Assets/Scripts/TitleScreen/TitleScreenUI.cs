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
            EventSystem.current.SetSelectedGameObject(newGameButton.gameObject);
        } else
        {
            EventSystem.current.SetSelectedGameObject(continueButton.gameObject);
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

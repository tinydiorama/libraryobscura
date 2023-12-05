using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceManager : MonoBehaviour {

    [SerializeField] private GameObject settingsMenu;

    private GameManager gm;
    public static InterfaceManager instance { get; private set; }
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        gm = GameManager.GetInstance();
        if (!DialogueManager.GetInstance().dialogueIsPlaying && !gm.isInteractionsDisabled)
        {
            if (InputManager.GetInstance().GetSettingsPressed())
            {
                if ( settingsMenu.activeSelf )
                {
                    gm.isPaused = false;
                    settingsMenu.SetActive(false);
                } else if ( ! gm.isPaused )
                {
                    PlayerManager.instance.GetComponent<PlayerPlatformerController>().stopPlayer();
                    gm.isPaused = true;
                    settingsMenu.SetActive(true);
                }
            }
        }
    }
}

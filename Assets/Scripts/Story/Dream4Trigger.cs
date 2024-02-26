using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dream4Trigger : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cutsceneCam;

    [SerializeField] private GameObject introBG;
    [SerializeField] private GameObject introText1;
    [SerializeField] private GameObject introText2;
    [SerializeField] private GameObject panel;
    [SerializeField] private Item panacea;
    private TextMeshProUGUI text;
    private TextMeshProUGUI text2;

    public CinemachineVirtualCamera mainCam;
    private GameManager gm;
    private bool playerInRange;
    private GameObject player;
    private bool showingText;

    private void Update()
    {
        gm = GameManager.GetInstance();
        if (playerInRange && ! showingText)
        {
            showingText = true;
            gm.isPaused = true;
            player.GetComponent<PlayerPlatformerController>().stopPlayer();
            showText();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = true;
            player = collider.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }

    private void showText()
    {

        introBG.gameObject.SetActive(true);
        LeanTween.alpha(introBG.GetComponent<RectTransform>(), 0.8f, 2f).setOnComplete(() =>
        {
        });

        LeanTween.alphaCanvas(introText1.GetComponent<CanvasGroup>(), 1f, 5f).setOnComplete(() =>
        {
        });
        LeanTween.alphaCanvas(introText2.GetComponent<CanvasGroup>(), 1f, 5f).setDelay(2f).setOnComplete(() =>
        {
            StartCoroutine(continueGo());
        });
    }


    private IEnumerator continueGo()
    {
        yield return new WaitForSeconds(5f);
        fadeOut();
        StartCoroutine(showPanel());
    }

    private IEnumerator showPanel()
    {
        yield return new WaitForSeconds(4f);
        panel.SetActive(true);
    }

    public void hidePanel()
    {
        panel.SetActive(false);
        InventoryManager.instance.addItem(panacea);
        gm.showNightFade();
        StartCoroutine(cleanupTrigger());
    }
    private IEnumerator cleanupTrigger()
    {
        yield return new WaitForSeconds(2.5f);
        cutsceneCam.gameObject.SetActive(false);
        mainCam.gameObject.SetActive(true);
        player.GetComponent<PlayerPlatformerController>().loudFootsteps = false;
        CutsceneManager.instance.cleanupCutscene();
    }

    private void fadeOut()
    {
        LeanTween.alphaCanvas(introText1.GetComponent<CanvasGroup>(), 0f, 5f).setOnComplete(() =>
        {
        });
        LeanTween.alphaCanvas(introText2.GetComponent<CanvasGroup>(), 0f, 5f).setOnComplete(() =>
        {
        });

        LeanTween.alpha(introBG.GetComponent<RectTransform>(), 0, 5f).setOnComplete(() =>
        {
            introBG.gameObject.SetActive(false);
        });
    }
}

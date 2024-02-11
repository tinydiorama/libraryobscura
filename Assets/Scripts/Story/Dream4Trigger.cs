using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Progress;

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

        introText1.gameObject.SetActive(true);
        text = introText1.GetComponent<TextMeshProUGUI>();
        var color = text.color;
        var fadeincolor = color;
        fadeincolor.a = 1;
        LeanTween.value(introText1.gameObject, updateColorValueCallback, color, fadeincolor, 20f).setEase(LeanTweenType.easeOutElastic).setDelay(2f);
        text2 = introText2.GetComponent<TextMeshProUGUI>();
        LeanTween.value(introText2.gameObject, updateColorValueCallback2, color, fadeincolor, 20f).setEase(LeanTweenType.easeOutElastic).setDelay(7f);


        StartCoroutine(continueGo());
    }

    private void updateColorValueCallback(Color val)
    {
        text.color = val;
    }

    private void updateColorValueCallback2(Color val)
    {
        text2.color = val;
    }

    private IEnumerator continueGo()
    {
        yield return new WaitForSeconds(7f);
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
        AudioManager.GetInstance().StartPlaylist();
        text = introText1.GetComponent<TextMeshProUGUI>();
        var color = text.color;
        var fadeoutcolor = color;
        fadeoutcolor.a = 0;
        LeanTween.value(introText1.gameObject, updateColorValueCallback, color, fadeoutcolor, 10f).setEase(LeanTweenType.easeOutBack).setOnComplete(() =>
        {
            introText1.gameObject.SetActive(false);
        });
        text2 = introText2.GetComponent<TextMeshProUGUI>();
        LeanTween.value(introText2.gameObject, updateColorValueCallback2, color, fadeoutcolor, 10f).setEase(LeanTweenType.easeOutBack).setDelay(1f).setOnComplete(() =>
        {
            introText2.gameObject.SetActive(false);
        });

        LeanTween.alpha(introBG.GetComponent<RectTransform>(), 0, 2f).setDelay(3f).setOnComplete(() =>
        {
            introBG.gameObject.SetActive(false);
        });
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndingSequenceLetter : MonoBehaviour
{
    [SerializeField] private GameObject overlay;
    [SerializeField] private GameObject endingText1;
    [SerializeField] private GameObject endingText2;
    [SerializeField] private GameObject endingArrow;

    private bool allowContinue;
    private TextMeshProUGUI text;
    private TextMeshProUGUI text2;

    private StoryManager sm;

    public void Start()
    {
        sm = StoryManager.instance;
    }

    public void showEndingTextLetter(string displayText1, string displayText2)
    {

        GameManager.GetInstance().isPaused = true;
        overlay.gameObject.SetActive(true);
        LeanTween.alpha(overlay.GetComponent<RectTransform>(), 0.8f, 2f).setOnComplete(() =>
        {
        });

        endingText1.GetComponent<TextMeshProUGUI>().text = displayText1;
        endingText2.GetComponent<TextMeshProUGUI>().text = displayText2;


        LeanTween.alphaCanvas(endingText1.GetComponent<CanvasGroup>(), 1f, 5f).setOnComplete(() =>
        {
        });

        LeanTween.alphaCanvas(endingText2.GetComponent<CanvasGroup>(), 1f, 5f).setDelay(2f).setOnComplete(() =>
        {
            endingArrow.SetActive(true);
            LeanTween.alpha(endingArrow.GetComponent<RectTransform>(), 1, 2f).setOnComplete(() =>
            {
                StartCoroutine(continueGo());
            });
        });

        

    }

    private IEnumerator continueGo()
    {
        yield return new WaitForSeconds(0.2f);
        allowContinue = true;
    }

    private void Update()
    {
        if (allowContinue)
        {
            if (InputManager.GetInstance().GetInteractPressed())
            {
                allowContinue = false;
                fadeOut();
            }
        }
    }
    private void fadeOut()
    {
        LeanTween.alphaCanvas(endingText1.GetComponent<CanvasGroup>(), 0f, 5f).setOnComplete(() =>
        {
        });
        LeanTween.alphaCanvas(endingText2.GetComponent<CanvasGroup>(), 0f, 5f).setOnComplete(() =>
        {
        });

        LeanTween.alpha(endingArrow.GetComponent<RectTransform>(), 0, 1f).setOnComplete(() =>
        {
            endingArrow.gameObject.SetActive(false);
        });

        LeanTween.alpha(overlay.GetComponent<RectTransform>(), 0, 5f).setOnComplete(() =>
        {
            overlay.gameObject.SetActive(false);
            GameManager.GetInstance().isPaused = false;
        });
    }
}

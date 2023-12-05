using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IntroCutscene : MonoBehaviour
{
    [SerializeField] private GameObject introBG;
    [SerializeField] private GameObject introText1;
    [SerializeField] private GameObject introText2;
    [SerializeField] private GameObject introArrow;

    private bool allowContinue;
    private TextMeshProUGUI text;
    private TextMeshProUGUI text2;

    private StoryManager sm;

    public void Start()
    {
        sm = StoryManager.instance;
        if (! sm.cutscene0Triggered)
        {
            GameManager.GetInstance().isPaused = true;
            introBG.SetActive(true);

            introText1.gameObject.SetActive(true);
            text = introText1.GetComponent<TextMeshProUGUI>();
            var color = text.color;
            var fadeincolor = color;
            fadeincolor.a = 1;
            LeanTween.value(introText1.gameObject, updateColorValueCallback, color, fadeincolor, 20f).setEase(LeanTweenType.easeOutElastic).setDelay(2f);
            text2 = introText2.GetComponent<TextMeshProUGUI>();
            LeanTween.value(introText2.gameObject, updateColorValueCallback2, color, fadeincolor, 20f).setEase(LeanTweenType.easeOutElastic).setDelay(5f);


            introArrow.SetActive(true);
            LeanTween.alpha(introArrow.GetComponent<RectTransform>(), 1, 2f).setDelay(6f);

            StartCoroutine(continueGo());

        }
        else
        {
            AudioManager.GetInstance().StartPlaylist();
        }
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
        yield return new WaitForSeconds(5f);
        allowContinue = true;
    }

    private void Update()
    {
        if (allowContinue && ! sm.cutscene0Triggered)
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
        sm.cutscene0Triggered = true;
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

        LeanTween.alpha(introArrow.GetComponent<RectTransform>(), 0, 1f).setDelay(1f).setOnComplete(() =>
        {
            introArrow.gameObject.SetActive(false);
        });

        LeanTween.alpha(introBG.GetComponent<RectTransform>(), 0, 2f).setDelay(3f).setOnComplete(() =>
        {
            introBG.gameObject.SetActive(false);
            GameManager.GetInstance().isPaused = false;
        });
    }
}

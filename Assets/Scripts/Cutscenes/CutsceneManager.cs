using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour, iDataPersistence
{
    public bool cutscene0Triggered;
    public bool cutscene1Triggered;
    public bool cutscene2Triggered;
    public bool cutscene3Triggered;
    public bool mailboxInteract1;
    public bool buyAllowed;
    public bool sellAllowed;

    [SerializeField] private GameObject introBG;
    [SerializeField] private GameObject introText1;
    [SerializeField] private GameObject introText2;
    [SerializeField] private GameObject introArrow;
    [SerializeField] private GameObject figure;

    private bool allowContinue;

    public void LoadData(GameData data)
    {
        this.mailboxInteract1 = data.initialMailbox;
        this.cutscene0Triggered = data.cutscene0triggered;
        this.cutscene1Triggered = data.cutscene1triggered;
        this.cutscene2Triggered = data.cutscene2triggered;
        this.cutscene3Triggered = data.cutscene3triggered;
        this.buyAllowed = data.buyAllowed;
        this.sellAllowed = data.sellAllowed;

        if (this.cutscene2Triggered)
        {
            figure.SetActive(false);
        } else
        {
            figure.SetActive(true);
        }
        if ( this.buyAllowed )
        {
            GameManager.GetInstance().showMoneyUI();
        }
    }

    public void SaveData(ref GameData data)
    {
        data.initialMailbox = this.mailboxInteract1;
        data.cutscene0triggered = this.cutscene0Triggered;
        data.cutscene1triggered = this.cutscene1Triggered;
        data.cutscene2triggered = this.cutscene2Triggered;
        data.cutscene3triggered = this.cutscene3Triggered;
        data.buyAllowed = this.buyAllowed;
        data.sellAllowed = this.sellAllowed;
    }

    public void Start()
    {
        if (!cutscene0Triggered)
        {
            introBG.SetActive(true);
            StartCoroutine(startText1());
        } else
        {
            AudioManager.GetInstance().StartPlaylist();
        }
    }
    private IEnumerator startText1()
    {
        yield return new WaitForSeconds(1f);
        introText1.SetActive(true);
        StartCoroutine(startText2());
    }
    private IEnumerator startText2()
    {
        yield return new WaitForSeconds(3f);
        introText2.SetActive(true);
        StartCoroutine(ShowArrow());
    }
    private IEnumerator ShowArrow()
    {
        yield return new WaitForSeconds(4f);
        introArrow.SetActive(true);
        allowContinue = true;
    }

    private void Update()
    {
        if (allowContinue && ! cutscene0Triggered )
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                allowContinue = false;
                introText1.GetComponent<Animator>().SetBool("FadeOut", true);
                StartCoroutine(fadeText1());
            }
        }
    }
    private IEnumerator fadeText1()
    {
        yield return new WaitForSeconds(3f);
        AudioManager.GetInstance().StartPlaylist();
        StartCoroutine(fadeText2());
    }
    private IEnumerator fadeText2()
    {
        introText2.GetComponent<Animator>().SetBool("FadeOut", true);
        introArrow.GetComponent<Animator>().SetBool("FadeOut", true);
        yield return new WaitForSeconds(3f);
        StartCoroutine(fadeBG());
    }
    private IEnumerator fadeBG()
    {
        introBG.GetComponent<Animator>().SetBool("FadeOut", true);
        yield return new WaitForSeconds(2f);
        cutscene0Triggered = true;
        introBG.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneTrigger2 : MonoBehaviour
{
    [SerializeField] private GameObject figure;

    private GameManager gm;
    private float m_CurrentClipLength;

    private void Start()
    {
        gm = GameManager.GetInstance();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!StoryManager.instance.cutscene2Triggered)
        {
            gm.isPaused = true;
            figure.GetComponent<Animator>().SetBool("Leave", true);
            AnimatorClipInfo[] animController = figure.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0);

            m_CurrentClipLength = animController[0].clip.length;
            StartCoroutine(animateFigure());
        }
    }

    IEnumerator animateFigure()
    {
        yield return new WaitForSeconds(2f);
        gm.isPaused = false;
        figure.SetActive(false);
        StoryManager.instance.cutscene2Triggered = true;
    }
}

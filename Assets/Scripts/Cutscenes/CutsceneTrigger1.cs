using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class CutsceneTrigger1 : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera mainCam;
    [SerializeField] private CinemachineVirtualCamera cutsceneCam;
    private GameManager gm;
    private float m_CurrentClipLength;

    private void Start()
    {
        gm = GameManager.GetInstance();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( ! gm.cutsceneManager.cutscene1Triggered )
        {
            gm.isPaused = true;
            mainCam.gameObject.SetActive(false);
            cutsceneCam.gameObject.SetActive(true);

            AnimatorClipInfo[] animController = cutsceneCam.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0);

            m_CurrentClipLength = animController[0].clip.length;
            StartCoroutine(hideCutscene());
        }
    }

    IEnumerator hideCutscene()
    {
        yield return new WaitForSeconds(m_CurrentClipLength);
        gm.isPaused = false;
        cutsceneCam.gameObject.SetActive(false);
        mainCam.gameObject.SetActive(true);
        gm.cutsceneManager.cutscene1Triggered = true;
    }
}

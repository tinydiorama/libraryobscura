using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

public class Dream4Manager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera mainCam;
    [SerializeField] private CinemachineVirtualCamera cutsceneCam;
    [SerializeField] private GameObject dreamTrigger;
    private GameManager gm;
    private Bloom blm;
    private Vignette vnt;

    public void startDream(GameObject cameraCollider, GameObject player, GameObject world, Volume globalVolume, Light2D globalLight, CinemachineVirtualCamera vcam)
    {
        mainCam = GameObject.FindWithTag("VirtualCamera").GetComponent<CinemachineVirtualCamera>();
        Bloom temp;
        if (globalVolume.profile.TryGet<Bloom>(out temp))
        {
            blm = temp;
        }
        Vignette vig;
        if (globalVolume.profile.TryGet<Vignette>(out vig))
        {
            vnt = vig;
        }
        gm = GameManager.GetInstance();
        gm.isStopTime = true;

        player.GetComponent<PlayerPlatformerController>().maxSpeed = 2;
        blm.intensity.Override(90f);
        blm.threshold.Override(0.75f);
        blm.tint.Override(new Color(0.4f, 0.6f, 1f));
        vnt.active = false;
        globalLight.intensity = 0.5f;
        gm.isInteractionsDisabled = true;

        //world.SetActive(false);
        Vector2 newPos = new Vector2(227.87f, -5.84f);
        Vector2 posDelta = newPos - (Vector2)player.transform.position;

        player.transform.position = new Vector3(227.87f, -5.84f, 0);
        player.GetComponent<PlayerPlatformerController>().faceRight();
        vcam.OnTargetObjectWarped(player.transform, posDelta);
        cutsceneCam.m_LookAt = player.transform;
        cutsceneCam.m_Follow = player.transform;
        dreamTrigger.GetComponent<Dream4Trigger>().mainCam = mainCam;
        mainCam.gameObject.SetActive(false);
        cutsceneCam.gameObject.SetActive(true);
        StartCoroutine(fadeOut());
    }

    private IEnumerator fadeOut()
    {
        yield return new WaitForSeconds(2.5f);
        GameManager.GetInstance().hideNightFade();
    }
}

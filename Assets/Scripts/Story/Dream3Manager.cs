using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Dream3Manager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera mainCam;
    [SerializeField] private CinemachineVirtualCamera cutsceneCam;
    [SerializeField] private GameObject dreamTrigger;
    private GameManager gm;
    private Vignette vnt;

    public void startDream(GameObject cameraCollider, GameObject player, GameObject world, Volume globalVolume, Light2D globalLight, CinemachineVirtualCamera vcam)
    {
        mainCam = GameObject.FindWithTag("VirtualCamera").GetComponent<CinemachineVirtualCamera>();
        Vignette temp;
        if (globalVolume.profile.TryGet<Vignette>(out temp))
        {
            vnt = temp;
        }
        gm = GameManager.GetInstance();
        gm.isStopTime = true;

        player.GetComponent<PlayerPlatformerController>().maxSpeed = 2;
        player.GetComponent<PlayerPlatformerController>().faceLeft();
        vnt.intensity.Override(0.6f);
        vnt.smoothness.Override(0.4f);
        globalLight.intensity = 0.5f;
        gm.isInteractionsDisabled = true;

        //world.SetActive(false);
        Vector2 newPos = new Vector2(204f, 0.31f);
        Vector2 posDelta = newPos - (Vector2)player.transform.position;

        player.transform.position = new Vector3(204f, 0.31f, 0);
        player.GetComponent<PlayerPlatformerController>().loudFootsteps = true;
        player.GetComponent<PlayerPlatformerController>().faceRight();
        vcam.OnTargetObjectWarped(player.transform, posDelta);
        cutsceneCam.m_LookAt = player.transform;
        cutsceneCam.m_Follow = player.transform;
        dreamTrigger.GetComponent<Dream3Trigger>().mainCam = mainCam;
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

using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
using Unity.VisualScripting;

public class Dream2Manager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera mainCam;
    [SerializeField] private CinemachineVirtualCamera cutsceneCam;
    [SerializeField] private Dream2Trigger dreamTrigger;
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
        Vector2 newPos = new Vector2(206.43f, 9.45f);
        Vector2 posDelta = newPos - (Vector2)player.transform.position;

        player.transform.position = new Vector3(206.43f, 9.45f, 0);
        vcam.OnTargetObjectWarped(player.transform, posDelta);
        cutsceneCam.m_LookAt = player.transform;
        cutsceneCam.m_Follow = player.transform;
        dreamTrigger.mainCam = mainCam;
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

using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
using Cinemachine;

public class Dream1Manager : MonoBehaviour
{
    [SerializeField] private GameObject dreamTrigger;
    private GameManager gm;
    private Vignette vnt;

    public void startDream(GameObject cameraCollider, GameObject player, GameObject world, Volume globalVolume, Light2D globalLight, CinemachineVirtualCamera vcam)
    {
        Vignette temp;
        if (globalVolume.profile.TryGet<Vignette>(out temp))
        {
            vnt = temp;
        }
        gm = GameManager.GetInstance();
        gm.isStopTime = true;

        player.GetComponent<PlayerPlatformerController>().maxSpeed = 1;
        player.GetComponent<PlayerPlatformerController>().faceLeft();
        vnt.intensity.Override(0.6f);
        vnt.smoothness.Override(0.4f);
        globalLight.intensity = 0.5f;
        gm.isInteractionsDisabled = true;

        //world.SetActive(false);
        Vector2 newPos = new Vector2(158.74f, -1.97f);
        Vector2 posDelta = newPos - (Vector2)player.transform.position;

        player.transform.position = new Vector3(158.74f, -1.97f, 0);
        cameraCollider.transform.position = new Vector3(157.1f, 4.3f, 0);
        vcam.OnTargetObjectWarped(player.transform, posDelta);
        StartCoroutine(fadeOut());
    }

    private IEnumerator fadeOut()
    {
        yield return new WaitForSeconds(2.5f);
        dreamTrigger.SetActive(true);
        GameManager.GetInstance().hideNightFade();
    }
}

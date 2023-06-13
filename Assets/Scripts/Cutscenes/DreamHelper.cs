using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class DreamHelper : MonoBehaviour
{
    [SerializeField] private GameObject playerPosition;
    [SerializeField] private GameObject playerBedPosition;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private Volume globalVolume;
    [SerializeField] private Light2D globalLight;
    [SerializeField] private GameObject hud;

    //dream 1
    [SerializeField] private GameObject backyardCollider;
    [SerializeField] private GameObject knockPlayer;

    private GameManager gm;
    public Vignette vnt;

    private void Start()
    {
        Vignette temp;
        if (globalVolume.profile.TryGet<Vignette>(out temp))
        {
            vnt = temp;
        }
    }
    public void setupDream1()
    {
        gm = GameManager.GetInstance();
        gm.isStopTime = true;
        mainCamera.transform.position = playerPosition.transform.position;
        gm.player.transform.position = playerPosition.transform.position;
        gm.player.GetComponent<PlayerPlatformerController>().maxSpeed = 1;
        gm.player.GetComponent<PlayerPlatformerController>().faceLeft();
        vnt.intensity.Override(0.6f);
        vnt.smoothness.Override(0.4f);
        globalLight.intensity = 0.5f;
        gm.disableInteractions = true;
        backyardCollider.SetActive(true);
        knockPlayer.SetActive(true);
        hud.SetActive(false);

        // player will walk until hitting KnockDreamTrigger
    }

    public void endDream1()
    {
        gm = GameManager.GetInstance();
        gm.isStopTime = false;
        mainCamera.transform.position = playerBedPosition.transform.position;
        gm.player.transform.position = playerBedPosition.transform.position;
        gm.player.GetComponent<PlayerPlatformerController>().maxSpeed = gm.player.GetComponent<PlayerPlatformerController>().defaultSpeed;

        vnt.intensity.Override(0.508f);
        vnt.smoothness.Override(0.171f);
        globalLight.intensity = 1f;
        gm.disableInteractions = false;
        backyardCollider.SetActive(false);
        knockPlayer.SetActive(false);
        hud.SetActive(true);

        StartCoroutine(gm.startNewDay());
    }
}

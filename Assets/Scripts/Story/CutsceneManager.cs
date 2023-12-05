using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
using Cinemachine;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] private GameObject cameraCollider;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject world;
    [SerializeField] private CinemachineVirtualCamera vcam;

    [SerializeField] private Volume globalVolume;
    [SerializeField] private Light2D globalLight;
    [SerializeField] private GameObject hud;
    private Vignette vnt;

    private void Start()
    {
        Vignette temp;
        if (globalVolume.profile.TryGet<Vignette>(out temp))
        {
            vnt = temp;
        }
    }

    public static CutsceneManager instance { get; private set; }
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            Debug.Log("more than one player manager");
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void loadCutscene1()
    {
        hud.SetActive(false);
        GameObject cutscene = InstantiateResource("Cutscenes", "Dream1");
        cutscene.GetComponent<Dream1Manager>().startDream(cameraCollider, player, world, globalVolume, globalLight, vcam);
    }

    public void loadCutscene2()
    {
        hud.SetActive(false);
        GameObject cutscene = InstantiateResource("Cutscenes", "Dream2");
        cutscene.GetComponent<Dream2Manager>().startDream(cameraCollider, player, world, globalVolume, globalLight, vcam);

    }

    public void cleanupCutscene()
    {
        // reset everything
        Vector2 newPos = new Vector2(27.45f, -1.97f);
        Vector2 posDelta = newPos - (Vector2)player.transform.position;
        GameManager gm = GameManager.GetInstance();
        world.SetActive(true);
        gm.isStopTime = false;
        player.transform.position = newPos;
        cameraCollider.transform.position = new Vector3(50.179f, 3.400905f, 0.009863324f);
        vcam.OnTargetObjectWarped(player.transform, posDelta);
        player.GetComponent<PlayerPlatformerController>().maxSpeed = player.GetComponent<PlayerPlatformerController>().defaultSpeed;
        StartCoroutine(afterMoveCleanup());
    }

    private IEnumerator afterMoveCleanup()
    {
        GameManager gm = GameManager.GetInstance();
        yield return new WaitForSeconds(4f);
        vnt.intensity.Override(0.508f);
        vnt.smoothness.Override(0.171f);
        globalLight.intensity = 1f;
        gm.isInteractionsDisabled = false;
        hud.SetActive(true);

        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        StartCoroutine(gm.startNewDay());
    }

    public GameObject InstantiateResource(string folder, string name)
    {
        GameObject resource = Instantiate<GameObject>(Resources.Load<GameObject>(folder + "/" + name), this.transform);
        if (resource == null)
        {
            Debug.LogErrorFormat("Cannot find resource {0} in {1}", name, folder);
            return null;
        }
        resource.name = name;
        return resource;
    }
}

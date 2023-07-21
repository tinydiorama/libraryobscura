using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCutscene : Interactable
{
    [SerializeField] private GameObject player;
    [SerializeField] private CinemachineVirtualCamera mainCam;
    [SerializeField] private CinemachineVirtualCamera cutsceneCam;
    public override void interact()
    {
        mainCam.gameObject.SetActive(false);
        cutsceneCam.gameObject.SetActive(true);
        player.transform.position = new Vector3(206.43f, 9.45f, 0);
    }
}

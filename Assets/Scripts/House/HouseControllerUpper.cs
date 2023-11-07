using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseControllerUpper : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera vcam;

    private Animator anim;

    private void Start()
    {
        anim = vcam.GetComponent<Animator>();
    }

    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (anim != null)
        {
            anim.SetBool("ZoomInUpper", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (anim != null)
        {
            anim.SetBool("ZoomInUpper", false);
        }
    }
}

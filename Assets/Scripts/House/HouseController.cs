using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseController : MonoBehaviour
{
    [SerializeField] private GameObject[] unlockedRooms;
    [SerializeField] private CinemachineVirtualCamera vcam;

    private Animator anim;
    private bool inHouse;

    private void Start()
    {
        anim = vcam.GetComponent<Animator>();
        inHouse = false;
    }

    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (anim != null)
        {
            anim.SetBool("ZoomIn", true);
            foreach (GameObject room in unlockedRooms)
            {
                room.GetComponent<Animator>().SetBool("FadeOut", true);
                StartCoroutine(fadeRoom(room));
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if ( anim != null )
        {
            anim.SetBool("ZoomIn", false);
            foreach (GameObject room in unlockedRooms)
            {
                room.SetActive(true);
            }
        }
    }

    IEnumerator fadeRoom(GameObject room)
    {
        yield return new WaitForSeconds(0.9f);
        room.SetActive(false);
    }
}

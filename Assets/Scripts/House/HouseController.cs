using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HouseController : MonoBehaviour
{
    [SerializeField] private List<GameObject> unlockedRooms;
    [SerializeField] private CinemachineVirtualCamera vcam;

    [SerializeField] private GameObject upstairsLibrary;
    [SerializeField] private GameObject upstairsStudy;
    [SerializeField] private GameObject thirdfloorCover;

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

    public void unlockLibrary()
    {
        upstairsLibrary.GetComponent<Animator>().SetBool("FadeOut", true);
        upstairsStudy.GetComponent<Animator>().SetBool("FadeOut", true);
        StartCoroutine(fadeRoom(upstairsLibrary));
        StartCoroutine(fadeRoom(upstairsStudy));
        unlockedRooms.Add(upstairsLibrary);
        unlockedRooms.Add(upstairsStudy);
    }

    public void addLibrary()
    {
        unlockedRooms.Add(upstairsLibrary);
        unlockedRooms.Add(upstairsStudy);
    }

    public void unlockThirdFloor()
    {
        thirdfloorCover.GetComponent<Animator>().SetBool("FadeOut", true);
        StartCoroutine(fadeRoom(thirdfloorCover));
        unlockedRooms.Add(thirdfloorCover);
    }

    IEnumerator fadeRoom(GameObject room)
    {
        yield return new WaitForSeconds(0.9f);
        room.SetActive(false);
    }
}

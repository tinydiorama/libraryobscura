using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorUI : MonoBehaviour
{
    [SerializeField] private ElevatorUIItem[] elevatorUIButtons;
    [SerializeField] private Vector3 floor1Pos = new Vector3(18.44929f, -2.79659f, 0);
    [SerializeField] private Vector3 floor2Pos = new Vector3(18.44929f, 0.2506582f, 0);
    [SerializeField] private Vector3 floor3Pos = new Vector3(18.44929f, 2.95f, 0);

    public Elevator currentElevator;

    private StoryManager sm;

    public void setupElevator(int myFloor, Elevator setElevator)
    {
        sm = StoryManager.instance;
        currentElevator = setElevator;
        foreach (ElevatorUIItem elevatorUIItem in elevatorUIButtons)
        {
            if ((elevatorUIItem.floorIndex == myFloor) ||
                (elevatorUIItem.floorIndex == 1 && !sm.floor2Unlocked) ||
                (elevatorUIItem.floorIndex == 2 && !sm.floor3Unlocked) ||
                (elevatorUIItem.floorIndex == 3 && !sm.floor4Unlocked))
            {
                elevatorUIItem.gameObject.SetActive(false);
            } else
            {
                elevatorUIItem.gameObject.SetActive(true);
            }
        }
    }

    public void toggleElevator(int floorIndex)
    {
        currentElevator.gotoFloor(floorIndex);
        gameObject.SetActive(false);
    }
}

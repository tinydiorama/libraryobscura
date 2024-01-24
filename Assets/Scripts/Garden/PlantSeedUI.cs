using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlantSeedUI : MonoBehaviour
{

    public FarmController farmController;
    public bool isButtonsEnabled;

    private void Start()
    {
        StartCoroutine(enableButtons());
    }

    private void OnEnable()
    {
        StartCoroutine(enableButtons());
    }

    private void Update()
    {
        if ( isButtonsEnabled )
        {
            if (InputManager.GetInstance().GetClosePressed())
            {
                isButtonsEnabled = false;
                farmController.CloseSeedMenu();
            }
            else if (InputManager.GetInstance().GetConfirmPressed())
            {
                isButtonsEnabled = false;
                farmController.plantSeed();
            }
        }
    }

    private IEnumerator enableButtons()
    {
        yield return new WaitForSeconds(0.2f);
        isButtonsEnabled = true;
    }
}

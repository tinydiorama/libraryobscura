using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmController : MonoBehaviour {

    [SerializeField] private GardenPlot[] gardenPlots;
    [SerializeField] private GameObject notifContainer;
    [SerializeField] private GameObject selectSeedContainer;

    private GameManager gm;
    public GardenPlot activeGardenPlot;
    private void Start()
    {
        gm = GameManager.GetInstance();
    }

    public void CloseSeedMenu()
    {
        notifContainer.SetActive(false);
        selectSeedContainer.SetActive(false);
        gm.isPaused = false;
    }
    public void plantSeed()
    {
        notifContainer.SetActive(false);
        selectSeedContainer.SetActive(false);
        gm.isPaused = false;
        activeGardenPlot.plantSeed();
    }
}

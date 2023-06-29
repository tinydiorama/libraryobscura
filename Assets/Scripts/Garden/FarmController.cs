using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmController : MonoBehaviour, iDataPersistence
{

    [SerializeField] private GardenPlot[] gardenPlots;
    [SerializeField] private GameObject plantSeedUI;
    public GardenPlot activeGardenPlot;

    private GameManager gm;

    private void Start()
    {
        gm = GameManager.GetInstance();
        gm.onEndOfDay += advanceSeeds;
    }

    public void CloseSeedMenu()
    {
        plantSeedUI.SetActive(false);
        gm.isPaused = false;
    }
    public void plantSeed()
    {
        plantSeedUI.SetActive(false);
        gm.isPaused = false;
        activeGardenPlot.plantSeed();
    }

    public void advanceSeeds()
    {
        foreach ( GardenPlot plot in gardenPlots)
        {

            plot.GetComponent<HighlightShowController>().enableHighlight();

            if ( plot.state == (int)PlantState.TILLED )
            {
                if ( plot.watered )
                {
                    plot.watered = false;
                } else
                {
                    plot.setStateDirt();
                }
            } else if (plot.state == (int)PlantState.PLANTED1 )
            {
                if ( plot.watered )
                {
                    plot.setStatePlant2();
                } else
                {
                    plot.setStatePlantDead();
                }
            } else if (plot.state == (int)PlantState.PLANTED2 )
            {
                if (plot.watered)
                {
                    plot.setStatePlant3();
                }
                else
                {
                    plot.setStatePlantDead();
                }
            } else if ( plot.state == (int)PlantState.PLANTED3 )
            {
                if (plot.watered)
                {
                    plot.setStatePlant4();
                }
                else
                {
                    plot.setStatePlantDead();
                }
            }
        }
    }
    public void LoadData(GameData data)
    {
        var index = 0;
        gm = GameManager.GetInstance();
        foreach (GardenPlot plot in gardenPlots)
        {
            string seedId;
            if ( data.seedId.Count > 0 )
            {
                seedId = data.seedId[index];
                if (seedId != "") // plant exists
                {
                    for (int i = 0; i < InventoryManager.instance.itemsDatabase.Count; i++)
                    {
                        if (InventoryManager.instance.itemsDatabase[i].id == seedId)
                        {
                            plot.growingSeed = new ItemSlot(InventoryManager.instance.itemsDatabase[i], 1);
                        }
                    }
                    if (data.state[index] == (int)PlantState.TILLED)
                    {
                        plot.setStateTilled();
                    }
                    else if (data.state[index] == (int)PlantState.PLANTED1)
                    {
                        plot.setStatePlant1();
                    }
                    else if (data.state[index] == (int)PlantState.PLANTED2)
                    {
                        plot.setStatePlant2();
                    }
                    else if (data.state[index] == (int)PlantState.PLANTED3)
                    {
                        plot.setStatePlant3();
                    }
                    else if (data.state[index] == (int)PlantState.READYFORHARVEST)
                    {
                        plot.setStatePlant4();
                    }
                    if (data.state[index] == (int)PlantState.DEAD)
                    {
                        plot.setStatePlantDead();
                    }
                }
                index++;
            }
        }
    }

    public void SaveData(ref GameData data)
    {
        var index = 0;
        data.seedId.Clear();
        data.state.Clear();
        data.watered.Clear();
        foreach (GardenPlot plot in gardenPlots)
        {
            if (plot.growingSeed.item != null)
            {
                data.seedId.Add(plot.growingSeed.item.id);
                data.state.Add(plot.state);
                data.watered.Add(plot.watered);
            } else
            {
                data.seedId.Add(null);
                data.state.Add(0);
                data.watered.Add(false);
            }
            index++;
        }
    }
}

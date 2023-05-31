using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Xml;
using UnityEngine.UI;
using static UnityEditor.Progress;

public enum PlantState { 
    DIRT = 0,
    TILLED = 1,
    PLANTED1 = 2,
    PLANTED2 = 3,
    READYFORHARVEST = 4,
    DEAD = -1
};

public class GardenPlot : Interactable
{
    [SerializeField] private FarmController fm;
    [SerializeField] private Sprite tilledSprite;
    [SerializeField] private Sprite wateredSoil;
    [SerializeField] private TextMeshProUGUI promptText;
    [SerializeField] private SpriteRenderer sr;

    [SerializeField] private GameObject notifContainer;
    [SerializeField] private GameObject selectSeedContainer;
    [SerializeField] private GameObject seedDisplay;
    [SerializeField] private GameObject noSeedMessage;
    [SerializeField] private Button plantButton;
    [SerializeField] private GameObject seedSelectPrefab;
    [SerializeField] private Color selectedColor;
    [SerializeField] private Color neutralColor;

    [SerializeField] private SpriteRenderer plantImage;
    [SerializeField] private Sprite witheredImage;

    private ItemSlot seedSelected;
    public ItemSlot growingSeed;
    private Button seedSelectedUI;

    public int state;
    public bool watered;

    private GameManager gm;

    private void Start()
    {
        //state = (int)PlantState.DIRT;
        gm = GameManager.GetInstance();
    }

    public override IEnumerator Interact(PlayerController player)
    {

        if ( state == (int)PlantState.DIRT )
        {
            setStateTilled();
        } else if ( state == (int)PlantState.TILLED )
        {
            //GetComponent<HighlightShowController>().disableHighlight();
            //GetComponent<HighlightShowController>().hideHighlight();
            showSeedSelect();
        } else if ( (state == (int)PlantState.PLANTED1 || state == (int)PlantState.PLANTED2) && ! watered)
        {
            waterPlant();
        } else if ( state == (int)PlantState.DEAD )
        {
            setStateDirt();
        }
        yield return new WaitForSeconds(0.2f);
        resetInteraction(player);
    }

    public void waterPlant()
    {
        watered = true;
        sr.sprite = wateredSoil;
        GetComponent<HighlightShowController>().disableHighlight();
        GetComponent<HighlightShowController>().hideHighlight();
    }

    public void setStateDirt()
    {
        state = (int)PlantState.DIRT;
        promptText.text = "Plow";
        watered = false;
        sr.sprite = null;
    }

    public void setStateTilled()
    {
        sr.sprite = tilledSprite;
        state = (int)PlantState.TILLED;
        watered = false;
        promptText.text = "Plant";
    }

    public void setStatePlant1()
    {
        sr.sprite = tilledSprite;
        state = (int)PlantState.PLANTED1;
        plantImage.sprite = growingSeed.item.seedImages[0];
        watered = false;
        promptText.text = "Water";
    }

    public void setStatePlant2()
    {
        sr.sprite = tilledSprite;
        plantImage.sprite = growingSeed.item.seedImages[1];
        state = (int)PlantState.PLANTED2;
        watered = false;
        promptText.text = "Water";
    }
    public void setStatePlant3()
    {
        sr.sprite = tilledSprite;
        plantImage.sprite = growingSeed.item.seedImages[2];
        state = (int)PlantState.READYFORHARVEST;
        watered = false;
        promptText.text = "Harvest";
    }
    public void setStatePlantDead()
    {
        sr.sprite = tilledSprite;
        plantImage.sprite = witheredImage;
        state = (int)PlantState.DEAD;
        watered = false;
        promptText.text = "Clear";
    }

    private void showSeedSelect()
    {
        notifContainer.SetActive(true);
        selectSeedContainer.SetActive(true);
        gm.isPaused = true;

        foreach (Transform child in seedDisplay.transform)
        {
            if ( child.name != "NoSeeds" )
            {
                Destroy(child.gameObject);
            }
        }
        int j = 0;
        InventoryManager invManage = gm.inventoryManager;
        if ( invManage.items.Count > 0 )
        {
            noSeedMessage.SetActive(false);
            plantButton.interactable = true;
        } else
        {
            noSeedMessage.SetActive(true);
            plantButton.interactable = false;
        }
        for (int i = 0; i < invManage.items.Count; i++)
        {
            if (invManage.items[i].item.category.ToString() == "Seed")
            {
                GameObject seedInstance = Instantiate(seedSelectPrefab, seedDisplay.transform);
                seedInstance.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = invManage.items[i].count + " " + invManage.items[i].item.itemName;

                ItemSlot tempSeed = invManage.items[i];
                seedInstance.GetComponent<Button>().onClick.AddListener(delegate { selectSeed(ref seedInstance, ref tempSeed); });
                if ( j == 0 ) // first seed
                {
                    selectSeed(ref seedInstance, ref tempSeed);
                }
                j++;
            }
        }
    }

    private void selectSeed(ref GameObject seedInstance, ref ItemSlot seedToSelect)
    {
        ColorBlock colorBlock;
        if (seedSelectedUI != null )
        {
            // deselect previous
            colorBlock = seedSelectedUI.colors;
            colorBlock.normalColor = neutralColor;
            seedSelectedUI.colors = colorBlock;
        }
        seedSelectedUI = seedInstance.GetComponent<Button>();
        seedSelected = seedToSelect;

        colorBlock = seedSelectedUI.colors;
        colorBlock.normalColor = selectedColor;
        seedSelectedUI.colors = colorBlock;

        fm.activeGardenPlot = this;
    }

    public void plantSeed()
    {
        bool successfulPlant = gm.inventoryManager.removeItem(seedSelected.item);
        growingSeed = seedSelected;
        if ( successfulPlant )
        {
            setStatePlant1();
        }
    }

}

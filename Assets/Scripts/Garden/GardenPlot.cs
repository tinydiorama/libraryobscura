using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Xml;
using UnityEngine.UI;

public enum PlantState { 
    DIRT = 1,
    TILLED = 2,
    PLANTED1 = 3,
    PLANTED2 = 4,
    READYFORHARVEST = 5,
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
    [SerializeField] private GameObject seedSelectPrefab;
    [SerializeField] private Color selectedColor;
    [SerializeField] private Color neutralColor;

    private ItemSlot seedSelected;
    private Button seedSelectedUI;

    public int state;
    public bool watered;

    private GameManager gm;

    private void Start()
    {
        state = (int)PlantState.DIRT;
        gm = GameManager.GetInstance();
    }

    public override IEnumerator Interact(PlayerController player)
    {

        if ( state == (int)PlantState.DIRT )
        {
            Debug.Log("tilling");
            sr.sprite = tilledSprite;
            state = (int)PlantState.TILLED;
            promptText.text = "Plant";
        } else if ( state == (int)PlantState.TILLED )
        {
            //GetComponent<HighlightShowController>().disableHighlight();
            //GetComponent<HighlightShowController>().hideHighlight();
            showSeedSelect();
        } else if ( (state == (int)PlantState.PLANTED1 || state == (int)PlantState.PLANTED2) && ! watered)
        {
            Debug.Log("watering");
            watered = true;
            sr.sprite = wateredSoil;
            GetComponent<HighlightShowController>().disableHighlight();
            GetComponent<HighlightShowController>().hideHighlight();
        }
        yield return new WaitForSeconds(0.2f);
        resetInteraction(player);
    }

    private void showSeedSelect()
    {
        notifContainer.SetActive(true);
        selectSeedContainer.SetActive(true);
        gm.isPaused = true;

        foreach (Transform child in seedDisplay.transform)
        {
            Destroy(child.gameObject);
        }
        int j = 0;
        InventoryManager invManage = gm.inventoryManager;
        for (int i = 0; i < gm.inventoryManager.items.Count; i++)
        {
            Debug.Log(gm.inventoryManager.items[i].item.category.ToString());
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
        state = (int)PlantState.PLANTED1;
        promptText.text = "Water";
    }
}

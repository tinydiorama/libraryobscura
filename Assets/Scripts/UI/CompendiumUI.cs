using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CompendiumUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI uiNum;
    [SerializeField] private TextMeshProUGUI uiName;
    [SerializeField] private Image uiImage;
    [SerializeField] private TextMeshProUGUI uiBuyPrice;
    [SerializeField] private TextMeshProUGUI uiSellPrice;
    [SerializeField] private TextMeshProUGUI uiDesc;
    [SerializeField] private Image uiCrossBreedBaseImage1;
    [SerializeField] private Image uiCrossBreedBaseImage2;
    [SerializeField] private Image uiCrossBreedBaseImage3;
    [SerializeField] private Image uiCrossBreedCrossImage1;
    [SerializeField] private Image uiCrossBreedCrossImage2;
    [SerializeField] private Image uiCrossBreedCrossImage3;
    [SerializeField] private Image uiCrossBreedResultImage1;
    [SerializeField] private Image uiCrossBreedResultImage2;
    [SerializeField] private Image uiCrossBreedResultImage3;

    [SerializeField] private string baseName;
    [SerializeField] private string baseDesc;
    [SerializeField] private string basePrice;
    private CollectionSlot currItemSlot;
    private int currItemPos;
    private GameManager gm;
    private CollectionManager cm;
    public void startCompendium()
    {
        gm = GameManager.GetInstance();
        cm = CollectionManager.instance;
        currItemPos = 0;
        currItemSlot = null;

        gm.isPaused = true;
        showFirstCollection();
    }

    private void Update()
    {
        if (InputManager.GetInstance().GetMenuMoveLeftPressed())
        {
            nextPage();
        }
        else if (InputManager.GetInstance().GetMenuMoveRightPressed())
        {
            prevPage();
        }
        else if (InputManager.GetInstance().GetClosePressed())
        {
            closeCompendium();
        }
    }

    private void showFirstCollection()
    {
        
        foreach ( CollectionSlot slot in cm.collection )
        {
            if ( slot.discovered == true )
            {
                currItemSlot = slot;
                break;
            }
            currItemPos++;
        }

        if (currItemSlot == null )
        {
            currItemPos = 0; // reset the current position to 0 because you have no compendium items
            currItemSlot = cm.collection[0];
        } 
        setUIToCurrItem();
    }

    private void setUIToCurrItem()
    {
        uiNum.text = (currItemPos + 1).ToString() + ". ";

        uiImage.sprite = currItemSlot.item.icon;
        uiCrossBreedBaseImage1.sprite = currItemSlot.item.icon;
        uiCrossBreedBaseImage2.sprite = currItemSlot.item.icon;
        uiCrossBreedBaseImage3.sprite = currItemSlot.item.icon;
        if ( currItemSlot.item.crossBreed1 )
        {
            uiCrossBreedCrossImage1.sprite = currItemSlot.item.crossBreed1.icon;
            uiCrossBreedCrossImage1.color = Color.white;
            if ( ! isDiscovered(currItemSlot.item.crossBreed1) )
            {
                uiCrossBreedCrossImage1.color = Color.black;
            }
        }
        if (currItemSlot.item.crossBreed2)
        {
            uiCrossBreedCrossImage2.sprite = currItemSlot.item.crossBreed2.icon;
            uiCrossBreedCrossImage2.color = Color.white;
            if (!isDiscovered(currItemSlot.item.crossBreed2))
            {
                uiCrossBreedCrossImage2.color = Color.black;
            }
        }
        if (currItemSlot.item.crossBreed3)
        {
            uiCrossBreedCrossImage3.sprite = currItemSlot.item.crossBreed3.icon;
            uiCrossBreedCrossImage3.color = Color.white;
            if (!isDiscovered(currItemSlot.item.crossBreed3))
            {
                uiCrossBreedCrossImage3.color = Color.black;
            }
        }
        if (currItemSlot.item.crossBreedResult1)
        {
            uiCrossBreedResultImage1.sprite = currItemSlot.item.crossBreedResult1.icon;
            uiCrossBreedResultImage1.color = Color.white;
            if (!isDiscovered(currItemSlot.item.crossBreedResult1))
            {
                uiCrossBreedResultImage1.color = Color.black;
            }
        }
        if (currItemSlot.item.crossBreedResult2)
        {
            uiCrossBreedResultImage2.sprite = currItemSlot.item.crossBreedResult2.icon;
            uiCrossBreedResultImage2.color = Color.white;
            if (!isDiscovered(currItemSlot.item.crossBreedResult2))
            {
                uiCrossBreedResultImage2.color = Color.black;
            }
        }
        if (currItemSlot.item.crossBreedResult3)
        {
            uiCrossBreedResultImage3.sprite = currItemSlot.item.crossBreedResult3.icon;
            uiCrossBreedResultImage3.color = Color.white;
            if (!isDiscovered(currItemSlot.item.crossBreedResult3))
            {
                uiCrossBreedResultImage3.color = Color.black;
            }
        }

        if (currItemSlot.discovered ) {
            uiName.text = currItemSlot.item.itemName;
            uiDesc.text = currItemSlot.item.itemDesc;
            uiBuyPrice.text = currItemSlot.item.buyPrice.ToString();
            uiSellPrice.text = currItemSlot.item.sellPrice.ToString();

            uiImage.color = Color.white;
            uiCrossBreedBaseImage1.color = Color.white;
            uiCrossBreedBaseImage2.color = Color.white;
            uiCrossBreedBaseImage3.color = Color.white;
        } else
        {
            uiName.text = baseName;
            uiDesc.text = baseDesc;
            uiBuyPrice.text = basePrice;
            uiSellPrice.text = basePrice;
            uiImage.color = Color.black;
            uiCrossBreedBaseImage1.color = Color.black;
            uiCrossBreedBaseImage2.color = Color.black;
            uiCrossBreedBaseImage3.color = Color.black;
            uiCrossBreedCrossImage1.color = Color.black;
            uiCrossBreedCrossImage2.color = Color.black;
            uiCrossBreedCrossImage3.color = Color.black;
            uiCrossBreedResultImage1.color = Color.black;
            uiCrossBreedResultImage2.color = Color.black;
            uiCrossBreedResultImage3.color = Color.black;
        }
    }

    private bool isDiscovered(Item plantToCheck)
    {
        foreach ( CollectionSlot slot in cm.collection )
        {
            if ( slot.item.itemName == plantToCheck.itemName )
            {
                return slot.discovered;
            }
        }
        return false;
    }

    public void nextPage()
    {
        currItemPos++;
        if ( currItemPos >= cm.collection.Count )
        {
            // circle back to 0
            currItemPos = 0;
        }
        currItemSlot = cm.collection[currItemPos];
        setUIToCurrItem();
    }

    public void prevPage()
    {
        currItemPos--;
        if (currItemPos < 0 )
        {
            // circle back to 0
            currItemPos = cm.collection.Count - 1;
        }
        currItemSlot = cm.collection[currItemPos];
        setUIToCurrItem();
    }

    public void closeCompendium()
    {
        gm.isPaused = false;
        this.gameObject.SetActive(false);
    }
}

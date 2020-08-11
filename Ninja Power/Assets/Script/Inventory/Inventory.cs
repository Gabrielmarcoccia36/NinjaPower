using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    public TextMeshProUGUI Stack = new TextMeshProUGUI();
    
    public Image[] itemImages = new Image[numItemSlots];
    public ItemO[] items = new ItemO[numItemSlots];
    public const int numItemSlots = 15;

    public void AddItem(ItemO itemToAdd)
    {
        if(itemToAdd.MxStack > 1 && itemToAdd.currentStack < itemToAdd.MxStack)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if(items[i] == itemToAdd)
                {
                    itemToAdd.currentStack++;
                    Stack.text = itemToAdd.currentStack.ToString();
                    return;
                }
            }

        }
        for (int i = 0; i < items.Length; i++)
        {  
            if (items[i] == null)
            {
                items[i] = itemToAdd;
                itemImages[i].sprite = itemToAdd.sprite;
                itemImages[i].enabled = true;
                return;
            }
        }
    }

    public void RemoveItem(ItemO itemToRemove)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == itemToRemove)
            {
                items[i] = null;
                itemImages[i].sprite = null;
                itemImages[i].enabled = false;
                return;
            }
        }
    }

}
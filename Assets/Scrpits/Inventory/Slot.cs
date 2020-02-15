using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Item item;
    public Image itemImage;


    //slot item alpha
    private void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }


    public void AddItem(Item _item)
    {
        item = _item;
        itemImage.sprite = item.itemImage;

        SetColor(1);
    }

    public void RemoveItem(Item _item)
    {
        item = null;
        itemImage.sprite = null;
        SetColor(0);
    }

    public void EquipmentItem()
    {
        if (item != null)
        {
            if (item.itemType == Item.ItemType.Equipment)
            {

            }
        }
    }


    private void ClearSlot()
    {
        item = null;

        itemImage.sprite = null;
        SetColor(0);


    }
}


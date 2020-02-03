using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Item item; 
    public int itemCount;
    public Image itemImage;


    [SerializeField]
    private Text text_Count;
    [SerializeField]
    private GameObject go_CountImage;


    //slot item alpha
    private void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }


    public void AddItem(Item _item, int _count = 1)
    {
        item = _item;
        itemCount = _count;
        itemImage.sprite = item.itemImage;

        SetColor(1);
    }
    

    public void EquipmentItem()
    {
        if(item != null)
        {
            if (item.itemType == Item.ItemType.Equipment)
            {

            }
        }
    }


    private void ClearSlot()
    {
        item = null;
        itemCount = 0;
        itemImage.sprite = null;
        SetColor(0);

        text_Count.text = "0";
        go_CountImage.SetActive(false);
    }
}


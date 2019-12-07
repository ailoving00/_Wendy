﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{

    public Item item; // 획득한 아이템.
    public int itemCount; // 획득한 아이템의 개수.
    public Image itemImage; // 아이템의 이미지.


    // 필요한 컴포넌트.
    [SerializeField]
    private Text text_Count;
    [SerializeField]
    private GameObject go_CountImage;


    // 이미지의 투명도 조절.
    private void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }

    // 아이템 획득
    public void AddItem(Item _item, int _count = 1)
    {
        item = _item;
        itemCount = _count;
        itemImage.sprite = item.itemImage;


        SetColor(1);
    }

    // 아이템 개수 조정.
    public void SetSlotCount(int _count)
    {
        itemCount += _count;
        text_Count.text = itemCount.ToString();

        if (itemCount <= 0)
            ClearSlot();
    }

    // 슬롯 초기화.
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



//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class Slot : MonoBehaviour
//{

//    public Item item; // 휙득한 아이템
//    public int itemCount; // 휙득한 아이템의 갯수 - 필요X
//    public Image itemImage; // 아이템의 이미지


//    //필요한 컴포넌트
//    [SerializeField]
//    private Text text_Count;



//    //이미지의 투명도 조절 - 아이템이 없을때는 투명, 있을때는 선명하게 해야한다.
//    private void SetColor(float _alpha)
//    {
//        Color color = itemImage.color;
//        color.a = _alpha;
//        itemImage.color = color;
//    }

//    //아이템 휙득
//    public void Additem(Item _item, int _count = 1 )
//    {
//        item = _item;
//        itemCount = _count;
//        itemImage.sprite = item.itemImage;

//      //  go_CountImage.SetActive(true);
//        SetColor(1); // 아이템이 들어오면 보여준다. 
//    }



//    public void SetSlotCount(int _count)
//    {
//        itemCount += _count;
//        text_Count.text = itemCount.ToString();

//        if (itemCount <= 0)
//            ClearSlot();
//    }

//    //슬롯초기화
//    private void ClearSlot()
//    {
//        item = null;
//        //itemCount = 0;
//        itemCount = 0;
//        itemImage.sprite = null;
//        SetColor(0); //아이템이 사라지면 투명화

//        //  go_CountImage.SetActive(false);

//    }

//    //public SetSlotCount(int _count)


//}

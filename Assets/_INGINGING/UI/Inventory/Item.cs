using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New item", menuName = "New item/item")]

public class Item : ScriptableObject
{
    public string itemName; // 아이템의 이름
    public ItemType itemType;
    public Sprite itemImage; // 아이템의 이미지
    public GameObject itemPrefab; //아이템의 프리팹 - 아이템3d 이미지 

    public string weaponType;

    public enum ItemType
    {
        Equipment,  //장비 (손전등)
        Used,       //사용(소비아이템)
        Read        //쪽지등 기타 아이템(인벤토리이용불가)
    }



}



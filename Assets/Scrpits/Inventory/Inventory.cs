/////////////////////Inventory/////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static bool inventoryActivated = false;

    [SerializeField]
    private GameObject go_InventoryBase;

    [SerializeField]
    private GameObject go_SlotsParent;



    private Slot[] slots;
    public GameObject[] NoteItemCG;
    public GameObject CarPuzzle;

    int BlockCount = 0;
    bool check;



    void Start()
    {
        slots = go_SlotsParent.GetComponentsInChildren<Slot>();
        CarPuzzle.SetActive(false);
    }


    public void AcquireItem(Item _item, int _count = 1)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (Item.ItemType.Read  != _item.itemType)
            {
                if(Item.ItemType.Equipment != _item.itemType)
                {
                    if (slots[i].item == null)
                    {
                        slots[i].AddItem(_item, _count);


                        if (Item.ItemType.Puzzle == _item.itemType)
                        {
                            BlockCount++;
                            if (BlockCount == 4) { CarPuzzle.SetActive(true); }
                        }

                        return;
                    }
                }
            }
        }
    }

}








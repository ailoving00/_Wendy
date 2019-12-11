using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public static bool inventoryActivated = false;


    // 필요한 컴포넌트
    [SerializeField]
    private GameObject go_InventoryBase;
    [SerializeField]
    private GameObject go_SlotsParent;


    // 슬롯들
    private Slot[] slots;



    // Use this for initialization
    void Start()
    {
        slots = go_SlotsParent.GetComponentsInChildren<Slot>();
      

        // up_Light.GetComponent<SpriteRenderer>().sprite = Resources.Load("up_", typeof(Sprite)) as Sprite;
        // down_Light.GetComponent<SpriteRenderer>().sprite = Resources.Load("down_", typeof(Sprite)) as Sprite;
    }

    // Update is called once per frame
    void Update()
    {





    }

    public void AcquireItem(Item _item, int _count = 1)
    {
        if (Item.ItemType.Equipment != _item.itemType)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].item != null)
                {
                    if (slots[i].item.itemName == _item.itemName)
                    {
                        slots[i].SetSlotCount(_count);
                        return;
                    }
                }
            }
        }

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null)
            {
                slots[i].AddItem(_item, _count);
                return;
            }
        }
    }
}





////본인코드 
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Inventory : MonoBehaviour
//{

//    public static bool inventoryActivated = false;
//    // public static bool inventoryActivate = false; - 필요x
//    // Tab누리면 인벤토리 활성화 되게 완료되어있음

//    [SerializeField]
//    private GameObject go_InventoryBase;

//    [SerializeField]
//    private GameObject go_SlotsParent;

//    //슬롯들
//    private Slot[] slots;


//    // Start is called before the first frame update
//    void Start()
//    {
//        slots = go_SlotsParent.GetComponentsInChildren<Slot>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        //TryOpenInventroy();
//    }

//    public void AcquireItem(Item _item)
//    {

//        for (int i = 0; i < slots.Length; i++)
//        {
//            if (slots[i].item != null)
//            {
//                if (slots[i].item.itemName == "")
//                {
//                    slots[i].AddItem(_item, _count);
//                    Debug.Log("실행되었습니다");
//                    return;
//                }
//            }

//        }
//    }


//}

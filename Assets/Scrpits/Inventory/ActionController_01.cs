/////////////////////Inventory action/////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ActionController_01 : MonoBehaviour
{
    public Inventory theInventory;

    [SerializeField]
    private float range;

    [SerializeField]
    private LayerMask layerMask;

    [SerializeField]
    private Text actionText;

    /// acquire true - false 
    private bool pickupActivated = false;
    private RaycastHit hitInfo;

    // item event

    // item event count
    private int BlockCount = 0;


    void Start()
    {
    }


    void Update()
    {
        CheckItem();
        TryAction();
    }


    private void TryAction()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckItem();
            CanPickUp();
        }
    }

    private void CanPickUp()
    {
        if (pickupActivated)
        {
            if (hitInfo.transform != null)
            {
                if (hitInfo.transform.tag == "ItemSet")
                {
                    theInventory.RemoveSlot(hitInfo.transform.GetComponent<ItemSetUp>().item);

                    if (theInventory.Remove_Count)
                    {
                        hitInfo.transform.GetComponent<ItemSetUp>().SetItem.SetActive(true);
                        if (hitInfo.transform.GetComponent<ItemSetUp>().item.itemName == "Block")
                        {
                            BlockCount++;
                        }
                    }
                }

                if (hitInfo.transform.tag == "Item")
                {
                    Debug.Log(hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + "획득했습니다");
                    theInventory.AcquireItem(hitInfo.transform.GetComponent<ItemPickUp>().item);
                    Destroy(hitInfo.transform.gameObject);
                    InfoDisappear();
                }
            }
        }
    }

    private void CheckItem()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitInfo, range, layerMask))
        {
            if (hitInfo.transform.tag == "Item")
            {
                ItemInfoAppear();
            }

            if (hitInfo.transform.tag == "ItemSet")
            {
                DoorBlockSet();
            }
        }
        else
            InfoDisappear();
    }




    // Need to modify

    private void ItemInfoAppear()
    {
        pickupActivated = true;
        actionText.gameObject.SetActive(true);
        actionText.text = hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + "획득" + "[Click]";
    }

    public void InfoDisappear()
    {
        pickupActivated = false;
        actionText.gameObject.SetActive(false);
    }


    public void DoorBlockSet()
    {
        pickupActivated = true;
        actionText.gameObject.SetActive(true);
        actionText.text = "문에 블럭 꽂기";

    }



}

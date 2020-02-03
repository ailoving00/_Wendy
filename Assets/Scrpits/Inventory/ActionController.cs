/////////////////////Inventory action/////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ActionController : MonoBehaviour
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

    /// Note item
    public GameObject Read_itemPlane;
    public GameObject Note1;
    public GameObject Note2;
    public GameObject Note3;
    public GameObject Note4;

    // Equipment item - Flashlight
    public GameObject FlashlightItem;
    int FlashCount = 0;



    void Start()
    {
        Note1.SetActive(false);
        Note2.SetActive(false);
        Note3.SetActive(false);
        Note4.SetActive(false);
        FlashlightItem.SetActive(false);
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


                if (hitInfo.transform.tag == "Item")
                {

                    Debug.Log(hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + "획득했습니다");
                    theInventory.AcquireItem(hitInfo.transform.GetComponent<ItemPickUp>().item);
                    Destroy(hitInfo.transform.gameObject);
                    InfoDisappear();


                    /// pickupActioned - Noteitem
                    /// 
                    if (hitInfo.transform.GetComponent<ItemPickUp>().item.itemName == "Note1")
                    {
                        Note1.SetActive(true);
                    }

                    if (hitInfo.transform.GetComponent<ItemPickUp>().item.itemName == "Note2")
                    {
                        Note2.SetActive(true);
                    }

                    if (hitInfo.transform.GetComponent<ItemPickUp>().item.itemName == "Note3")
                    {
                        Note3.SetActive(true);
                    }

                    if (hitInfo.transform.GetComponent<ItemPickUp>().item.itemName == "Note4")
                    {
                        Note4.SetActive(true);
                    }

                    if (hitInfo.transform.GetComponent<ItemPickUp>().item.itemName == "FlashlightItem")
                    {
                      
                        FlashlightItem.SetActive(true);

                    }

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




}


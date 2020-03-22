/////////////////////Inventory action/////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;



public class ActionController_01 : MonoBehaviour
{
    public Inventory theInventory;

    [SerializeField]
    private float range; // 충돌 체크 구의 반경
    [SerializeField]
    private float length = 3f ; // 충돌 체크의 최대 거리 

    [SerializeField]
    private LayerMask layerMask;

    [SerializeField]
    private GameObject target;

    [SerializeField]
    private GameObject P_target;//타겟 발 오브젝트와 연결된 pivot

    public float angleRange = 180f;
    public float distance = 5f;
    public bool isCollision = false;
    Color _blue = new Color(0f, 0f, 1f, 0.2f);
    Color _red = new Color(1f, 0f, 0f, 0.2f);
    Vector3 direction;
    float dotValue = 0f;


    [SerializeField]
    private Text actionText;

    /// acquire true - false 
    public bool pickupActivated = false;
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
    private void OnDrawGizmos()
    {
        Handles.color = isCollision ? _red : _blue;
        Handles.DrawSolidArc(target.transform.position, Vector3.up, target.transform.forward, angleRange / 2, distance); 
        //                     타겟에의 위치에서, 타겟의 위치 앞전방으로,위아래 판별, 각도는 몇만큼, 방향은 몇만큼
        Handles.DrawSolidArc(target.transform.position, Vector3.up, target.transform.forward, -angleRange / 2, distance);
        //                     타겟에의 위치에서, 타겟의 위치 앞전방으로 ,위아래 판별, 각도는 몇만큼의 -, 방향은 몇만큼. 

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
        if (Physics.SphereCast(P_target.transform.position, range, Vector3.up , out hitInfo, length, layerMask))
        {
            //                 레이저 발사 위치            , 구의 반경, 발사 방향,      충돌 결과,     최대거리, 레이어마스크
            ItemInfoAppear();
            CheckSectorform();

            Debug.Log("검토작업시작");
            if (isCollision)
            {
                if (hitInfo.transform.tag == "Item")
                {
                    ItemInfoAppear();
                    Debug.Log("이건 되고있나?");
                }

                if (hitInfo.transform.tag == "ItemSet")
                {
                    DoorBlockSet();
                }

            }


        }

        else
        {
            InfoDisappear();
            isCollision = false;
            
        }


    }


    private void CheckSectorform()
    {
        dotValue = Mathf.Cos(Mathf.Deg2Rad * (angleRange / 2)); //코사인을 구하는것....안의 각도를 구하는것
        direction = hitInfo.transform.position - target.transform.position; 
        if (direction.magnitude < distance) 
        {
            if (Vector3.Dot(direction.normalized, target.transform.forward) > dotValue) 
            {
                isCollision = true;
                Debug.Log("충돌중");
            }
            else
            {
                isCollision = false;
                Debug.Log("충돌안함");
            }
        }
        else
            isCollision = false;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionController_Drawer : MonoBehaviour
{
    [SerializeField]
    private float range;
    [SerializeField]
    private LayerMask layerMask;
    private RaycastHit hitaction;
    private Camera mainCam;

    private bool pickupActivated;
    [SerializeField]
    private Image actionImage;

    // - 외곽선
    private DrawOutline_HJ OutlineController;
    private int pre_ol_index = 0; //이전 아웃라인 인덱스
   
    // - 서랍
    public GameObject[] moveChest;

    // - 장애물, 벽
    ObstacleReader obstacleReader_script;
    bool coverCheck = false;

    void Start()
    {
        mainCam = GetComponent<Camera>();

        //외곽선
        OutlineController = GameObject.FindObjectOfType<DrawOutline_HJ>();

        //장애물,벽
        obstacleReader_script = GameObject.FindObjectOfType<ObstacleReader>();
    }

    // Update is called once per frame
    void Update()
    {
        if (coverCheck)
        {
            coverCheck = obstacleReader_script.LookAtFrame((int)layerMask);
            return;
        }

        LookAtDrawer();
        TryAction();
    }

    private void LookAtDrawer()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitaction, range, layerMask))
        {
            if (hitaction.transform.CompareTag("Drawer")) //compare @
            {
                // - 장애물 검사하기
                coverCheck = obstacleReader_script.LookAtFrame((int)layerMask);
                if (coverCheck)
                    return;

                ActionAppear();
            }
        }
        else
        {
            ActionDisappear();

            // - 장애물 검사하기
            coverCheck = obstacleReader_script.LookAtFrame((int)layerMask);
        }
    }

    private void TryAction()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // - 서랍 클릭했는지 검사
            Check_Do_action();
        }
    }


    private void Check_Do_action()
    {
        if (hitaction.transform != null) //pickupActivated == true
        {
            if (hitaction.transform.tag == "Drawer") //compare @
            {
                int Chestnumber = hitaction.transform.parent.GetComponent<Chestaction>().Chest_number;
                int drawerType = hitaction.transform.parent.GetComponent<Chestaction>().type;
                moveChest[Chestnumber].transform.parent.GetComponent<Chestaction>().Start_action(drawerType);
            }
        }
    }

    private void Checkaction()
    {

    }

    // Need to modify
    private void ActionAppear()
    {
        pickupActivated = true;
        //actiontext.gameObject.SetActive(true);
        //actiontext.text =  "서랍 여닫기 [Click]";
    }
    public void ActionDisappear()
    {
        pickupActivated = false;
        //actiontext.gameObject.SetActive(false);
    }
}

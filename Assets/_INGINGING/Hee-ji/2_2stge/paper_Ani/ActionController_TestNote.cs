using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionController_TestNote : MonoBehaviour
{
    /// acquire true - false 
    private bool pickupActivated = false;
    private RaycastHit hitInfo;
    [SerializeField]
    private float range;
    [SerializeField]
    private LayerMask layerMask;

    [SerializeField]
    private Image actionImage;

    // - 외곽선
    private Camera mainCam;
    private DrawOutline_HJ OutlineController;
    private int pre_ol_index = 0; //이전 아웃라인 인덱스

    // - 쪽지
    //ViewNote_Ani_02 viewNote_script_clock;
    FlodNote clockNote_script;

    bool popupNote = false;
    bool opening = false;

    void Start()
    {
        mainCam = GetComponent<Camera>();
        OutlineController = GameObject.FindObjectOfType<DrawOutline_HJ>();

        clockNote_script = GameObject.FindObjectOfType<FlodNote>();
    }

    void Update()
    {
        if (!popupNote)
        {
            CheckItem();
        }
        TryAction();
    }

    private void TryAction()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // - 애니메이션 쪽지
            if (!popupNote)
            {
                CanPickUp();
            }
            else
            {
                if (!opening) // 2번
                {
                    //쪽지 열기 애니메이션 (이동은 CanPickUp에서)
                    if (clockNote_script.openAni_Note())
                        opening = true;
                }
                else // 3번
                {
                    //접기 + 원위치로 이동
                    if (clockNote_script.endAni_Note())
                    {
                        opening = false;
                        popupNote = false; //->위 호출이 다끝나면 변하게해야함
                    }
                }
            }
        }
    }

    private void CanPickUp()
    {
        if (pickupActivated)
        {
            if (hitInfo.transform != null)
            {
                if (hitInfo.transform.CompareTag("Note_CP")) // 1번
                {
                    popupNote = true;

                    clockNote_script.SetActive_Ani(true);
                    clockNote_script.SetActive_Outline(false);

                    clockNote_script.startAni_Note();

                    InfoDisappear();

                    // - 외곽선
                    //OutlineController.set_enabled(pre_ol_index, false);
                }
            }
        }
    }

    private void CheckItem()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitInfo, range, layerMask))
        {
            if (hitInfo.transform.CompareTag("Note_CP"))
            {
                // - info 띄우기
                ItemInfoAppear();

            }
            else
            {

            }
        }
        else
        {
            InfoDisappear();
        }
    }


    // Need to modify
    private void ItemInfoAppear()
    {
        pickupActivated = true;
        //actionImage.gameObject.SetActive(true);
    }

    public void InfoDisappear()
    {
        pickupActivated = false;
        //actionImage.gameObject.SetActive(false);
    }
}

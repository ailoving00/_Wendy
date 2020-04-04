using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockPuzzle_Manager : MonoBehaviour
{
    // - 시계퍼즐 풀 수 있는지 상태 확인하기 (범위에 들어왔는가)
    public bool active = false;
    private bool end = false;

    // - 클릭
    // 카메라
    private Camera mainCamera;
    private Transform mCT;
    // 레이케스트
    private RaycastHit hitInfo;
    private float range = 2.5f;
    public LayerMask layerMask;

    Move_Cuckoo cuckoo_script;

    EnterClockAnswer enterBtn_script;
    DoorAni_reward reward_script;
    CustomFan fan_script;

    void Start()
    {
        mainCamera = Camera.main;
        mCT = mainCamera.transform;

        cuckoo_script = GameObject.FindObjectOfType<Move_Cuckoo>();

        enterBtn_script = GameObject.FindObjectOfType<EnterClockAnswer>();
        reward_script = GameObject.FindObjectOfType<DoorAni_reward>();
        fan_script = GameObject.FindObjectOfType<CustomFan>();
    }

    void Update()
    {
        check_click();
    }

    private void check_click()
    {
        if (end)
            return;

        if (!active)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            check_collider();
        }
    }

    private void check_collider()
    {
        if (Physics.Raycast(mCT.position, mCT.TransformDirection(Vector3.forward), out hitInfo, range, layerMask))
        {
            if (hitInfo.transform.tag == "InputButton_CP")
            {
                InputClockAnswer input_script = hitInfo.transform.GetComponent<InputClockAnswer>();
                input_script.click_button();                
            }
            else if (hitInfo.transform.tag == "EnterButton_CP")
            {
                if(!enterBtn_script.get_result())
                {
                    cuckoo_script.start_cuckooAni();
                }
                else
                {
                    // - 코루틴으로 몇초뒤 스크립트가 enable = false 되는것은 @
                    end = true;
                    fan_script.cp_is_over();

                    // - 시계판 열리는 애니메이션
                    reward_script.set_Ani_param();
                }
            }
        }
    }

    public void set_active(bool btemp)
    {
        active = btemp;
    }
    public bool get_active()
    {
        return active;
    }


    public Vector3 get_mainCam_pos()
    {
        return mCT.position;
    }

    public Vector3 get_hitinfo_pos()
    {
        return hitInfo.point;
    }
}

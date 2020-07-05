using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellarDoorCollider : MonoBehaviour
{
    public Text guideCaption; //안씀
    ChangeCam_2stage ChangeCam_script;
    bool textstate = true;


    [SerializeField]
    private float range;
    [SerializeField]
    private LayerMask layerMask;
    private RaycastHit hitInfo;

    Camera _mainCam;
    public Camera CellarCamera;

    // - 외곽선
    private DrawOutline_HJ OutlineController;
    public int pre_ol_index = -1; //이전 아웃라인 인덱스
    private bool outline_active = false;

    // - 클릭버튼
    public GameObject actionCaption;

    ActionController_02_VER2 actionCtrler2_script;

    // - 장애물, 벽
    ObstacleReader obstacleReader_script;
    bool coverCheck = false;
    int checklayer;

    // - 서브시계 보기
    MakeClockSee subClock_script; // 우선순위를 위해서

    // - 시계퍼즐 활성화 상태를 얻기위함
    ClockPuzzle_Manager cp_manager_script;

    // - 쪽지 매니저
    NoteManger notemager;

    // - 2스테이지 클리어 변수
    private bool _2stage_clear = false;

    void Start()
    {
        ChangeCam_script = FindObjectOfType<ChangeCam_2stage>();
        //guideCaption.gameObject.SetActive(false);

        _mainCam = Camera.main;
        CellarCamera = GetComponent<Camera>();

        // - 장애물 확인용 레이어 지정
        checklayer = (1 << LayerMask.NameToLayer("Basement")) + (1 << LayerMask.NameToLayer("Obstacle"));
        //외곽선
        OutlineController = GameObject.FindObjectOfType<DrawOutline_HJ>();
        //장애물,벽
        obstacleReader_script = GameObject.FindObjectOfType<ObstacleReader>();

        // 서브시계 보는 스크립트
        subClock_script = GameObject.FindObjectOfType<MakeClockSee>();

        //시계퍼즐 매니저 스크립트
        cp_manager_script = GameObject.FindObjectOfType<ClockPuzzle_Manager>();

        // 쪽지 매니저
        notemager = FindObjectOfType<NoteManger>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            if (_2stage_clear)
                return;

            if (notemager._popup == true) //쪽지 팝업 체크
                return;

            // 시계퍼즐이 클리어 됬는지 (서브시계
            if (!cp_manager_script.GetPuzzleEnd())
            {
                // - 지하실 볼수있는 범위에 들어오면 서브시계 볼수없음, 지하실보는것이 우선순위
                subClock_script.set_active(false);
                subClock_script.enabled = false;
            }
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            if (_2stage_clear)
                return;

            if (notemager._popup == true) //쪽지 팝업 체크
                return;

            if (textstate)
            {
                if (LookAtDoor())
                {
                    //GuidText();

                    // - 외곽선 그리기
                    if (pre_ol_index == -1)
                    {
                        SetOutline setoutlin_script = hitInfo.transform.GetComponent<SetOutline>();
                        OutlineController.set_check(true);
                        OutlineController.set_enabled(setoutlin_script._index, true);
                        pre_ol_index = setoutlin_script._index;
                        outline_active = true;

                        // - 클릭버튼 활성화
                        actionCaption.SetActive(true);
                    }
                }
                else
                {
                    if (pre_ol_index != -1)
                    {
                        // - 외곽선 해제
                        OutlineController.set_enabled(pre_ol_index, false);
                        pre_ol_index = -1;
                        OutlineController.set_check(false);
                        outline_active = false;

                        // - 클릭버튼 해제
                        actionCaption.SetActive(false);
                    }
                }
            }
            else
            {
                //NotText();

                if (pre_ol_index != -1)
                {
                    // - 외곽선 해제
                    OutlineController.set_enabled(pre_ol_index, false);
                    pre_ol_index = -1;
                    OutlineController.set_check(false);
                    outline_active = false;

                    // - 클릭버튼 해제
                    actionCaption.SetActive(false);
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (LookAtDoor())
                {
                    ChangeCam_script.change_Camera(1);

                    //NotText();

                    textstate = false;
                }
            }
        }
    }

    bool LookAtDoor()
    {
        if (Physics.Raycast(_mainCam.transform.position, _mainCam.transform.TransformDirection(Vector3.forward), out hitInfo, range, layerMask))
        {
            return true;
        }
        return false;
    }



    void GuidText()
    {
        //guideCaption.gameObject.SetActive(true);
        //guideCaption.text = "지하실 살펴보기";
    }

    void NotText()
    {
        //guideCaption.gameObject.SetActive(false);
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            if (_2stage_clear)
                return;

            if (notemager._popup == true) //쪽지 팝업 체크
                return;

            //guideCaption.gameObject.SetActive(false);
            textstate = true;

            if (pre_ol_index != -1)
            {
                // - 외곽선 해제
                OutlineController.set_enabled(pre_ol_index, false);
                pre_ol_index = -1;
                OutlineController.set_check(false);
                outline_active = false;

                // - 클릭버튼 해제
                actionCaption.SetActive(false);
            }

            // 시계퍼즐이 클리어 됬는지
            if (!cp_manager_script.GetPuzzleEnd())
            {
                // - 서브시계 볼수있음
                subClock_script.enabled = true;
            }
        }
    }

    private bool CheckObstacle()
    {
        // - 장애물 검사하기
        coverCheck = obstacleReader_script.LookAtFrame(checklayer);
        if (coverCheck)
        {
            if (pre_ol_index != -1)
            {
                // - 외곽선 해제
                OutlineController.set_enabled(pre_ol_index, false);
                pre_ol_index = -1;
                OutlineController.set_check(false);
                outline_active = false;

                // - 클릭버튼 해제
                actionCaption.SetActive(false);
            }

            return true;
        }

        return false;
    }

    public void set_state(bool b) //지하실 changeCam 스크립트에서 호출됨
    {
        textstate = b;
    }

    public void Set2StageEnd()
    {
        _2stage_clear = true;
    }
}

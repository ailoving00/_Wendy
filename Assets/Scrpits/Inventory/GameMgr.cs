﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameMgr : MonoBehaviour
{
    public Transform[] points;
    public RectTransform Inventory_Panel;
    public RectTransform scrollRectView;
    private bool check;

    public CanvasGroup inventoryCG;

    private bool isPaused;

    Animator animator;

    [SerializeField]
    private string BGMSound;

    // - 선택슬롯
    public SelectSlot selectSlot_script;

    //- 자막 (인벤)
    public Image puzzleImage;
    FadeAni_guide guide_script;
    GuideCaption_Controller guideController_script;
    private bool onceCaption = false;
    // - 1스테이지 인벤토리 가이드 확인
    public bool invenguide_on = true;

    // - 옵션창
    public GameObject optionPanel;
    public bool pop = false;
    private bool once_pop = false;
    private Option_inGame option_ingame_script;

    // - stage
    public int stage; //1 : 1스테이지, 2 : 2~3스테이지

    // - 카메라 움직임
    FirstPersonCamera fpCam_script;

    // - 쪽지 매니저
    NoteManger notemager;

    public GameObject Aim;

    // - 게임오버
    GameOverManger gameOver_script;


    void Start()
    {
        check = false;

        inventoryCG.interactable = false;
        inventoryCG.blocksRaycasts = false;

        //RectTransform scrollRectView = GetComponent<RectTransform>();
        //RectTransform Inventory_Panel = GetComponent<RectTransform>();

        animator = Inventory_Panel.GetComponent<Animator>();
        SoundManger.instance.PlayBGMSound(BGMSound);

        // - 인벤토리 
        if (puzzleImage != null)
        {
            guide_script = puzzleImage.gameObject.GetComponent<FadeAni_guide>();
            guideController_script = puzzleImage.gameObject.GetComponent<GuideCaption_Controller>();
        }
        else
        {
            onceCaption = true;
        }

        if (stage == 2)
            fpCam_script = GameObject.FindObjectOfType<FirstPersonCamera>();

        option_ingame_script = GameObject.FindObjectOfType<Option_inGame>();

        //쪽지매니저
        notemager = FindObjectOfType<NoteManger>();
        //if (notemager.guidePopup == true)

        //게임오버
        gameOver_script = GameObject.FindObjectOfType<GameOverManger>();
    }

    void Update()
    {
        if (stage == 2)
        {
            if (gameOver_script.SetClick == true)
                return;
        }

        //// - 커서 락모드 테스트 
        //if (Input.GetKeyDown(KeyCode.T))
        //{
        //    Cursor.lockState = CursorLockMode.None;
        //}
        //if (Input.GetKeyDown(KeyCode.G))
        //{
        ////    Cursor.lockState = CursorLockMode.Locked;
        //}

        // - 옵션창
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Application.Quit();

            if (!pop)
            {
                OptionPopUp();
                if (notemager.guidePopup == true)
                    notemager.NoClickEvent_fromGameMgr();
            }
            else
            {
                OptionDisappear();
            }
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!onceCaption)
            {
                onceCaption = true;
                invenguide_on = false;
                guide_script.InStartFadeAnim();
            }

            if (check)
            {
                check = false;
                SlideInventory(false);
            }
            else
            {
                check = true;
                SlideInventory(true);
            }

            OnInventoryOpen(check);
        }

        //Move scroll
        if (check == true)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                selectSlot_script.Set_slotPos_index(-1); //이동보간

                if (selectSlot_script.select_EndSlot)
                    scrollRectView.anchoredPosition += new Vector2(0, -10);
                //Debug.Log("위 실행"); 
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                selectSlot_script.Set_slotPos_index(1);

                if (selectSlot_script.select_EndSlot)
                    scrollRectView.anchoredPosition += new Vector2(0, 10);
                //Debug.Log("아래 실행"); 
            }
        }
    }

    public void SlideInventory(bool is2Opened)
    {
        //Animator animator = Inventory_Panel.GetComponent<Animator>();
        if (Inventory_Panel != null)
        {
            bool isOpen = animator.GetBool("open");

            animator.SetBool("open", !isOpen);
        }
    }

    public void OnInventoryOpen(bool isOpened)
    {
        inventoryCG.interactable = isOpened;
        inventoryCG.blocksRaycasts = isOpened;
        StartCoroutine("WaitForAnimation");
    }
    bool EndAnimationDone()
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.CloseInventory") &&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.99f; //==true 이면, 애니메이션 끝남
        //false == animator.IsInTransition(0)
    }
    IEnumerator WaitForAnimation()
    {
        while (!EndAnimationDone())
        {
            yield return new WaitForEndOfFrame();
        }

        // - 닫았을때
        scrollRectView.anchoredPosition = new Vector2(0.0f, -144.6f); //인벤토리 애니메이션이 끝날때 호출
    }

    public void OptionPopUp()
    {
        Time.timeScale = 0f;
        optionPanel.SetActive(true);
        pop = true;

        if (!once_pop)
        {
            once_pop = true;
            //Option_inGame.InitSliderValue(); //초기화는 언제하는지.
        }

        Cursor.lockState = CursorLockMode.None;

        if (stage == 1)
        {

        }
        else if (stage == 2)
        {
            fpCam_script.enabled = false;
        }
    }
    public void OptionDisappear()
    {
        Time.timeScale = 1f;

        optionPanel.SetActive(false);
        pop = false;

        if (stage == 1)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else if (stage == 2 || stage == 3)
        {
            Cursor.lockState = CursorLockMode.Locked;
            fpCam_script.enabled = true;
        }

        notemager.guidePopup = false;
    }

}

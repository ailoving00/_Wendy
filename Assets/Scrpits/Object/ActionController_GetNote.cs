using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ActionController_GetNote : MonoBehaviour
{

    [SerializeField]
    private float range;

    [SerializeField]
    private LayerMask layerMask;

    private RaycastHit hitaction;

    Chestaction cheataction;
    NoteManger notemager;
    //RewardNote_Check noteCheck_script;

    private bool pickupActivated;

    public Text actiontext;

   // RewardNote_Check notecheck_script;
    public GameObject[] moveChest;


    private bool isPopup = false;
    private bool isFirstPage = true;
    private bool isLastPage = false;
    private bool getKey = false;

    FirstPersonCamera fpCam_Script;
    Player_HJ player_script;

    private bool AniState = false;


    // - ui
    public GameObject Aim;
    Vector3 halfScreen;


    // Start is called before the first frame update
    void Start()
    {

        //noteCheck_script = GameObject.FindObjectOfType<RewardNote_Check>();
        fpCam_Script = Camera.main.GetComponent<FirstPersonCamera>();
        player_script = GameObject.FindObjectOfType<Player_HJ>();
        cheataction = FindObjectOfType<Chestaction>();
        notemager = FindObjectOfType<NoteManger>();
      //  notecheck_script = FindObjectOfType<RewardNote_Check>();
        //  noteCheck_script.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        Checkaction();
        TryAction();
    }



    private void TryAction()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // - 아이템 사용
            Check_Do_action();
        }
    }


    private void Check_Do_action()
    {
        if (hitaction.transform != null)
        {
            //추후에 따로 분리할 예정입니다.
            if (hitaction.transform.tag == "Action") //compare @
            {
                int Chestnumber = hitaction.transform.parent.GetComponent<Chestaction>().Chest_number;
                moveChest[Chestnumber].transform.parent.GetComponent<Chestaction>().Start_action(1);
            }
            
            if (hitaction.transform.tag == "Note_EB") //compare @
            {
                hitaction.transform.GetComponent<PageNote>().CheckAddcount(1);

                fpCam_Script.enabled = false;
                player_script.enabled = false;


                if(AniState ==false)
                {
                    DelayPlay();

                }

                Aim.SetActive(false);
                ActionDisappear(); //info 삭제 - 분명 삭제했는데 왜 자꾸 뜬담? 


            }
            if (hitaction.transform.tag == "Door_EB") //compare @
            {
                notemager.OpenCondition();
            }

        }
    }



    bool flipOver = false;


    void DelayPlay()
    {
        StartCoroutine(DelayNoteAni());
    }
    IEnumerator DelayNoteAni()
    {
        AniState = true;

        yield return new WaitForSeconds(0.2f);//3초동안 딜레이

        hitaction.transform.GetComponent<RewardNote_Check>().move_NoteAni();

        yield return new WaitForSeconds(0.2f);//3초동안 딜레이

        AniState = false;
    }


    private void PopUpNote()
    {
        if (flipOver)
            return;
    }

    public void reset_NoteState()
    {
        //책 팝업상태 해제
        isPopup = false; //팝업 상태 

        //카메라, 플레이어 이동 가능
        fpCam_Script.enabled = true;
        player_script.enabled = true;

        Aim.SetActive(true);

    }


    private void Checkaction()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitaction, range, layerMask))
        {
            if (hitaction.transform.CompareTag("Action")) //compare @
            {
                ActionAppear();
            }

            if (hitaction.transform.CompareTag("Note_EB")) //compare @
            {
                NoteAppear();
            }

            if (hitaction.transform.CompareTag("Door")) //compare @
            {
                DoorAppear();
            }
        }
        else
            ActionDisappear();
    }
    private void DoorAppear()
    {
        pickupActivated = true;
        actiontext.gameObject.SetActive(true);
        actiontext.text = " 밖으로 나간다";
    }

    private void NoteAppear()
    {
        pickupActivated = true;
        //actiontext.gameObject.SetActive(true);
      //  actiontext.text = " 쪽지 살펴보기 [Click]";
    }


    // Need to modify
    private void ActionAppear()
    {
        pickupActivated = true;
        actiontext.gameObject.SetActive(true);
        actiontext.text =  "서랍 여닫기 [Click]";
    }
    public void ActionDisappear()
    {
        pickupActivated = false;
       actiontext.gameObject.SetActive(false);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("noteAction"))
    //    {
    //        GameDataManager.instance.AddCount(1);
    //    }

    //}

}

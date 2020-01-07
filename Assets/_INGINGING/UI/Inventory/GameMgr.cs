using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameMgr : MonoBehaviour
{
    //프리팹을 저장할 변수
    public Transform[] points;

    GameObject[] hi;
    //일시정지 여부를 판단하는 변수
    private bool isPaused;

    //인벤토리 패널을 가져와 부드러운 이동 시전; 
    public GameObject Inventory_Panel;

    // 스크롤 트랜스 폼을 받아오는 함수
    public RectTransform scrollRectView;





    //Inventory 의 CanvasGroup 컴포넌트를 저장할 변수 
    public CanvasGroup inventoryCG;

    private bool check;

    // Start is called before the first frame update

    void Start()
    {
        OnInventoryOpen(false);
        check = false;

        RectTransform scrollRectView = GetComponent<RectTransform>();
        RectTransform Inventory_Panel = GetComponent<RectTransform>();

        //Vector2 Inventory_false = Inventory_Panel.anchoredPosition - new Vector2(46, 0);
       // Vector2 Inventory_true = Inventory_Panel.anchoredPosition + new Vector2(46, 0);
       // 부드러운 이동은 ~ 언제나 애니메이션이 답이야! 

    }

    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (check)
            {
                check = false;
                SlideInventory(false);

                //Inventory_Panel.anchoredPosition = Vector2.Lerp(Inventory_Panel.anchoredPosition, Inventory_false, Time.deltaTime); 
            }
            else
            {
                check = true;
                SlideInventory(true);
                //Inventory_Panel.anchoredPosition += new Vector2(46, 0);
                // Inventory_Panel.anchoredPosition = Vector2.Lerp(Inventory_Panel.anchoredPosition, Inventory_true, Time.deltaTime);
            }

                OnInventoryOpen(check);
        }

        if (check == true)
        {

            
            //panel 위치가 움직이여함

            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                Debug.Log("위로 스크롤 확인 ");
                scrollRectView.anchoredPosition += new Vector2(0, -10);
            }

            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                Debug.Log("아래로 스크롤 확인 ");
                scrollRectView.anchoredPosition += new Vector2(0, 10);
            }
        }

    }

    public void OnPauseClick()
    {
        isPaused = !isPaused;
        //TimeScale 이 0이면 정지, 1이면 정상속도
        Time.timeScale = (isPaused) ? 0.0f : 1.0f;
        //특정 객체와 스크립트를 일시정지- ( 현재 맞춰 추가)
        //카메라와 플레이어 객체 정지 

        var playObj = GameObject.FindGameObjectsWithTag("Camera");
        //카메라의 모든 스크립트 추출 후 정지
        /*
        var scripts = playObj.GetComponents<MonoBehaviour>();

     
        foreach(var script in scripts)
        {
             scripts.enabled = !isPaused;
         }
               */
    }

    public void OnInventoryOpen(bool isOpened)
    {
        /*
        inventoryCG.alpha = (isOpened) ? 1.0f : 0.0f;
        inventoryCG.interactable = isOpened;
        inventoryCG.blocksRaycasts = isOpened;
        */

    }

    public void SlideInventory(bool is2Opened)
    {
        Animator animator = Inventory_Panel.GetComponent<Animator>();
        if (Inventory_Panel != null)
        {
            bool isOpen = animator.GetBool("open");

            animator.SetBool("open", !isOpen);
        }
    }

    

}

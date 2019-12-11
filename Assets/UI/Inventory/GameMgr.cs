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


    //Inventory 의 CanvasGroup 컴포넌트를 저장할 변수 
    public CanvasGroup inventoryCG;

    private bool check;

    // Start is called before the first frame update

    void Start()
    {
        OnInventoryOpen(false);
        check = false;
    }

    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (check)
                check = false;
            else
                check = true;

            OnInventoryOpen(check);
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

        //똑같이 했는데 안돼
        //확장메서드있는데 없다고 떠
        //1시간 삽질 실화냐ㅐ 
        //일부 UI도 정지되게 구현 가능 - 추후 구현-
    }

    public void OnInventoryOpen(bool isOpened)
    {
        inventoryCG.alpha = (isOpened) ? 1.0f : 0.0f;
        inventoryCG.interactable = isOpened;
        inventoryCG.blocksRaycasts = isOpened;


    }

    

}

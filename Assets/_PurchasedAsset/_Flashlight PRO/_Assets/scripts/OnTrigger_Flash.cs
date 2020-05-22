using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 수정 중! 활성화 노노! 
public class OnTrigger_Flash : MonoBehaviour
{

    // 도달했을 시 손전등이 꺼지는 연출
    private Camera mainCamera;
    public GameObject Target_Player;

    public GameObject FlashLamp_Transform;

    public GameObject Flash_Pack;

    private bool FlashState = true;
    private bool CoroutineState = false;
    float checkangle;
    public float moveSpeed = 0.7f;



    void Start()
    {
        mainCamera = Camera.main;

    }

    // Start is called before the first frame update


    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            //정지

            if (FlashState == true)
            {
                 StartCoroutine(MoveOutPanel());

                
            }

            else
            {
                Target_Player.gameObject.GetComponent<Player_HJ>().enabled = true;
                mainCamera.gameObject.GetComponent<FirstPersonCamera>().enabled = true;
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
                Flash_Pack.SetActive(false);
            }
            // 파티클 실행

            // 손전등 내림 


            //Debug.Log("충돌! 닿았습니까? 그렇다면 손전등을 내놓고 가세요! ");
            // 한번 실행하면 그것으로 끝! 이 콜라이더도 비활성화! 



        }


    }
    // 로테이션 이동- 어우 개  빡 치 네! 가 생각나네!
    IEnumerator MoveOutPanel()
    {
        FlashState = true;

        Target_Player.gameObject.GetComponent<Player_HJ>().enabled = false;
        mainCamera.gameObject.GetComponent<FirstPersonCamera>().enabled = false;

        Quaternion targetSet = FlashLamp_Transform.transform.rotation;
     //   Quaternion bRotation = FlashLamp_Transform.transform.rotation + new Vector3(0,0,0);
        Quaternion bRotation = Quaternion.Euler(targetSet.eulerAngles + new Vector3(0, 0, 20));

        while (true)
        {
            yield return new WaitForSeconds(0.01f);

            float step = moveSpeed * Time.deltaTime;
            FlashLamp_Transform.transform.rotation = Quaternion.Slerp(targetSet, bRotation, step);


            checkangle = Quaternion.Angle(bRotation, FlashLamp_Transform.transform.rotation);

            if (checkangle <= 0)
            {

                break;

            }

        }

        FlashState = false;



        //Mathf.Lerp ( 시작점, 종료점, 거리비율을 받는데 )
        // 시작점에는 오브젝트의 현재 위치를 받고 - 종료점에는 오브젝트 현재 위치 + 10.
        // 다시 시작점에는 오브젝트의 종료 위치를 받고 - 종료점에는 그 시작점의 + 10.


    }



}

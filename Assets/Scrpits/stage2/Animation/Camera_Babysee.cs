using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Babysee : MonoBehaviour
{

    public Animation anim;
    private GameObject _ClickDoor;



// Start is called before the first frame update
void Start()
    {
        // 다른 오브젝트의 애니메이션을 가지고 온다
        anim = GameObject.Find("Main Camera").GetComponent<Animation>();
    }

    private GameObject GetClickedObject()
    {
        RaycastHit hitObj;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //마우스위치를 ray좌표에 넣는다.

        if (true == (Physics.Raycast(ray.origin, ray.direction * 10, out hitObj)))   //마우스 근처에 오브젝트가 있는지 확인

        {
            //있으면 오브젝트를 저장한다.
            _ClickDoor = hitObj.collider.gameObject;

        }

        return _ClickDoor;

    }



    // Update is called once per frame
    void Update()
    {


        //rayInstance = Camera.main.ScreenPointToRay(Input.mousePosition);

        
        if (Input.GetMouseButtonDown(0))
        {
            _ClickDoor = GetClickedObject();



            if (_ClickDoor.Equals(gameObject))
            {
                Debug.Log("문 클릭됨 ");
                Debug.Log("애니메이션 실행코드진입 ");

                anim.Play("See_Baby");

            }
        }
        
    }


}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyesight_baby : MonoBehaviour
{

    private GameObject _underdoor;

    [SerializeField]
    private GameObject go_Camera;


    float moveFloat;
    int speed = 10;
    Vector3 startMarker;
    Vector3 endMarket;

    //   private float fTickTime;

    //   private Vector3 rotation;

    private GameObject GetClickedObject()
    {

        RaycastHit hit;
        GameObject _underdoor = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //마우스 포인트 근처 좌표를 만든다. 

        if (true == (Physics.Raycast(ray.origin, ray.direction * 10, out hit)))   //마우스 근처에 오브젝트가 있는지 확인

        {
            //있으면 오브젝트를 저장한다.
            _underdoor = hit.collider.gameObject;
        }


        return _underdoor;
    }

    // Start is called before the first frame update
    void Start()
    {

        // 카메라의 위치 저장 
       // startMarker = go_Camera.transform.position;
        //endMarket = new Vector3(0.45f, 7.11f, 11.55f);

        //현재 카메라의 월드좌표를 뷰포트 기준좌표로 변환
        // Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

        //go_to_CamValue = transform.position(new Vector3(0.45f, 7.11f, 11.55f));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _underdoor = GetClickedObject();

                if (_underdoor.Equals(gameObject))
                {

                // float fMove = Time.deltaTime * speed;

                // go_to_Camera.transform.position = new Vector3(0.45f, 7.11f, 11.55f);
                //go_Camera.transform.position = Vector3.MoveTowards(go_Camera.transform.position, new Vector3(0.45f, 7.11f, 11.55f), 100);



              //  go_Camera.transform.position = Vector3.Lerp(startMarker,)

                moveFloat += Time.deltaTime * 2.5f;

              
              //  go_Camera.transform.position = Vector3.Lerp(go_Camera.transform.position, new Vector3(0.45f, 7.11f, 11.55f), speed * Time.deltaTime);

              //  if (go_Camera.transform. position = )
             
         
              //  go_Camera.transform.rotation = Quaternion.Euler(1.9f, -173f, -1.3f);
                // 위치는 지정완료. 이동하는데 걸리는 것을 수정



            }
                ///카메라를 움직이는 코드
                // rotation = rotation + new Vector3(0, -180, 0);


            }
    }

}


/*
 
     
     
     
        void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _underdoor = GetClickedObject();

                if (_underdoor.Equals(gameObject))
                {

                 float fMove = Time.deltaTime * speed;

                // go_to_Camera.transform.position = new Vector3(0.45f, 7.11f, 11.55f);
                //go_Camera.transform.position = Vector3.MoveTowards(go_Camera.transform.position, new Vector3(0.45f, 7.11f, 11.55f), 100);

                go_Camera.transform.position = new Vector3(0.45f, 7.11f, 11.55f);

             
         
                go_Camera.transform.rotation = Quaternion.Euler(1.9f, -173f, -1.3f);
                // 위치는 지정완료. 그렇다면 이동하는데 걸리는 것을 수정해야한다. 



            }
                ///카메라를 움직이는 코드를 넣자
                // rotation = rotation + new Vector3(0, -180, 0);


            }
    }

} 
     
     
     
     
     */




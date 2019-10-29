using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_test : MonoBehaviour
{

    private GameObject target;

    private bool state;

    public GameObject[] _Pointstate;

   
    ///[SerializeField] private로 받으면오류가 생긴다. 왜?

    // Use this for initialization
    void Start()
    {
        state = true;
    }

    private GameObject GetClickedObject()
    {

        RaycastHit hit;
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //마우스 포인트 근처 좌표를 만든다. 

        if (true == (Physics.Raycast(ray.origin, ray.direction * 10, out hit)))   //마우스 근처에 오브젝트가 있는지 확인

        {
            //있으면 오브젝트를 저장한다.
            target = hit.collider.gameObject;

        }
        return target;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            target = GetClickedObject();

            if (state == true)
            { 
                 if (target.Equals(gameObject))
                  {
                      //print("마우스 입력 받았음");
                      if (state == true)
                     {
                        if (_Pointstate[0].activeInHierarchy == true)
                        {
                            _Pointstate[0].gameObject.SetActive(false);
                        }
                        else { _Pointstate[0].gameObject.SetActive(true); }

                        if (_Pointstate[1].activeInHierarchy == true)
                        {
                            _Pointstate[1].gameObject.SetActive(false);
                        }
                        else { _Pointstate[1].gameObject.SetActive(true); }

                        if (_Pointstate[2].activeInHierarchy == true)
                        {
                            _Pointstate[2].gameObject.SetActive(false);
                        }
                        else { _Pointstate[2].gameObject.SetActive(true); }

                     

                        //else { _Pointstate[0].gameObject.SetActive(true); }


                        //print("사라져");
                        state = false;
                  }
              }
            }
            else
            {
                if (_Pointstate[0].activeInHierarchy == true)
                {
                    _Pointstate[0].gameObject.SetActive(false);
                }
                else { _Pointstate[0].gameObject.SetActive(true); }

                if (_Pointstate[1].activeInHierarchy == true)
                {
                    _Pointstate[1].gameObject.SetActive(false);
                }
                else { _Pointstate[1].gameObject.SetActive(true); }

                if (_Pointstate[2].activeInHierarchy == true)
                {
                    _Pointstate[2].gameObject.SetActive(false);
                }
                else { _Pointstate[2].gameObject.SetActive(true); }



                state = true;
            }
        }
    }



}

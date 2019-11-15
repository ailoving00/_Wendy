﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour
{

    public GameObject[] _LightButton;
    private GameObject _ResetButton;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <= 7; i++)
        {
           // Debug.Log(i*2);
            _LightButton[i].gameObject.SetActive(false);
            // 전부다 꺼져있던 걸로 시작
        }
        // 
    }


    private GameObject GetClickedObject()
    {

        RaycastHit hit;
        GameObject _ResetButton = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //마우스 포인트 근처 좌표를 만든다. 

        if (true == (Physics.Raycast(ray.origin, ray.direction * 10, out hit)))   //마우스 근처에 오브젝트가 있는지 확인

        {
            //있으면 오브젝트를 저장한다.
            _ResetButton = hit.collider.gameObject;

        }
        return _ResetButton;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _ResetButton = GetClickedObject();

            if (_ResetButton.Equals(gameObject))
            {
                for (int i = 0; i <= 7; i++)
                {
                  //  Debug.Log(i);
                    _LightButton[i].gameObject.SetActive(false);
                    // Debug로 다 정상적으로 돌아가는 것을 확인
                    // 다만 비활성화/활성화 오브젝트가 섞여있을시
                    // 강제로 비활성화된 오브젝트는 활성화, 활성화된 오브젝트는 활성화 되는 오류 존재 
                    // !!!오류해결!!!
                }
            }
        }
    }
}

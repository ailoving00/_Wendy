﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameMgr : MonoBehaviour
{
    public Transform[] points;
    public GameObject Inventory_Panel;
    public RectTransform scrollRectView;
    private Slot[] slots;
    private bool check;


    private bool isPaused;



    void Start()
    {
        check = false;

        RectTransform scrollRectView = GetComponent<RectTransform>();
        RectTransform Inventory_Panel = GetComponent<RectTransform>();

        //Vector2 Inventory_false = Inventory_Panel.anchoredPosition - new Vector2(46, 0);
       // Vector2 Inventory_true = Inventory_Panel.anchoredPosition + new Vector2(46, 0);
       // 부드러운 이동은 ~ 언제나 애니메이션이 답이야! 
    }

   

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
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
              
        }

        //Move scroll
        if (check == true)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0) { scrollRectView.anchoredPosition += new Vector2(0, -20); Debug.Log("위 실행"); }
            if (Input.GetAxis("Mouse ScrollWheel") < 0) { scrollRectView.anchoredPosition += new Vector2(0, 20); Debug.Log("아래 실행"); }
        }
    }


    //Need to modify
    public void OnPauseClick()
    {
        isPaused = !isPaused;
        Time.timeScale = (isPaused) ? 0.0f : 1.0f;

        var playObj = GameObject.FindGameObjectsWithTag("Camera");
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

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class up_Wheel_sprite : MonoBehaviour
{
    public Sprite sprite1;
    public Sprite sprite2;




    // Start is called before the first frame update
    void Start()
    {
       // gameObject.GetComponent<Image>().sprite = Up_sprite1;

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetAxis("Mouse ScrollWheel") < 0)
        //{
            
        //    gameObject.GetComponent<Image>().sprite = sprite2;
        //}
        //else { gameObject.GetComponent<Image>().sprite = sprite1;  }


        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            
            gameObject.GetComponent<Image>().sprite = sprite2;
        }
        else   { gameObject.GetComponent<Image>().sprite = sprite1;  }

    }


}

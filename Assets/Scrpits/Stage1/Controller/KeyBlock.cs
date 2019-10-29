﻿//
//2019-10-29
//도착지에 들어가야하는 블럭
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBlock : MonoBehaviour
{
    public GameObject winText;

    void start()
    {
        GetComponent<Block>().bType = 0;
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Exit")
        //if (coll.gameObject.CompareTag("Exit"))
        {
            winText.SetActive(true);
            Debug.Log("__Exit__");
        }
    }
}

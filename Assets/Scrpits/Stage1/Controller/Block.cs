//
//2019-10-22
//블럭 충돌 관련
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //private Vector3 ColPos;

    public GameObject winText;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //void OnCollisionEnter(Collision coll)
    //{
    //    Debug.Log("__Exit__");

    //    if (coll.gameObject.tag == "Exit")
    //    {
    //        Debug.Log("__Exit__");
    //    }
    //}

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRange : MonoBehaviour
{
    public WendyAI _wendy_ai;

    void Start()
    {
        //_wendy_ai = GameObject.FindObjectOfType<WendyAI>;
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wendy")
        {
            _wendy_ai.CollideWithPlayer();
        }
    }
}

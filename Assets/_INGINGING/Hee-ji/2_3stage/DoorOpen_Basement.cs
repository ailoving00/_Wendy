using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen_Basement : MonoBehaviour
{
    //public Transform _startPos;
    //public Transform _endPos;

    Animator _animator;


    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public void StartDoorAni()
    {
        _animator.SetBool("IsOpening", true);
    }
}

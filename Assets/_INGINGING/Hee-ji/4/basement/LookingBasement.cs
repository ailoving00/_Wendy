using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingBasement : MonoBehaviour
{
    [SerializeField]
    private float range = 5f;

    [SerializeField]
    private LayerMask layerMask;

    private RaycastHit hitInfo;

    public GameObject tempStairs; //지하실 문

    private bool once = false;

    void Start()
    {

    }

    void Update()
    {
        LookAtBasement();
    }

    void LookAtBasement()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitInfo, range, layerMask))
        {
            if (once)
                return;

            once = true;

            DoorOpen_Basement doorAni = tempStairs.GetComponent<DoorOpen_Basement>();
            doorAni.StartDoorAni();

            this.enabled = false;
        }
    }
}

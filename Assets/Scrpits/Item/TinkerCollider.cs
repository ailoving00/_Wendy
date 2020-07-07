using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinkerCollider : MonoBehaviour
{
    private Collider thinkerbell;
    private ItemPickUp CanPick;

    void Start()
    {
        
        thinkerbell = this.gameObject.GetComponent<Collider>();
        thinkerbell.isTrigger = true;
        CanPick = this.gameObject.GetComponent<ItemPickUp>();

        CanPick.enabled = false;

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Floor"))
        {
            //정지

            thinkerbell.attachedRigidbody.useGravity = false;

            CanPick.enabled = true;
            // this.gameObject(false);
            this.enabled = false;


        }

    }
}

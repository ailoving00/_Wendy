using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinkerCollider : MonoBehaviour
{
    private Collider thinkerbell;
    private ItemPickUp CanPick;

    private ActionController_02_VER2 actionCtrler2_script;

    void Start()
    {
        thinkerbell = this.gameObject.GetComponent<Collider>();
        //thinkerbell.isTrigger = true;
        CanPick = this.gameObject.GetComponent<ItemPickUp>();

        //CanPick.enabled = false; //사용불가

        actionCtrler2_script = GameObject.FindObjectOfType<ActionController_02_VER2>();
    }

    //void OnTriggerEnter(Collider other)
    void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Floor"))
        {
            actionCtrler2_script.enabled = true;

            //정지
            thinkerbell.attachedRigidbody.useGravity = false;

            //CanPick.enabled = true; //사용불가
            // this.gameObject(false);

            // +
            Destroy(gameObject.GetComponent<Rigidbody>());

            this.enabled = false;
        }
    }
}

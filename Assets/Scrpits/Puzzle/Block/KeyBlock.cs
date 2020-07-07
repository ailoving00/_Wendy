using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBlock : MonoBehaviour
{
    public NextStage_01 nextStage;



    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("Destination"))
        {
            nextStage.InStartFadeAnim();
        }
    }
}

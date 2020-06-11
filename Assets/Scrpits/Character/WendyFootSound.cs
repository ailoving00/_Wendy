using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WendyFootSound : MonoBehaviour
{
    [SerializeField]
    private string[] floorfootSound;


    void OnTriggerEnter(Collider _col)
    {
        if (_col.gameObject.layer == LayerMask.NameToLayer("Floor"))
        {

            int i = Random.Range(0, 3);
            SoundManger.instance.PlaySound(floorfootSound[i]);

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSound : MonoBehaviour
{

    [SerializeField]
    private string footSound;


    void OnTriggerEnter(Collider _col)
    {
        if (_col.gameObject.layer == LayerMask.NameToLayer("Floor"))
        {
            SoundManger.instance.PlaySound(footSound);
        }
    }
}

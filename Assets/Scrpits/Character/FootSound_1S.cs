using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSound_1S : MonoBehaviour
{

    [SerializeField]
    private string[] snowfootSound;

    [SerializeField]
    private string[] floorfootSound;

    void Start()
    {

    }

    void OnTriggerEnter(Collider _col)
    {
        if (_col.gameObject.layer == LayerMask.NameToLayer("Floor"))
        {
            if(_col.transform.CompareTag("Snow"))
            {
                int i = Random.Range(0, 4);
                SoundManger.instance.PlaySound(snowfootSound[i]);
            }

            if (_col.transform.CompareTag("Floor"))
            {
                int j = Random.Range(0, 4);
                SoundManger.instance.PlaySound(floorfootSound[j]);
            }

        }
    }
}

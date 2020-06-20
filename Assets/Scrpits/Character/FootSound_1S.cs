using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSound_1S : MonoBehaviour
{

    [SerializeField]
    private string[] snowfootSound;

    [SerializeField]
    private string[] floorfootSound;

    bool snowfloorState = true;
    bool woodfloorState = false;


    void FootSound()
    {
        if (snowfloorState == true)
        {
            int i = Random.Range(0, 4);
            SoundManger.instance.PlaySound(snowfootSound[i]);

        }
        //사운드 출력.
        else if (woodfloorState == true)
        {
            int i = Random.Range(0, 4);
            SoundManger.instance.PlaySound(floorfootSound[i]);
        }
        else
        {
            return;
        }

    }


    void OnTriggerEnter(Collider _col)
    {

        if (_col.CompareTag("Snow"))
        {
            snowfloorState = true;
            woodfloorState = false;
        }

        if (_col.CompareTag("Floor"))
        {
            snowfloorState = false;
            woodfloorState = true;

        }


    }

    //void OnTriggerExit(Collider _col)
    //{

    //    if (_col.CompareTag("Floor"))
    //    {
    //        carpetfloorState = false;
    //        woodfloorState = true;

    //    }

    //}

    //void OnTriggerEnter(Collider _col)
    //{
    //    if (_col.gameObject.layer == LayerMask.NameToLayer("Floor"))
    //    {
    //        if(_col.transform.CompareTag("Snow"))
    //        {
    //            int i = Random.Range(0, 4);
    //            SoundManger.instance.PlaySound(snowfootSound[i]);
    //        }

    //        if (_col.transform.CompareTag("Floor"))
    //        {
    //            int j = Random.Range(0, 4);
    //            SoundManger.instance.PlaySound(floorfootSound[j]);
    //        }

    //    }
    //}
}

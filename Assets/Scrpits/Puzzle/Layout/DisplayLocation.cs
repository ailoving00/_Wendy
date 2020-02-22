using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayLocation : MonoBehaviour
{
    public bool state = false; //있으면 true, 없으면 false
    public int location_Num = 0;

    void Start()
    {
    }

    void Update()
    {

    }

    public void setup_Doll(GameObject obj)
    {
        Instantiate(obj, gameObject.transform.position, Quaternion.identity);

        state = true;
    }

    public void take_Doll()
    {
        state = false;
    }

    public bool tryToPut_doll()
    {
        if (state) //인형이 놓여진 상태일때
            return false;
        else
            return true;
    }
}

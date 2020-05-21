using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chestaction : MonoBehaviour
{


    private Quaternion Right = Quaternion.identity;



    public int Chest_number;
    public GameObject MoveChest;
    public float angle;

    Quaternion targetSet;
    Quaternion bRotation;


    bool CheckState = false;
    bool moveOnState = false;
    bool moveOffState = false;

    float time = 0f;
    float F_time =1f;
    float SetTimeState = 0f;
    float checkangle;

    void Start()
    {
        targetSet = Quaternion.Euler(0, 0, 0);
        bRotation = Quaternion.Euler(new Vector3(0, angle, 0));
        SetTimeState = time;



    }
    void Update()
    {

        if (moveOnState)
        {
            time += Time.deltaTime / F_time;
            this.transform.rotation = Quaternion.Slerp(targetSet, bRotation, time);
            checkangle = Quaternion.Angle(targetSet, MoveChest.transform.rotation);

            if (checkangle >= Mathf.Abs(angle))
            {
                CheckState = true;
                moveOnState = false;
                time = 0f;
                return;
            }
        }

        if(moveOffState)
        {
            time += Time.deltaTime / F_time;
            this.transform.rotation = Quaternion.Slerp(bRotation, targetSet, time);
            checkangle = Quaternion.Angle(targetSet, MoveChest.transform.rotation);

            if (checkangle <= 0)
            {
                CheckState = false;
                moveOffState = false;
                time = 0f;
                return;
            }
        }


        /*
        while (SetTimeState < 1f)
        {
            //Debug.Log("실행중");
            time += Time.deltaTime / F_time;
            this.transform.rotation = Quaternion.Slerp(targetSet, bRotation, time);
            SetTimeState += Time.deltaTime / F_time;
        }
        */
    }

    public void Start_action(int type)
    {
        if (type == 1)
        {

            if (!CheckState)
            {
                moveOnState = true;
                return;
            }

            else
            {
                moveOffState = true;
                return;

            }

        }

    }


}




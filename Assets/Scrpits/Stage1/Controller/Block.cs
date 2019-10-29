//
//2019-10-29
//블럭 이동 관련 o (단, 도착했을시 수정필요하다. BeBlockedByWall, clear부분)
//블럭끼리 충돌 x
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    enum BlockType { Me, H2, H3, V2, V3, };
    enum Axis { X, Y, Z };

    public float speed;

    private bool isMoving;

    private Vector3 myPos;
    private Vector3 direction;

    //[Range(-2.6f, 2.6f)]
    private Vector3 destination;

    private Axis axis;
    private BlockType blockType;
    public int bType;

    private bool clear;

    void Start()
    {
        speed = 10f;

        isMoving = false;
        direction = Vector3.zero;
        destination = Vector3.zero;

        blockType = (BlockType)bType;

        clear = false;
    }

    void Update()
    {
        if (clear)
            return;

        if (isMoving)
        {
            float step = speed * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, destination, step);
            //transform.Translate(direction * step);

            if (transform.position == destination)
            {
                isMoving = false;

                if (transform.position.x == -3.9f &&
                    transform.position.y == 0.6500001f )       //클리어
                    clear = true;
            }
        }
    }

    public void Move(Vector3 dir, int a)
    {
        axis = (Axis)a;

        if (axis == Axis.X)
        {
            direction = dir;
            //direction = dir.normalized;

            destination = transform.position + (direction * 1.3f);

            if (!BeBlockedByWall())
                return;

            isMoving = true;
        }
        else //(axis == Axis.Y)
        {
            direction = dir;
            //direction = dir.normalized;

            destination = transform.position + (direction * 1.3f);

            if (!BeBlockedByWall())
                return;

            isMoving = true;
        }
    }

    private bool BeBlockedByWall() //Mathf.Clamp    
    {
        if (axis == Axis.X)
        {
            if (blockType == BlockType.Me && direction.x == -1f)
            {
                if (transform.position.x == -2.6f &&
                    transform.position.y == 0.6500001f)
                    return true;
            }

            if (destination.x >= -2.6f && 
                destination.x <= 2.6f)
                return true;
        }
        else
        {
            if (destination.y >= -3.25f &&
                destination.y <= 3.25f)
                return true;
        }

        return false;
    }

    public int GetBlockType()
    {
        return (int)blockType;
    }

    public void SetBlockType(int bt)
    {
        blockType = (BlockType)bt;
    }
}

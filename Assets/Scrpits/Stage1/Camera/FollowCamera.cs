//
//2019-10-21
//플레이어 고정 카메라 이동
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject target;
    //private Transform target;
    Vector3 offset;

    float xMax, xMin, yMax, yMin;

    //[SerializeField]
    //Tilemap tilemap;

    void Start()
    {
        //target = GameObject.FindGameObjectWithTag("Player").transform;

        //player = target.GetComponent<Player>();

        //Vector3 minTile = tilemap.CellToWorld(tilemap.cellBounds.min);
        //Vector3 maxTile = tilemap.CellToWorld(tilemap.cellBounds.max);

        //SetLimits(minTile, maxTile);
        //player.SetLimits(minTile, maxTile);


        offset = target.transform.position - transform.position;
    }

    void LateUpdate()
    {
        //float minClamp = Mathf.Clamp(target.position.x, xMin, xMax);
        //float maxClamp = Mathf.Clamp(target.position.y, yMin, yMax);

        //transform.position = new Vector3(minClamp, maxClamp, -10);


        Quaternion rotation = Quaternion.Euler(0, 0, 0);
        transform.position = target.transform.position - (rotation * offset);

        transform.LookAt(target.transform);
    }

    private void SetLimits(Vector3 minTile, Vector3 maxTile)
    {
        Camera cam = Camera.main;

        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;

        xMin = minTile.x + width / 2;
        xMax = maxTile.x - width / 2;

        yMin = minTile.y + height / 2;
        yMax = maxTile.y - height / 2;
    }
}

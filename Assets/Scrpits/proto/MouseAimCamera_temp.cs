//
//2019-10-13
//우클릭으로 카메라 에임 돌리기
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAimCamera_temp : MonoBehaviour
{
    public GameObject target;
    public float rotateSpeed = 5;

    FollowCamera_temp followCamera;
    Vector3 offset;

    void Start()
    {
        followCamera = GameObject.Find("MainCamera").GetComponent<FollowCamera_temp>();
        offset = followCamera.offset;
    }

    void LateUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            offset = followCamera.offset;

            float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
            target.transform.Rotate(0, horizontal, 0);

            float desiredAngleY = target.transform.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0, desiredAngleY, 0);
            transform.position = target.transform.position - (rotation * offset);
        }
    }
}

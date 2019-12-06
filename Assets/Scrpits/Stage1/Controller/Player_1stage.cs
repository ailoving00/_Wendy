//
//2019-12-06
//3인칭용 (1스테이지용)
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_1stage : MonoBehaviour
{
    [SerializeField]
    private Transform[] exitPoints;
    private int exitIndex = 0;

    private Vector3 min, max;

    [SerializeField]
    public Transform myTarget { get; set; } //마우스로 선택한 오브젝트

    float h, v;

    public float movementSpeed = 2;
    public float turningSpeed = 5;

    Animator _animator = null;

    public float latestKeyCheck;

    int rudder;
    bool check;

    float MaxDistance = 8f;

    public float currentAngle;
    public float desiredAngle;
    public float angle;
    public GameObject target;

    Ray ray;

    public GameObject standard;

    private Vector3[] s_vec;
    private Vector3 t_vec; //타겟기준벡터
    private Vector3 tv_vec; //타겟기준벡터

    public float atanAngle;

    int anglecheck;

    Vector3 dir;

    public float zangle;
    private float zMin;
    private float zMax;
    public float desiredZAngle;
    public float currentZAngle;
    public GameObject center;
    public float ZturningSpeed = 1;
    private bool ZCheck; //안씀 check를 사용한다

    public float xangle;
    private float xMin;
    private float xMax;
    public float desiredXAngle;
    public float currentXAngle;

    float th, tv;

    void Start()
    {
        _animator = GameObject.Find("wendy_umuni_rigging").GetComponent<Animator>();
        //_animator = GetComponent<Animator>();

        check = false;

        s_vec = new Vector3[4];
        s_vec[0] = standard.transform.forward - standard.transform.position;
        s_vec[1] = -standard.transform.right - standard.transform.position;
        s_vec[2] = -standard.transform.forward - standard.transform.position;
        s_vec[3] = standard.transform.right - standard.transform.position;

        atanAngle = 0.0f;
        anglecheck = 0;

        zangle = 0.0f;
        zMin = -7f;
        zMax = 7f;

        xangle = 0.0f;
        xMin = -7f;
        xMax = 7f;

        ZCheck = false;
    }

    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        standard.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        
        if (v == 0 & h == 0)
        {
            _animator.SetBool("IsWalking", false);
            check = true;
        }
        else //if (v != 0)
        {
            tv = v; th = h;
            dir = h * Vector3.left + v * Vector3.back;
            transform.position = transform.position + dir * movementSpeed * Time.deltaTime;

            _animator.SetBool("IsWalking", true);
            check = false;

            if (v == -1) //앞
            {
                desiredXAngle = xMin;
            }
            else if (v == 1)
            {
                desiredXAngle = xMax;
            }
            else if (v == 0)
            {
                desiredXAngle = 0;
            }

            currentXAngle = target.transform.eulerAngles.x; //center
            xangle = Mathf.LerpAngle(currentXAngle, desiredXAngle, Time.deltaTime * ZturningSpeed);

            if (h == -1) //left
            {
                desiredZAngle = zMin;
                ZCheck = true;
            }
            else if (h == 1)
            {
                desiredZAngle = zMax;
                ZCheck = true;
            }
            else if (h == 0)
            {
                desiredZAngle = 0;
                ZCheck = false;
            }

            currentZAngle = target.transform.eulerAngles.z; //center
            zangle = Mathf.LerpAngle(currentZAngle, desiredZAngle, Time.deltaTime * ZturningSpeed);

            //캐릭터의 회전 ***********

            atanAngle = CalculateAngle(-standard.transform.forward, dir);

            currentAngle = target.transform.eulerAngles.y;
            desiredAngle = atanAngle;

            angle = Mathf.LerpAngle(currentAngle, desiredAngle, Time.deltaTime * turningSpeed);

            Quaternion rotation = Quaternion.Euler(xangle, angle, zangle);
            target.transform.rotation = rotation;
            
            Debug.DrawRay(standard.transform.position, dir * MaxDistance, Color.blue, 0.3f);
        }

        if (check)
        {
            currentXAngle = target.transform.eulerAngles.x;
            xangle = Mathf.LerpAngle(currentXAngle, 0, Time.deltaTime * ZturningSpeed);

            currentZAngle = target.transform.eulerAngles.z;
            zangle = Mathf.LerpAngle(currentZAngle, 0, Time.deltaTime * ZturningSpeed);

            Quaternion rotation2 = Quaternion.Euler(xangle, target.transform.eulerAngles.y, zangle);
            target.transform.rotation = rotation2;
        }
    }

    public void SetLimits(Vector3 min, Vector3 max)
    {
        this.min = min;
        this.max = max;
    }

    public static float GetAngle(Vector3 vStart, Vector3 vEnd)
    {
        Vector3 v = vEnd - vStart;

        return Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
    }

    public static float CalculateAngle(Vector3 from, Vector3 to)
    {
        return Quaternion.FromToRotation(from, to).eulerAngles.y;
    }

    float ClampZAngle(float angle, float min, float max)
    {
        if (angle < min)
            angle = min;
        if (angle > max)
            angle = max;
        return Mathf.Clamp(angle, min, max);
    }
}

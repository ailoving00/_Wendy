using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_HJ : MonoBehaviour
{
    private Vector3 min, max;
    private float h, v;

    public float movementSpeed = 10;
    public float turningSpeed = 60;

    Animator _animator = null;

    public bool gameEnd;

    public GameObject playerObj; //벡터
    public GameObject playerObj_normal; //법선벡터

    private Vector3 targetForward;
    private Vector3 targetNormal_Forward;

    public GameObject playerModeling;

    void Start()
    {
        //_animator = GameObject.Find("wendy_umuni_rigging").GetComponent<Animator>();
        _animator = playerModeling.GetComponent<Animator>();

        gameEnd = false;
    }

    //protected override void Update() //활동제한
    //{
    //    //Executes the GetInput function
    //    GetInput();

    //    float xMinClamp = Mathf.Clamp(transform.position.x, min.x, max.x);
    //    float yMinClamp = Mathf.Clamp(transform.position.y, min.y, max.y);

    //    transform.position = new Vector3(xMinClamp, yMinClamp, transform.position.z);
    //}
    void Update()
    {
        if (gameEnd)
            return;

        GetInput();
    }

    private void GetInput()
    {
        targetForward = playerObj.transform.rotation * Vector3.forward; //localRotation -> rotation
        targetNormal_Forward = playerObj_normal.transform.rotation * Vector3.forward;


        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        // - Animation transition
        if (h == 0 && v == 0)
        {
            _animator.SetBool("IsWalking", false);
            //Debug.Log("Arrow Button Released");
        }
        else
        {
            _animator.SetBool("IsWalking", true);

            targetForward = playerObj.transform.rotation * Vector3.forward; //localRotation -> rotation
        }

        // - 디버그
        Debug.DrawRay(playerObj.transform.position, targetForward, Color.blue);

        // - 움직임2
        //앞뒤
        if (v == 1)
        {
            transform.Translate(-targetForward.x * movementSpeed * Time.deltaTime, 0, -targetForward.z * movementSpeed * Time.deltaTime);
        }
        else if (v == -1)
        {
            transform.Translate(targetForward.x * movementSpeed * Time.deltaTime, 0, targetForward.z * movementSpeed * Time.deltaTime);
        }
        //좌우
        if (h == 1)
        {
            transform.Translate(-targetNormal_Forward.x * movementSpeed * Time.deltaTime, 0, -targetNormal_Forward.z * movementSpeed * Time.deltaTime);
        }
        else if (h == -1)
        {
            transform.Translate(targetNormal_Forward.x * movementSpeed * Time.deltaTime, 0, targetNormal_Forward.z * movementSpeed * Time.deltaTime);
        }
    }

    public void SetLimits(Vector3 min, Vector3 max)
    {
        this.min = min;
        this.max = max;
    }
}

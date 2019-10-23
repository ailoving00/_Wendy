//
//2019-10-22
//자동차 퍼즐 조작
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_test : MonoBehaviour
{
    public Camera _mainCam = null;

    private GameObject target = null; //mouse target

    private GameObject _blockPrefab;
    private GameObject[] _blocks;
    public GameObject _exit; //탈출구
    public GameObject _me; //옮겨야할 블럭

    private Vector3 MousePos;
    private bool _targetState = false;

    void Start()
    {
        if (_blocks == null)
            _blocks = GameObject.FindGameObjectsWithTag("Block");

        //foreach (GameObject block in _blocks)
        //{
        //    Instantiate(_blockPrefab, block.transform.position, block.transform.rotation);
        //}
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            target = GetClickedObject();

            if (target != null)
            {
                if (target.tag == "Block")
                {
                    _targetState = true;

                    Debug.Log(target.GetComponent<Collider>().name);
                }
            }
        }
        else if (true == Input.GetMouseButtonUp(0))
        {
            _targetState = false;
        }

        if (true == _targetState)
        {
            OnMouseDrag();
        }
        else
        {

        }
    }
    //void OnMouseDown() {}

    private GameObject GetClickedObject()
    {
        RaycastHit hit;

        GameObject target = null;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (true == (Physics.Raycast(ray.origin, ray.direction * 10, out hit)))
        {
            target = hit.collider.gameObject;
        }

        return target;
    }

    private Vector3 OnMouseDrag()
    {
        MousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                                                              Input.mousePosition.y,
                                                              -Camera.main.transform.position.z));
        target.transform.position = new Vector3(MousePos.x, MousePos.y, target.transform.position.z);

        //print(MousePos);

        return MousePos;
    }
}

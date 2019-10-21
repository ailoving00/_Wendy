using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_test : MonoBehaviour
{
    public Camera _mainCam = null;

    private GameObject target = null; //mouse target
    public GameObject cube; //나중에 tag 사용

    private Vector3 MousePos;
    private bool _targetState = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            target = GetClickedObject();

            if (target != null && target.Equals(cube))
            {
                _targetState = true;

                //Debug.Log(target.GetComponent<Collider>().name);
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

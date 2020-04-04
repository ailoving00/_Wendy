using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FramePuzzle_Enter : MonoBehaviour
{
    Ray Mouse_ray;
    int FramelayerMask;
    private float range = 2.5f;
    RaycastHit hitInfo;

    int CamObstacle_layerMask;
    Camera camera;

    FramePuzzle_ChangeCam fpCameraController;

    bool puzzleEnd = false;

    void Start()
    {
        camera = GetComponent<Camera>(); //메인카메라

        FramelayerMask = (1 << LayerMask.NameToLayer("FramePuzzle"));
        CamObstacle_layerMask = (1 << LayerMask.NameToLayer("Obstacle")) + (1 << LayerMask.NameToLayer("FramePuzzle"));

        fpCameraController = GameObject.FindObjectOfType<FramePuzzle_ChangeCam>();
    }

    bool test = false;

    void Update()
    {
        TryAction();

        //if (test)
        //    Debug.DrawRay(Mouse_ray.origin, Mouse_ray.direction * range, Color.red, range);
    }

    void TryAction()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (puzzleEnd)
                return;

            //test = true;

            //스크린 클릭
            Vector3 p = Input.mousePosition;
            Mouse_ray = camera.ScreenPointToRay(Input.mousePosition);

            ClickFrame();
        }
    }

    void ClickFrame()
    {
        if (Physics.Raycast(Mouse_ray, out hitInfo, range, CamObstacle_layerMask))// 벽이 아닌지도 검사 
        {
            if (hitInfo.transform.CompareTag("Frame"))
            {
                fpCameraController.change_Camera(true);
            }
        }
    }

    public void set_puzzleEnd()
    {
        puzzleEnd = true;
    }
}

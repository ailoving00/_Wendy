using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCam_1stage : MonoBehaviour
{
    private Camera mainCamera;
    private Camera fpCamera;

    private AudioListener mainListener;
    private AudioListener fpListener;

    public bool PuzzlPlay = false;

    FadeAni_Spotlight spotlight_script;
    ActionController_01 actionController;

    void Start()
    {
        mainCamera = Camera.main;
        fpCamera = GetComponent<Camera>();

        mainListener = mainCamera.GetComponent<AudioListener>();
        fpListener = GetComponent<AudioListener>();

        //초기화
        mainListener.enabled = true;
        fpListener.enabled = false;

        spotlight_script = GameObject.FindObjectOfType<FadeAni_Spotlight>();
        actionController = mainCamera.GetComponent<ActionController_01>();
    }

    void Update()
    {

    }

    public void change_Camera(int type)
    {
        if (type == 1) //퍼즐 카메라 on
        {
            actionController.enabled = false;

            spotlight_script.InStartFadeAnim();

            PuzzlPlay = true;

            fpCamera.enabled = true;
            fpListener.enabled = true;

            mainCamera.enabled = false;
            mainListener.enabled = false;
        }
        else //if(type == 0) //다시 돌아가기
        {
            actionController.enabled = false;

            spotlight_script.stop_coroutine();

            PuzzlPlay = false;

            mainCamera.enabled = true;
            mainListener.enabled = true;

            fpCamera.enabled = false;
            fpListener.enabled = false;
        }
    }

    public bool get_PuzzlPlay()
    {
        return PuzzlPlay;
    }
}

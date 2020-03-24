using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class return_mainCam : MonoBehaviour
{
    ChangeCam_1stage ChangeCam_script;

    void Start()
    {
        ChangeCam_script = GameObject.FindObjectOfType<ChangeCam_1stage>();
    }

    void Update()
    {
        
    }

    void OnMouseDown()
    {
        ChangeCam_script.change_Camera(0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{
    public void StartButton()
    {
        // - 로딩씬

        SceneManager.LoadScene("01_Stage"); //임시

    }

    public void ExitButton()
    {
        Application.Quit();
    }

    void Start()
    {
        // 변경 필요함
        Screen.SetResolution(1920, 1080, false);
    }

    void Update()
    {
        
    }
}

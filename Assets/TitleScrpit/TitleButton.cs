using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{

    public void StartButton()
    {
        SceneManager.LoadScene("01_Stage");
    }

    public void ExitButton()
    {
        Application.Quit();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}

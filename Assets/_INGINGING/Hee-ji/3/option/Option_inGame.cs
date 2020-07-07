using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Option_inGame : MonoBehaviour
{
    public GameObject _option_window;
    public Slider _music_slider;
    public Slider _fx_slider;
    public Slider _bright_slider;

    // - 옵션 싱글톤, DontDestroy
    OptionManager option_manager_script;

    // - 옵션 슬라이더
    BrightnessController _brightness_ctrler_script;

    //// - 사운드
    //SoundManger songManager_script;

    // - 버튼 컨트롤
    GameMgr gameMgr_script;

    void Start()
    {
        option_manager_script = FindObjectOfType<OptionManager>();

        _brightness_ctrler_script = _bright_slider.gameObject.GetComponent<BrightnessController>();

        //InitSliderValue(); //GameMgr 스크립트로 옮김

        //songManager_script = FindObjectOfType<SoundManger>();

        gameMgr_script = GameObject.FindObjectOfType<GameMgr>();

    }

    public void InitSliderValue()
    {
        float temp_music = option_manager_script.GetMusicVolume();
        float temp_fx = option_manager_script.GetFXVolume();
        float temp_bright = option_manager_script.GetBrightnessVolume();

        // 슬라이더에 실제 값 적용
        _brightness_ctrler_script.Initialization(temp_bright);
    }

    //- 오류남 @@@@
    public void DelegateSliderValue()
    {
        //option_manager_script.SetMusicVolume(_music_slider.value);

        //option_manager_script.SetFXVolume(_fx_slider.value);

        ////option_manager_script.SetBrightnessVolume(_bright_slider.value);
        //option_manager_script.SetBrightnessVolume(_brightness_ctrler_script.GetSliderValue());
    }

    // = = = =
    //- 슬라이더 연결되어있음

    // = = = =
    // - 버튼

    public void ClickContinueButtorn()
    {
        //if (stage == 1)
        //{
        //    //player_script.enabled = true;
        //    //if (actionCtrler_script.enabled == false)
        //    //    actionCtrler_script.enabled = true;
        //}
        //else if (stage == 2)
        //{

        //}


        gameMgr_script.OptionDisappear();
        //Cursor.lockState = CursorLockMode.None;
        //Time.timeScale = 1f;
        //_option_window.SetActive(false);

    }

    //public void ClickContinueButtorn_2stage()
    //{
    //    //if (stage == 1)
    //    //{
    //    //    //player_script.enabled = true;
    //    //    //if (actionCtrler_script.enabled == false)
    //    //    //    actionCtrler_script.enabled = true;
    //    //}
    //    //else if (stage == 2)
    //    //{

    //    //}

    //    gameMgr_script.OptionDisappear();
    //    //Cursor.lockState = CursorLockMode.Locked;
    //    //Time.timeScale = 1f;
    //    //_option_window.SetActive(false);


    //    // 이동 수정
    //}

    public void ReturnTitleButton()
    {
        // - 메인화면으로 돌아가기
        SceneManager.LoadScene("00_Title");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    void Start()
    {
        option_manager_script = FindObjectOfType<OptionManager>();

        _brightness_ctrler_script = _bright_slider.gameObject.GetComponent<BrightnessController>();

        //InitSliderValue(); //GameMgr 스크립트로 옮김
    }

    void Update()
    {

    }

    public void InitSliderValue()
    {
        float temp_music = option_manager_script.GetMusicVolume();
        float temp_fx = option_manager_script.GetFXVolume();
        float temp_bright = option_manager_script.GetBrightnessVolume();

        // 슬라이더에 실제 값 적용
        _brightness_ctrler_script.Initialization(temp_bright);
    }

    public void DelegateSliderValue()
    {
        option_manager_script.SetMusicVolume(_music_slider.value);

        option_manager_script.SetFXVolume(_fx_slider.value);

        //option_manager_script.SetBrightnessVolume(_bright_slider.value);
        option_manager_script.SetBrightnessVolume(_brightness_ctrler_script.GetSliderValue());
    }

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

        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1f;
        _option_window.SetActive(false);
    }
}

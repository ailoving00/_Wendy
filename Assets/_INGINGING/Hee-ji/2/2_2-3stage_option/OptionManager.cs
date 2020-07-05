using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionManager : MonoBehaviour
{
    //씬 마지막부분에서 옵션값들을 넘겨받고 새로운씬에서 바로 적용
    public static OptionManager _option_manager = null;

    // * 중앙값 채워 넣기
    public float _music_volume = 0.5f;
    public float _fx_volume = 0.5f;
    public float _brightness_volume = 1f;

    void Awake()
    {
        if (_option_manager == null)
        {
            _option_manager = this;
        }
        else if (_option_manager != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {

    }

    void Update()
    {

    }

    // - 값을 전달
    public float GetMusicVolume()
    {
        return _music_volume;
    }
    public float GetFXVolume()
    {
        return _fx_volume;
    }
    public float GetBrightnessVolume()
    {
        return _brightness_volume;
    }

    // - 값을 바꿀때 (씬변경 직후)
    public void SetMusicVolume(float value)
    {
        _music_volume = value;
    }
    public void SetFXVolume(float value)
    {
        _fx_volume = value;
    }
    public void SetBrightnessVolume(float value)
    {
        _brightness_volume = value;
    }

}

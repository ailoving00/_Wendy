using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testsounslider : MonoBehaviour
{

    // Start is called before the first frame update

    public Slider _slider_script;
    public float _volum_value;

    public Image _panel;
    Image _panel_alpha;

    void Awake()
    {
        Debug.Log(_slider_script.normalizedValue);                  //슬라이더 벨류 값 0-1 로 정규화
        _slider_script = gameObject.GetComponent<Slider>();
        _panel_alpha = _panel.GetComponent<Image>();
    }

    public void SetMusicVolum(float volume)
    {
        //Color color = _panel_alpha.color;
       // color.a = 0.9f - _slider_script.normalizedValue;
        //_panel_alpha.color = color;

        AudioListener.volume = volume;



    }
    
    //void Update()
    //{
    //    AudioListener.volume = _volum_value;
    //}
}

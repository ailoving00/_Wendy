using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
    // - 밝기 조절
    public Slider _slider; 
    float intensityValue = 1f;


    public void BrightnessSlider()
    {
        intensityValue = _slider.value;
        RenderSettings.ambientIntensity = intensityValue;
    }


    //public float GammaCorrection;
    //public Rect SliderLocation;
    //float rgbValue = 0.5f;
    //void Update()
    //{
    //    RenderSettings.ambientLight = new Color(GammaCorrection, GammaCorrection, GammaCorrection, 1.0f);
    //}
    //void OnGUI()
    //{
    //    //1
    //    GammaCorrection = GUI.HorizontalSlider(SliderLocation, GammaCorrection, 0, 1.0f);
    //    //2
    //    rgbValue = GUI.HorizontalSlider(new Rect(Screen.width / 2 - 50, 90, 100, 30), rgbValue, 0f, 1f);
    //    RenderSettings.ambientLight = new Color(rgbValue, rgbValue, rgbValue, 1);
    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroPanel_1stage : MonoBehaviour
{
    private float FadeTime = 3f; // Fade효과 재생시간

    Image fadeImg;

    float start;
    float end;

    float time = 0f;

    Player_1stage playerCtrler_script;
    ActionController_01 actionCtrler;
    GameMgr gameManageer;

    void Start()
    {
        fadeImg = GetComponent<Image>();

        playerCtrler_script = GameObject.FindObjectOfType<Player_1stage>();
        actionCtrler = GameObject.FindObjectOfType<ActionController_01>();
        gameManageer = GameObject.FindObjectOfType<GameMgr>();

        actionCtrler.enabled = false;
        gameManageer.enabled = false;

        InStartFadeAnim();
    }

    void Update()
    {

    }

    //페이드아웃
    public void InStartFadeAnim()
    {
        // - 시간차를 둬야함, 
        playerCtrler_script.enabled = false;

        Color fadecolor = fadeImg.color;
        fadecolor.a = 1f;
        fadeImg.color = fadecolor;

        time = 0f;
        start = 1f;
        end = 0f;

        StartCoroutine(fadeIntanim());
    }

    IEnumerator fadeIntanim()
    {
        yield return new WaitForSeconds(1f);

        Color fadecolor = fadeImg.color;

        while (fadecolor.a > 0.01f)
        {
            time += Time.deltaTime / FadeTime;
            fadecolor.a = Mathf.Lerp(start, end, time);
            fadeImg.color = fadecolor;
            //yield return null;
            yield return new WaitForSeconds(0.01f);
        }

        fadecolor.a = 0f;
        fadeImg.color = fadecolor;

        playerCtrler_script.enabled = true;
        actionCtrler.enabled = true;
        gameManageer.enabled = true;
    }
}

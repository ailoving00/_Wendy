using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound_PUZZLE
{
    public string name;    //곡의 이름
    public AudioClip clip; //곡
}

public class SoundManger : MonoBehaviour
{
    static public SoundManger instance;



#region singleton
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
#endregion singleton     
     


    public AudioSource[] audioEffects;  //폭탄소리 총소리 발소리 괴물소리 - 동시에 재생가능하게 배열
    public AudioSource audioBgm;        // 브금을 재생시키기 위한 오디오 소스 - 하나면 충분.

    public AudioSource[] AddEffectSound;

    public string[] playSoundName;

    public Sound_PUZZLE[] effectSound;         //이펙스 사운드 저장
    public Sound_PUZZLE[] bgmSound;            //브금 사운드 저장


    float volumeSave;
    float BGMSettingVolume = 0.5f;
    float EffectSettingVolume = 0.5f;

    void start()
    {
        playSoundName = new string[audioEffects.Length];

        //기본은 0.5 전부 0.5로 초기화 

        // 기본 세팅 값의 사운드를 넣어주어야한다. 

        audioBgm.volume = 0.5f;

        for (int j = 0; j < audioEffects.Length; j++) //재생되어있지 않은 오디오를 찾기 
        {
            audioEffects[j].volume = 0.5f;
            //EffectSettingVolume = 0.5f;
            //Debug.Log(EffectSettingVolume);
        }


    }

    public void BGMSetMusicVolum(float vloume)
    {
        audioBgm.volume = vloume;
    }

    public void EffectSetMusicVolum(float vloume)
    {
        for (int j = 0; j < audioEffects.Length; j++) //재생되어있지 않은 오디오를 찾기 
        {
            audioEffects[j].volume = vloume;
        }
    }

    public void Effect_2SSetMusicVolum(float vloume)
    {
        for (int i = 0; i < audioEffects.Length; i++) //재생되어있지 않은 오디오를 찾기 
        {
            audioEffects[i].volume = vloume;
            EffectSettingVolume = vloume;
        }

        for (int j = 0; j < AddEffectSound.Length; j++) //재생되어있지 않은 오디오를 찾기 
        {
            AddEffectSound[j].volume = vloume;
        }
    }

    //이름이 입력되면 -> Sound배열안에 맞는 이름이 있는지 찾고 -> 있다면 AudioSource에 넣어서 재생
    public void PlaySound(string _name)
    {
        for (int i = 0; i < effectSound.Length; i++)
        {
            if(_name == effectSound[i].name)
            {
                for (int j = 0; j < audioEffects.Length; j++) //재생되어있지 않은 오디오를 찾기 
                {
                    if (!audioEffects[j].isPlaying) //재생중이지 않은것은 안걸림 
                    {
                        //Debug.Log(_name + "존재합니다 ");
                        playSoundName[i] = effectSound[i].name; //재생중인 효과이름을 사운드 이름에 넣어줍니다
                        audioEffects[i].clip = effectSound[i].clip;
                        audioEffects[i].Play();
                        return;
                    }

                }
                Debug.Log("모든 가용 AudioSource가 사용중입니다 ");
                return;
            }

         
               // Debug.Log(_name+"사운드가 존재하지않습니다. ");
        }
        
    }

    // 조정하고 싶은 오디오 이름과 볼륨을 입력받음
    public void PlaySoundVolume(string _name,float volumeSet)
    {
        for (int i = 0; i < effectSound.Length; i++)
        {
            if (_name == effectSound[i].name)
            {
                for (int j = 0; j < audioEffects.Length; j++) //재생되어있지 않은 오디오를 찾기 
                {

                    if (!audioEffects[j].isPlaying) //오디오가 재생중이지 않다면
                    {
                        //Debug.Log(_name + "존재합니다 ");
                        playSoundName[i] = effectSound[i].name; //재생중인 효과이름을 사운드 이름에 넣어줍니다
                        audioEffects[i].clip = effectSound[i].clip;//오디오에 해당 사운드 넣고 재생

                        //해당 오디오의 원래 볼륨 저장 

                        //오디오의 원래 볼륨을 받고 조절하고 싶은 수치를 *. 그리고 따른 곳에 저장
                        //float volumeSave = audioEffects[i].volume;

                        float effectvolume = EffectSettingVolume * volumeSet;
                        //audioEffects[i].volume = SettingVolume;
                        //Debug.Log(SettingVolume);

                        //조정된 해당 볼륨 출력 완료 
                        audioEffects[i].volume = effectvolume;
                        audioEffects[i].Play();

                        return;
                    }



                }
                Debug.Log("모든 가용 AudioSource가 사용중입니다 ");
                return;
            }


            // Debug.Log(_name+"사운드가 존재하지않습니다. ");
        }

    }

    //BGM 사운드 플레이 
    public void PlayBGMSound(string _name)
    {
        for (int i = 0; i < bgmSound.Length; i++)
        {
            if (_name == bgmSound[i].name)
            {
                playSoundName[i] = bgmSound[i].name; //재생중인 효과이름을 사운드 이름에 넣어줍니다
                audioBgm.clip = bgmSound[i].clip;


                audioBgm.Play();
                return;

            }
            //Debug.Log("모든 가용 AudioSource가 사용중입니다 ");
            return;
        }
        //Debug.Log(_name + "사운드가 존재하지않습니다. ");
    }

    //BGM 사운드 플레이 
    public void PlayBGMSoundVolume(string _name, float volumeSet)
    {
        for (int i = 0; i < bgmSound.Length; i++)
        {
            if (_name == bgmSound[i].name)
            {
                playSoundName[i] = bgmSound[i].name; //재생중인 효과이름을 사운드 이름에 넣어줍니다
                audioBgm.clip = bgmSound[i].clip;

                float bgmvolume = BGMSettingVolume * volumeSet;
                //audioEffects[i].volume = SettingVolume;
                //Debug.Log(SettingVolume);

                //조정된 해당 볼륨 출력 완료 
                audioBgm.volume = bgmvolume;
                audioBgm.Play();

                return;

            }
            //Debug.Log("모든 가용 AudioSource가 사용중입니다 ");
            return;
        }
        //Debug.Log(_name + "사운드가 존재하지않습니다. ");
    }



    //모든 사운드 정지
    public void StopALLSound()
    {
        for (int i = 0; i < audioEffects.Length; i++)
        {
            audioEffects[i].Stop();
        }

        audioBgm.Stop();

    }

    //BGM사운드 정지 
    public void StopBGMSound(string _name)
    {
        audioBgm.Stop();
    }



    //효과음 사운드 정지 
    public void StopEffectSound(string _name)
    {
        for (int i = 0; i < audioEffects.Length; i++)
        {
            if(playSoundName[i] == _name)
            {
                audioEffects[i].Stop();
                return;
            }
        }
        //Debug.Log("재생중인" + _name + "사운드가 없습니다.");
    }





}




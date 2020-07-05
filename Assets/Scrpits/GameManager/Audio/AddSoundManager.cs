using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSoundManager : MonoBehaviour
{
    [SerializeField]
    private string[] RondomSound;

    [SerializeField]
    private string CellarSound = "Cellar_breakon";

    public GameObject ToiletSound;
    public AudioClip ToiletWater;
    AudioSource WaterAudio; //컴퍼넌트에서 AudioSource가져오기


    public GameObject FireWall;
    AudioSource FirePlay;
    public ParticleSystem FireEffect;





    
    float Daleytime;

    // Start is called before the first frame update
    void Start()
    {


        WaterAudio = ToiletSound.GetComponent<AudioSource>();  //myAudio에 컴퍼넌트에있는 AudioSource넣기
        FirePlay = FireWall.GetComponent<AudioSource>();
        FireEffect.gameObject.SetActive(false);

        StartSound(); 
    }



    void StartSound()
    {
        StartCoroutine(RondomPlaylist()); //랜덤 사운드
        StartCoroutine(DelayTolietSound(7f)); // 화장실 물소리
        StartCoroutine(DelayCellarPlaylist()); // 지하실 소리 
    }

    public float DelayTimeSet(float SetTime, float EndTime)
    {

        Daleytime = Random.Range(SetTime, EndTime); // 딜레이 타임

        return Daleytime;
        
    }

    ///속삭이는 소리 
    IEnumerator RondomPlaylist()
    {
        while (true)
        {
            DelayTimeSet(50f, 70f);
            yield return new WaitForSeconds(Daleytime);
            int i = Random.Range(0, 7);
            SoundManger.instance.PlaySound(RondomSound[i]);
        }

    }

    IEnumerator DelayCellarPlaylist()
    {
        while (true)
        {
            DelayTimeSet(40f, 60f);
            yield return new WaitForSeconds(Daleytime);

            SoundManger.instance.PlaySound(CellarSound);
        }

    }


    IEnumerator DelayTolietSound(float Time) // 욕실 사운드 딜레이
    {
        while (true)
        {
            //DelayTimeSet(5f, 10f);
            //yield return new WaitForSeconds(Daleytime);
            yield return new WaitForSeconds(Time);

            // audio.PlayOnShot();
            WaterAudio.PlayOneShot(ToiletWater);
            //Debug.Log("soundplay");
        }
    }


    public void FireWallStartSound() // 벽난로 사운드 시작 ( 에펙트도 연결해줄 생각)  
    {
        FireEffect.gameObject.SetActive(true);
      //  FireEffect.Play();
        FirePlay.Play();
        
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation.Examples;

public class OntriggerLamp : MonoBehaviour
{
    public GameObject GameMgr;

    public GameObject PathObject;

    public GameObject Pathmodel;

    public GameObject TinkerSound;

    public GameObject PlayerMove; //게임 오브젝트- 플레이어. 여기서 수정 
    public GameObject playerModeling;

    public GameObject Enter_TinkerBell;
    ParticleSystem event_TinkerBellEnter;

    Animator _animator = null;

    private BoxCollider This_colider;

    //알파 값
    Renderer[] renderer;
    Color alphaColor;
    //Renderer rend;

    //스크립트
    ColliderMgr coliderscript;
    Player_HJ playerController;

    public AudioSource TinFlyAudio;


    //한번만 실행될 코루틴... 어.. 걍 끄면 될듯?
    private bool ColliderStay;

    private bool State = true;

    
    public float Set = 6f; // 등불이 켜지는 시간
    public float FadeSet = 4f; //팅커벨이 사라지기 전까지 걸리는 딜레이 시간 
    public float SoundSet = 2f;

    float time = 0f;

    PathFollower tinkerBellPath;

   Collider player_collider;

    void Start()
    {

        // 플레이어 충돌 콜라이더 값
        player_collider = PlayerMove.GetComponent<Collider>();


        //팅커벨 무브-알파값
        tinkerBellPath = PathObject.GetComponent<PathFollower>();
        renderer = Pathmodel.GetComponentsInChildren<Renderer>();


        //renderer = new Renderer[];
        // PointLamp_Renderer = new Renderer[PointLampModl.Length];

        //팅커벨 파티클
        event_TinkerBellEnter = Enter_TinkerBell.GetComponentInChildren<ParticleSystem>();

        //플레이어 move
        playerController = GameObject.FindObjectOfType<Player_HJ>();
        _animator = playerModeling.GetComponent<Animator>();

        //등불 퍼즐 스크립트
        coliderscript =  GameObject.FindObjectOfType<ColliderMgr>();
        Enter_TinkerBell.gameObject.SetActive(false);

        This_colider= this.gameObject.GetComponentInChildren<BoxCollider>();

        // renderer.material.color = new Color(0, 0, 0, 0);
    }


    public void OnTriggerEnter(Collider other)
    {

            if (other.transform.CompareTag("Player"))
            {
                //Debug.Log("충돌! 액자 퍼즐 깻는가 안 깻는가에 대해서!");

                ColliderStay = true;
                tinkerBellPath.enabled = true;

                SartDelay();
                Fadein();
                SoundPlay();
                // 등불 퍼즐 애니메이션 실행. 램프 키고 끄기 -- 추가하기 
                //  Tinkerbell_ani.Play();


        }


        
    }

    void SartDelay()
    {
        StartCoroutine(LampLightDelay(Set));

    }

    IEnumerator LampLightDelay(float Set)
    {
       // 
        _animator.SetBool("IsWalking", false);
        playerController.enabled = false;
        player_collider.enabled = false;

        // StartCoroutine(FadeInTinkerBell());


        yield return new WaitForSeconds(Set);
        //  PathObject.SetActive(false);
        coliderscript.enabled = true;

        yield return new WaitForSeconds(1f);

        // PlayerMove.GetComponent<Player_HJ>().enabled = true;
        playerController.enabled = true;
        player_collider.enabled = true;

        This_colider.enabled = false;
    }

    void SoundPlay()
    {
        StartCoroutine(TinkerBellPlay());

    }

    IEnumerator TinkerBellPlay()
    {

        yield return new WaitForSeconds(SoundSet);

        TinFlyAudio.Play();


    }

    void Fadein()
    {
        StartCoroutine(FadeInTinkerBell(FadeSet));
    }


IEnumerator FadeInTinkerBell(float FadeSet)
    {

        //foreach (Renderer rend in renderer)
        //    alphaColor = rend.material.color ;
        // yield return new WaitForSeconds(Set/2);

        // Color alpha = renderer.material.color;

        time = 0f;


        yield return new WaitForSeconds(FadeSet);


        while (alphaColor.a > 0f)
        {
            time += Time.deltaTime / 1f;
            alphaColor.a = Mathf.Lerp(1, 0, time);
            //Debug.Log("줄어드는중");

            //foreach ( Renderer rend in renderer)
            //   rend.material.color = alphaColor ;

            for (int i = 0; i < renderer.Length; i++)
            {
                renderer[i].material.color = alphaColor;

            }
            yield return new WaitForSeconds(0.01f);
        }
        Pathmodel.gameObject.SetActive(false);




        StartCoroutine(TinkerBellEnter());
      //  Enter_TinkerBell.GetComponent<ParticleSystem>().Play();


      //  Enter_TinkerBell.SetActive(false);
        TinkerSound.SetActive(false);

    }

    IEnumerator TinkerBellEnter()
    {
        yield return new WaitForSeconds(0.5f);
        Enter_TinkerBell.SetActive(true);

        if(!event_TinkerBellEnter.isPlaying)
        {
            Enter_TinkerBell.SetActive(false);
        }
     //   yield return new WaitForSeconds(5f);


    }




}

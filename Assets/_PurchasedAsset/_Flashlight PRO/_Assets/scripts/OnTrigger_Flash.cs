using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 수정 중! 활성화 노노! 
public class OnTrigger_Flash : MonoBehaviour
{
    [SerializeField]
    private string brokenSound = "bombHandLamp";

    // 도달했을 시 손전등이 꺼지는 연출 -- 원래는 불이 켜지면 해야하는데 지금은 트리거로 하기; 
    public GameObject mainCamera;
    public GameObject Target_Player;
    public GameObject playerModeling;
    public GameObject FlashLight;

    public float speedFactor = 0.0f; //보정값 222

    public GameObject Particle_bomb;
    ParticleSystem particleBomb;

    public GameObject FlashLamp_Transform;
    public GameObject FlahLamp_EndTrans;
    public Flashlight_PRO flashstate;

    public GameObject FlashCamera;
    public GameObject FlashPack;

    private bool FlashState = true;
    private bool CoroutineState = false;
    float checkangle;
    public float moveSpeed = 0.7f;
    float step;
    float Setangle = 1f;

    //-플레이어 이동 값
    Animator _animator = null;
    Player_HJ playerController;
    FirstPersonCamera Side_Controller;

    void Start()
    {
        //플레이어 move
        playerController = GameObject.FindObjectOfType<Player_HJ>();
        Side_Controller = GameObject.FindObjectOfType<FirstPersonCamera>();
        _animator = playerModeling.GetComponent<Animator>();


        // ParticleSystem particleBomb = Particle_bomb.GetComponentInChildren<ParticleSystem>();
        flashstate = FindObjectOfType<Flashlight_PRO>();
        particleBomb = Particle_bomb.GetComponentInChildren<ParticleSystem>();
        Particle_bomb.SetActive(false);

        playerController = GameObject.FindObjectOfType<Player_HJ>();
    }

    // Start is called before the first frame update



     public void FlashLightEnd(int i)
    {
        StartCoroutine(MoveFlash());
    }


    IEnumerator MoveFlash()
    {
        FlashState = true;


        yield return new WaitForSeconds(1.5f);

        _animator.SetBool("IsWalking", false);
        playerController.enabled = false;
        Side_Controller.enabled = false;
     

        yield return new WaitForSeconds(1f);


        Vector3 StartPoint = FlashLamp_Transform.transform.position;
        Vector3 SetPoint = FlahLamp_EndTrans.transform.position;

        Quaternion StartRotation = FlashLamp_Transform.transform.rotation;
        Quaternion SetRotation = FlahLamp_EndTrans.transform.rotation;




        //고장 파티클 추가
        Particle_bomb.SetActive(true);

        //등불 깜빡거림 

        yield return new WaitForSeconds(1f);

       FlashLight.SetActive(false);
        //flashstate.BombFlashLight();

        yield return new WaitForSeconds(1f);


        if (!particleBomb.isPlaying)
        {
            Particle_bomb.SetActive(false);
        }
        SoundManger.instance.PlaySound(brokenSound);



        while (true)
        {



            step += Time.deltaTime * moveSpeed;
            //FlashLamp_Transform.transform.rotation = Quaternion.Slerp(targetSet, bRotation, step);



            FlashLamp_Transform.transform.position = Vector3.Lerp(StartPoint, SetPoint, step);

            FlashLamp_Transform.transform.rotation = Quaternion.Lerp(StartRotation,SetRotation, step);

            if (Vector3.Distance(FlashLamp_Transform.transform.position, SetPoint) <= 0.1f)
            {

                break;

            }



            yield return new WaitForSeconds(0.01f);

        }

        yield return new WaitForSeconds(0.05f);



        playerController.enabled = true;
        Side_Controller.enabled = true;
        // this.gameObject.GetComponent<BoxCollider>().enabled = false;
        FlashCamera.SetActive(false);
        FlashPack.SetActive(false);

        FlashState = false;



    }



}

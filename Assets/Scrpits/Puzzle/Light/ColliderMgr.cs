using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ColliderMgr : MonoBehaviour
{
    //  public Animation Tinkerbell_ani;
    // Start is called before the first frame update

    public GameObject[] lamp;

    public GameObject bell_Doll;

    public GameObject MCamera;

    [SerializeField]
    private float range;

    [SerializeField]
    private LayerMask layer;


    public Text actionText;

    [SerializeField]
    private string Lamp_Sound;

    [SerializeField]
    private string ResetLamp_Sound;


    private bool pickupActivated = false;//false;
    private RaycastHit puzzleInfo;


    private int CheckOnL = 0;

    public GameObject ResetLeber;
    LampLight lamplight;
    Animator animator;
    private bool LaberOn = false;

    //public GameObject[] _Pointstate;


    void Start()
    {
        animator = ResetLeber.GetComponent<Animator>();
        bell_Doll.SetActive(false);

        //   Animation Tinkerbell_ani = gameObject.GetComponent<Animation>();
        lamplight = FindObjectOfType<LampLight>();
        lamp[0].SetActive(true);
        lamp[7].SetActive(true);
        lamp[1].SetActive(true);

        for (int i = 0; i < 8; i++)
        {
            lamp[i].SetActive(false);
        }

        lamp[0].SetActive(true);
        lamp[7].SetActive(true);
        lamp[1].SetActive(true);

        CheckOnL = 3;
    }

    // Update is called once per frame
    void Update()
    {
        CheckLamp();
        TryAction();
        End_LampP();

    }
    private void TryAction()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CanLocation();
        }
    }

    private void End_LampP()
    {
        if (CheckOnL == 8)
        {
            bell_Doll.SetActive(true);
            InfoDisappear();
            this.gameObject.GetComponent<ColliderMgr>().enabled = false;

        }
    }



    private void CanLocation()
    {
        if (pickupActivated)
        {
            if (puzzleInfo.transform != null)
            {
                if (puzzleInfo.transform.CompareTag("Puzzle"))
                {

                    int Lampnumber = puzzleInfo.transform.GetComponent<LampLight>().LampNum;



                    if (Lampnumber != 9)
                    {

                        SoundManger.instance.PlaySound(Lamp_Sound);


                        if (Lampnumber - 1 < 0)
                        {
                            if (lamp[7].activeInHierarchy == true)
                            {

                                lamp[7].gameObject.SetActive(false);
                                CheckOnL--;

                            }
                            else
                            {
                                lamp[7].gameObject.SetActive(true);
                                CheckOnL++;
                            }

                        }
                        else
                        {

                            if (lamp[Lampnumber - 1].activeInHierarchy == true)
                            {

                                lamp[Lampnumber - 1].gameObject.SetActive(false);
                                CheckOnL--;

                            }
                            else
                            {
                                lamp[Lampnumber - 1].gameObject.SetActive(true);
                                CheckOnL++;

                            }
                        }



                        if (lamp[Lampnumber].activeInHierarchy == true)
                        {
                            lamp[Lampnumber].gameObject.SetActive(false);
                            CheckOnL--;

                        }
                        else
                        {
                            lamp[Lampnumber].gameObject.SetActive(true);
                            CheckOnL++;

                        }


                        if (Lampnumber + 1 > 7)
                        {
                            if (lamp[0].activeInHierarchy == true)
                            {
                                lamp[0].gameObject.SetActive(false);
                                CheckOnL--;

                            }
                            else
                            {
                                lamp[0].gameObject.SetActive(true);
                                CheckOnL++;

                            }

                        }
                        else
                        {
                            if (lamp[Lampnumber + 1].activeInHierarchy == true)
                            {
                                lamp[Lampnumber + 1].gameObject.SetActive(false);
                                CheckOnL--;

                            }
                            else
                            {
                                lamp[Lampnumber + 1].gameObject.SetActive(true);
                                CheckOnL++;

                            }


                        }
                    }

                    else
                    {
                        StartCoroutine(CheckAnimationState());

                        if (LaberOn == false)
                        {
                            SoundManger.instance.PlaySound(ResetLamp_Sound);
                            animator.SetTrigger("On");
                        }
                        else
                            Debug.Log("현재 실행가능한 상태가 아닙니다.");

                        for(int i = 0; i < 8; i++)
                        {
                            lamp[i].SetActive(false);
                        }


                        

                        lamp[0].SetActive(true);
                        lamp[7].SetActive(true);
                        lamp[1].SetActive(true);
                        CheckOnL = 3;

                    }
                }
            }

        }

    }




    IEnumerator CheckAnimationState()
    {

        while (!animator.GetCurrentAnimatorStateInfo(0)
        .IsName("New State"))
        {
            //전환 중일 때 실행되는 부분
            LaberOn = true;
            yield return null;
        }

        while (animator.GetCurrentAnimatorStateInfo(0)
                .IsName("New State"))
        {
            //전환 중일 때 실행되는 부분
            LaberOn = false;
            yield return null;
        }


        //애니메이션 완료 후 실행되는 부분

    }






    private void CheckLamp()
    {
        if (Physics.Raycast(MCamera.transform.position, MCamera.transform.TransformDirection(Vector3.forward), out puzzleInfo, range, layer))
        {
            if (puzzleInfo.transform.CompareTag("Puzzle")) //compare @
            {
                LampInfoAppear();
            }
        }
        else
        {
            InfoDisappear();
        }
    }


    // Need to modify
    private void LampInfoAppear()
    {
        pickupActivated = true;

        //info
        //actionText.gameObject.SetActive(true);
        //actionText.text = "등불 끄기, 켜기 [Click]";
    }


    public void InfoDisappear()
    {
        pickupActivated = false;

        //info
        //actionText.gameObject.SetActive(false);
    }
}

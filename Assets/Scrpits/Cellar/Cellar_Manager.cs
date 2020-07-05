using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cellar_Manager : MonoBehaviour
{
    [SerializeField]
    private string MoveWallSound = "Cellar_moveWall";

    [SerializeField]
    private string RockDown = "Cellar_rockDown";

    [SerializeField]
    private string BreakonSound = "Cellar_breakon";

    public GameObject Wall_E;
    public GameObject Wall_S;

    public float SetTimeLimet = 1000f;
    float time = 0f;
    float movetime = 0f;

   // public float moveStreet = 1f;
   // public float addStreet = 1f;

    bool Stop = false;

    Coroutine _coroutine;


    // Start is called before the first frame update
    void Start()
    {
        //// 특정 상황 반복 시 코루틴 실행. 현재는 플레이어가 집에 들어오자마자 시작되는 것으로.
        //// Vector3 E_WallStart = Wall_E.transform.position; // E_Wall 의 시작 위치

        //Vector3 S_WallStop = Wall_S.transform.position + new Vector3(0, 0, 2); // E_Wall의 움직이고 난 끝위치

        //StartCoroutine(deley());
    }

    public void MoveStart()
    {
        Vector3 S_WallStop = Wall_S.transform.position + new Vector3(0, 0, 2); // E_Wall의 움직이고 난 끝위치

        StartCoroutine(deley());
    }

    public void MoveStop()
    {
        Stop = true;
    }

    IEnumerator deley()
    {
        yield return new WaitForSeconds(5);

        Vector3 EWallstartPos = Wall_E.transform.localPosition;
        Vector3 SWallstartPos = Wall_S.transform.position;

        SoundManger.instance.PlaySound(RockDown);
        SoundManger.instance.PlaySound(MoveWallSound);
        StartCoroutine(EWall_CountDown(EWallstartPos + new Vector3(10, 0, 0), SetTimeLimet));   // 시작부터 카운트 다운이 진행된다. 
        StartCoroutine(SWall_CountDown(SWallstartPos + new Vector3(0, 0, 10), SetTimeLimet));   // 시작부터 카운트 다운이 진행된다. 
    }

    IEnumerator EWall_CountDown(Vector3 endPos, float duration)
    {
        time = 0f;

        WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
        // Vector2 EWallEndPos = Wall_E.transform.localPosition + new Vector3(2, 0, 0);
        // 위치를 움직일 위치를 다시 잡습니다! 시작위치랑, 끝위치를 다시 잡습니다!!!! 후유! 

        Vector3 EWallstartPos = Wall_E.transform.localPosition;
        movetime = duration;

        while (duration > 0.0f) // 선형보간이 진행됩니다. 선형보간의 이동이 끝날때까지! 
        {
            duration -= Time.deltaTime; // 벽 2개가 움직입니다! 천천히 움직입니다!!  현재 5초로 입력했을시 5초동안 움직이는 것을 확인완료했습니다!
            time += Time.deltaTime;
            Wall_E.transform.localPosition = Vector3.Lerp(EWallstartPos, endPos,  time / movetime);

            if (Stop)
                break;

            yield return waitForEndOfFrame;
        }

        yield return new WaitForSeconds(2f);
    }

    IEnumerator SWall_CountDown(Vector3 endPos, float duration)
    {
        //time = 0f;

        WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
        // Vector2 EWallEndPos = Wall_E.transform.localPosition + new Vector3(2, 0, 0);
        // 위치를 움직일 위치를 다시 잡습니다! 시작위치랑, 끝위치를 다시 잡습니다!!!! 후유! 

        Vector3 SWallstartPos = Wall_S.transform.localPosition;
        movetime = duration;

        while (duration > 0.0f) // 선형보간이 진행됩니다. 선형보간의 이동이 끝날때까지! 
        {
            duration -= Time.deltaTime; // 벽 2개가 움직입니다! 천천히 움직입니다!!  현재 5초로 입력했을시 5초동안 움직이는 것을 확인완료했습니다!
            time += Time.deltaTime;
            Wall_S.transform.localPosition = Vector3.Lerp(SWallstartPos, endPos, time / movetime);
            //   Wall_E.transform.position = Vector3.Lerp(Wall_E.transform.position, E_WallStop, t);
            
            if (Stop)
                break;

            yield return waitForEndOfFrame;
        }

        yield return new WaitForSeconds(2f);

        Vector3 E_WallStop = Wall_E.transform.position + new Vector3(2, 0, 0); // E_Wall의 움직이고 난 끝위치
    }


}

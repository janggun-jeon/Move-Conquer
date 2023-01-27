using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{


    void Start()
    {
        
    }



    void Update()
    {
        
    }

    public void Cancel() // 취소버튼 누르면
    {
        GameObject player = GameManager.cntPlayer;
        player.transform.position = GameManager.routine[0]; // 플레이어가 경로상 최초위치로 돌아가고
        GameManager.routine = new List<Vector3>();
        GameManager.Routine(player); // 경로리스트가 초기화되서 반환(플레이어 객체와 게임매니저의 경로리스트 둘다 초기화)
    }

    public void Decision() // 결정버튼 누르면
    {
        GameObject player = GameManager.cntPlayer;
        player.transform.position = GameManager.routine[0]; // 플레이어가 경로상 최초위치로 돌아가고
        GameManager.routine = new List<Vector3>(); // 경로리스트를 저장한 상태에서 다른 플레이어의 결정을 기다림(게임매니저의 경로리스트는 초기화)
    }
}

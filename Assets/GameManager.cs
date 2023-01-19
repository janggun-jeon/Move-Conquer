using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    Camera cam; // 레이저를 쏠 카메라 컴포넌트
    public GameObject cntPlayer; // 현재 플레이어

    public static float time; // 턴 시간

    void Awake()
    {
        cam = gameObject.GetComponent<Camera>();
        time = 30f;
    }

    void Update()
    {
        time -= Time.deltaTime; // 턴 시간 감소
        ArrowClick(); // 항상 클릭 가능
    }

    void ArrowClick() // 이동할 타일 선택 함수
    {
        if (Input.GetMouseButtonDown(0)) // 클릭이 있을 때
        {
            // 클릭 위치 정보 받아오기
            Vector3 clickPos = cam.ScreenToWorldPoint(Input.mousePosition);

            // 클릭 위치의 오브젝트(타일) 탐지
            RaycastHit hit;
            Physics.Raycast(clickPos, transform.forward, out hit, 60f);
            if (hit.collider.tag == "Arrow")
            {
                // 플레이어 이동
                cntPlayer.transform.position = hit.transform.position; // 이동
            }
        }
    }
}

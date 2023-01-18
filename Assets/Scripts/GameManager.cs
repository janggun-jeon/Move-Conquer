using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // 싱글턴

    Camera cam;       // 카메라 컴포넌트
    Vector3 clickPos; // 클릭 위치 정보 
    RaycastHit2D hit; // 탐지할 오브젝트의 콜리젼

    public TileList table; // 타일들의 리스트

    public GameObject redTeam;  // 레드팀 플레이어
    public GameObject blueTeam; // 블루팀 플레이어
    GameObject Player;          // 현재의 플레이어

    int[,] redPos;  // 레드팀 경로
    int[,] bluePos; // 블루팀 경로

    public static int turn;   // 레드팀 = 1, 블루팀 = 2;
    public static float time; // 시간

    int dice;  int dice1; int dice2; // 행동력

    void Awake()
    {
        cam = GetComponent<Camera>();

        Player = redTeam;
        turn = 1;
        time = 30f;

        // 행동경로를 저장하는 배열 초기화1
        redPos = new int[7, 2] { { -1, -1 }, { -1, -1 }, { -1, -1 }, { -1, -1 }, { -1, -1 }, { -1, -1 }, { -1, -1 } };
        bluePos = new int[7, 2] { { -1, -1 }, { -1, -1 }, { -1, -1 }, { -1, -1 }, { -1, -1 }, { -1, -1 }, { -1, -1 } };

        // 행동경로를 저장하는 배열 초기화2
        redPos[0,0] = (int)(-0.5f * (redTeam.transform.position.y - 5f));
        redPos[0,1] = (int)((redTeam.transform.position.x + 2f) / 2f);
        bluePos[0,0] = (int)(-0.5f * (blueTeam.transform.position.y - 5f));
        bluePos[0,1] = (int)((redTeam.transform.position.x + 2f) / 2f);

        // 행동횟수 결정
        dice = Random.Range(1, 7);
        dice1 = dice2 = 0;
    }

    void Update()
    {
        time -= Time.deltaTime;
        if (time < 0f || dice1 >= dice || dice2 >= dice) { // 시간 초과나 행동력을 모두 사용했을 때 플레이어 변경
            if (turn == 1) {
                Player = blueTeam;
                turn = 2;
                dice1 = 0;
            }
            else if (turn == 2) {
                Player = redTeam;
                turn = 3;
                dice2 = 0;
            }
            time = 30f;
        }
        if (turn < 3) // 턴이 끝나지 않은 경우 다음 행동 클릭
        {
            TileClick(); // 클릭한 위치 정보를 턴이 끝날때까지 저장
        }
        else
        {
            Conquer(); // 턴이 끝나고, 그 턴에서 각각의 행동에 대한 영토 계산
        }
    }

    void TileClick() // 이동할 타일 선택 함수
    {
        if (Input.GetMouseButtonDown(0)) // 클릭이 있을 때
        {
            // 클릭 위치 정보 받아오기
            clickPos = cam.ScreenToWorldPoint(Input.mousePosition);

            // 클릭 위치의 오브젝트(타일) 탐지
            hit = Physics2D.Raycast(clickPos, transform.forward, 20f);
            Debug.DrawRay(clickPos, transform.forward * 10f, Color.green, 0.3f);
            Move();
        }
    }

    void Move() // 플레이어 이동 함수
    {
        if (hit.collider.tag == "Field")
        {
            //
            float x = hit.transform.position.x;
            float y = hit.transform.position.y;
            
            // 위치 -> 배열 인덱스 변환
            int row = (int)(-0.5f * (y - 5f));
            int col = (int)((x + 2f) / 2f);

            Tile tile = table.tileList[3 * row + col].GetComponent<Tile>();
            Player player = Player.GetComponent<Player>();
            if (tile.isMovable(player.row, player.col) ) // 대각선 이동 제한 조건
            {
                // 플레이어 이동
                Player.transform.position = new Vector2(x, y);
                player.Next();

                // 행동력을 소모시키고, 행동했던 위치들의 인덱스를 턴이 끝날때 까지 저장
                if (turn == 1)
                {
                    dice1++;
                    redPos[dice1, 0] = row; 
                    redPos[dice1,1] = col;
                }
                else if (turn == 2)
                {
                    dice2++;
                    bluePos[dice2, 0] = row;
                    bluePos[dice2, 1] = col;
                }
            }
        }
    }

    void Conquer() // 턴이 끝날때, 각각의 행동에 대한 영토 계산
    {
        for (int itr = 1; itr <= dice; itr++) // 행동별로 영토 반복 계산
        {
            int rowR = redPos[itr, 0];
            int colR = redPos[itr, 1];
            int rowB = bluePos[itr, 0];
            int colB = bluePos[itr, 1];

            // 레드팀 영토 체크
            table.counter[(int)(3f * rowR + colR)] += 1;
            if (rowR - 1 >= 0) { table.counter[(int)(3f * (rowR - 1) + colR)] += 1; }
            if (rowR + 1 <= 5) { table.counter[(int)(3f * (rowR + 1) + colR)] += 1; }
            if (colR - 1 >= 0) { table.counter[(int)(3f * rowR + colR - 1)] += 1; }
            if (colR + 1 <= 2) { table.counter[(int)(3f * rowR + colR + 1)] += 1; }

            // 블루팀 영토 체크
            table.counter[(int)(3f * rowB + colB)] += 2;
            if (rowB - 1 >= 0) { table.counter[(int)(3f * (rowB - 1) + colB)] += 2; }
            if (rowB + 1 <= 5) { table.counter[(int)(3f * (rowB + 1) + colB)] += 2; }
            if (colB - 1 >= 0) { table.counter[(int)(3f * rowB + colB - 1)] += 2; }
            if (colB + 1 <= 2) { table.counter[(int)(3f * rowB + colB + 1)] += 2; }

            table.Change(); // 체크된 영토 색 변경
        }

        // 다음 턴 파라미터들 초기화
        turn = 1;
        time = 30f;

        redPos = new int[7, 2] { { -1, -1 }, { -1, -1 }, { -1, -1 }, { -1, -1 }, { -1, -1 }, { -1, -1 }, { -1, -1 } };
        bluePos = new int[7, 2] { { -1, -1 }, { -1, -1 }, { -1, -1 }, { -1, -1 }, { -1, -1 }, { -1, -1 }, { -1, -1 } };

        redPos[0, 0] = (int)(-0.5f * (redTeam.transform.position.y - 5f));
        redPos[0, 1] = (int)((redTeam.transform.position.x + 2f) / 2f);
        bluePos[0, 0] = (int)(-0.5f * (blueTeam.transform.position.y - 5f));
        bluePos[0, 1] = (int)((redTeam.transform.position.x + 2f) / 2f);

        dice = Random.Range(1, 7);
        dice1 = dice2 = 0;
    }
}
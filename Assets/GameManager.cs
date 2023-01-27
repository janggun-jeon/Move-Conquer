using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    Camera cam; // �������� �� ī�޶� ������Ʈ
    public static GameObject cntPlayer; // ���� �÷��̾�
    public static List<Vector3> routine; // �÷��̾� ���

    public static float time; // �� �ð�

    public static GameObject board; // ����
    public static int redScore; // ������ ����
    public static int blueScore; // ����� ���� 

    void Awake()
    {
        cam = gameObject.GetComponent<Camera>();
        cntPlayer = GameObject.FindWithTag("Player1");

        routine = new List<Vector3>();

        time = 30f;

        board = GameObject.FindWithTag("Board");
        redScore = 0;
        blueScore = 0;
    }

    void Update()
    {
        time -= Time.deltaTime; // �� �ð� ����
        ArrowClick(); // �׻� Ŭ�� ����
        /*if ((int)time % 2 == 1)
        {
            Score();
        }*/
    }

    public  void ArrowClick() // �̵��� Ÿ�� Ŭ���ϸ� �̵�
    {
        if (Input.GetMouseButtonDown(0)) // Ŭ���� ���� ��
        {
            // Ŭ�� ��ġ ���� �޾ƿ���
            Vector3 clickPos = cam.ScreenToWorldPoint(Input.mousePosition);

            // Ŭ�� ��ġ�� ������Ʈ(Ÿ��) Ž��
            RaycastHit hit;
            Physics.Raycast(clickPos, transform.forward, out hit, 60f);
            if (hit.collider.tag == "Arrow")
            {
                // �÷��̾� �̵�
                cntPlayer.transform.position = hit.transform.position; // �̵�
                Routine(cntPlayer);
            }
        }
    }

    public static void Routine(GameObject player) // �÷��̾� ��ü�� ��ġ�� ����Ʈ�� �ְ� ��ȯ
    {
        routine.Add(player.transform.position);
        player.GetComponent<Player>().routine = routine;
    }

    public static void Score()
    {
        GameObject[] tiles = board.GetComponent<Board>().tiles;
        int r = 0; int b = 0; 
        for (int itr = 0; itr < tiles.Length; itr++)
        {
            if (tiles[itr].GetComponent<Tile>().colorNumber == 1)
            {
                r++; Debug.Log("Score!");
            }
            else if (tiles[itr].GetComponent<Tile>().colorNumber == 2)
            {
                b++;
            }
        }
        redScore = r;
        blueScore = b;
    }
}

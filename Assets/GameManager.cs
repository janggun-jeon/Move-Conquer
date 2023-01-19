using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    Camera cam; // �������� �� ī�޶� ������Ʈ
    public GameObject cntPlayer; // ���� �÷��̾�

    public static float time; // �� �ð�

    void Awake()
    {
        cam = gameObject.GetComponent<Camera>();
        time = 30f;
    }

    void Update()
    {
        time -= Time.deltaTime; // �� �ð� ����
        ArrowClick(); // �׻� Ŭ�� ����
    }

    void ArrowClick() // �̵��� Ÿ�� ���� �Լ�
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
            }
        }
    }
}

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

    public void Cancel() // ��ҹ�ư ������
    {
        GameObject player = GameManager.cntPlayer;
        player.transform.position = GameManager.routine[0]; // �÷��̾ ��λ� ������ġ�� ���ư���
        GameManager.routine = new List<Vector3>();
        GameManager.Routine(player); // ��θ���Ʈ�� �ʱ�ȭ�Ǽ� ��ȯ(�÷��̾� ��ü�� ���ӸŴ����� ��θ���Ʈ �Ѵ� �ʱ�ȭ)
    }

    public void Decision() // ������ư ������
    {
        GameObject player = GameManager.cntPlayer;
        player.transform.position = GameManager.routine[0]; // �÷��̾ ��λ� ������ġ�� ���ư���
        GameManager.routine = new List<Vector3>(); // ��θ���Ʈ�� ������ ���¿��� �ٸ� �÷��̾��� ������ ��ٸ�(���ӸŴ����� ��θ���Ʈ�� �ʱ�ȭ)
    }
}

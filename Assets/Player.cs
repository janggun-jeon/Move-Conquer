using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // �÷��̾� ��ġ�� ���� �ε��� ����
    public int row;
    public int col;

    void Start()
    {
        Next();
    }

    public void Next() // �ε��� ���� ����
    {
        row = (int)(-0.5f * (transform.position.y - 5f));
        col = (int)((transform.position.x + 2f) / 2f);
    }
}

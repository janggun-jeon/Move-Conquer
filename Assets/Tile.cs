using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    // Ÿ�� ��ġ�� ���� �ε��� ����
    int row;
    int col;

    // ������ ���׸��� ������ : ���(�⺻), ����, ���
    public Material[] mat = new Material[3];

    void Start()
    {
        // �ʱ�ȭ�� Ÿ���� �ε��� ������ ������� ����
        row = (int)(-0.5f * (transform.position.y - 5f));
        col = (int)((transform.position.x + 2f) / 2f);
    }

    public bool isMovable(int r, int c) { // Ŭ���� Ÿ���� �̵��������� �������ִ� �Լ�
        int threshold = (row - r >= 0 ? row - r : r - row) + (col - c >= 0 ? col - c : c - col);

        // �밢���̳� ���ڸ��� �̵��� ������
        if ( threshold < 2 && threshold > 0 ) { 
            return true; 
        }
        else { return false; }
    }
}

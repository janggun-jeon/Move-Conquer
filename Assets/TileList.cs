using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileList : MonoBehaviour 
{
    public List<GameObject> tileList; // Ÿ�ϵ��� ����Ʈ
    public int[] counter;             // Ÿ�Ϻ� üũ Ƚ���� ���� �迭

    void Start() 
    { 
        counter = new int[tileList.Count];
    }

    public void Change() 
    { 
        for (int itr = 0; itr < counter.Length; itr++) 
        {
            int color = counter[itr];
            if (color == 0) // üũ�� ���ų� �ߺ��Ǽ� ��ȿȭ�� Ÿ��
            { 
                continue;
            }
            else if (color == 1 || color == 2) // �� �÷��̾�鿡�� üũ�� Ÿ��
            { 
                tileList[itr].GetComponent<Renderer>().material.color = tileList[itr].GetComponent<Tile>().mat[color].color;
            }
        }
        counter = new int[tileList.Count];
    }
}

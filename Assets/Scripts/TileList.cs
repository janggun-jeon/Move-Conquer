using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileList : MonoBehaviour 
{
    public List<GameObject> tileList; // 타일들의 리스트
    public int[] counter;             // 타일별 체크 횟수에 대한 배열

    void Start() 
    { 
        counter = new int[tileList.Count];
    }

    public void Change() 
    { 
        for (int itr = 0; itr < counter.Length; itr++) 
        {
            int color = counter[itr];
            if (color == 0) // 체크가 없거나 중복되서 무효화된 타일
            { 
                continue;
            }
            else if (color == 1 || color == 2) // 두 플레이어들에게 체크된 타일
            { 
                tileList[itr].GetComponent<Renderer>().material.color = tileList[itr].GetComponent<Tile>().mat[color].color;
            }
        }
        counter = new int[tileList.Count];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 플레이어 위치에 대한 인덱스 정보
    public int row;
    public int col;

    void Start()
    {
        Next();
    }

    public void Next() // 인덱스 정보 갱신
    {
        row = (int)(-0.5f * (transform.position.y - 5f));
        col = (int)((transform.position.x + 2f) / 2f);
    }
}

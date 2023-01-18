using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    // 타일 위치에 대한 인덱스 정보
    int row;
    int col;

    // 세가지 머테리얼 데이터 : 흰색(기본), 레드, 블루
    public Material[] mat = new Material[3];

    void Start()
    {
        // 초기화된 타일의 인덱스 정보는 변경되지 않음
        row = (int)(-0.5f * (transform.position.y - 5f));
        col = (int)((transform.position.x + 2f) / 2f);
    }

    public bool isMovable(int r, int c) { // 클릭된 타일이 이동가능한지 응답해주는 함수
        int threshold = (row - r >= 0 ? row - r : r - row) + (col - c >= 0 ? col - c : c - col);

        // 대각선이나 제자리로 이동을 금지됨
        if ( threshold < 2 && threshold > 0 ) { 
            return true; 
        }
        else { return false; }
    }
}

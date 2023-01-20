using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Material[] tileColor;
    public int colorNumber; // 점수 비교를 위한 색깔 번호

    // Start is called before the first frame update
    void Start()
    {
        colorNumber = 0;
        /* if (num == 1)
         {
             GetComponent<MeshRenderer>().material = tileColor[num];
         }*/
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MakeRed()
    {
        GetComponent<MeshRenderer>().material = tileColor[1];
        colorNumber = 1;
    }
    public void MakeBlue()
    {
        GetComponent<MeshRenderer>().material = tileColor[2];
        colorNumber = 2;
    }


}

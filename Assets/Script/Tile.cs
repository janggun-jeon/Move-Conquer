using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Material[] tileColor;
    public int currentColorNumber = 0; // Ÿ���� ��ȭ�� ���� ���� ����
    public int colorNumber; // Ÿ���� ���� ���� 
    // Start is called before the first frame update
    void Start()
    {
        /* if (num == 1)
         {
             GetComponent<MeshRenderer>().material = tileColor[num];
         }*/
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void MakeColor(int id)
    {
        GetComponent<MeshRenderer>().material = tileColor[id];
        colorNumber = id;
    }

}

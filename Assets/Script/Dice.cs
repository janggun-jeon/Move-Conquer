using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public int diceNumber;

    // Start is called before the first frame update
    void Start()
    {
        diceNumber = Random.Range(1, 7); // �ֻ��� ���� ���� 1~6
    }

    // Update is called once per frame
    void Update()
    {




    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Text timer; // Ÿ�̸�

    void Start()
    {
        // ���ӸŴ��� �ý��� �ð��� ����
        timer = gameObject.GetComponent<Text>();
        timer.text = "Time : 30 sec";
    }

    void Update()
    {
        timer.text = "Time : " + ((int)GameManager.time).ToString() + " sec";
    }
}

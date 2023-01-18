using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Text timer; // 타이머

    void Start()
    {
        // 게임매니저 시스템 시간과 연동
        timer = gameObject.GetComponent<Text>();
        timer.text = "Time : 30 sec";
    }

    void Update()
    {
        timer.text = "Time : " + ((int)GameManager.time).ToString() + " sec";
    }
}

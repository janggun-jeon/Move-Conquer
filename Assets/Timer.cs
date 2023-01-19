using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Text timer;

    void Start()
    {
        timer = gameObject.GetComponent<Text>();
    }

    void Update()
    {
        timer.text = "Time : " + GameManager.time.ToString() + " sec";
    }
}

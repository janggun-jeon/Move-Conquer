using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static float time;
    void Awake()
    {
        time = 30f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Material[] tileColor;
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

    public void MakeRed()
    {
        GetComponent<MeshRenderer>().material = tileColor[1];
    }
    public void MakeBlue()
    {
        GetComponent<MeshRenderer>().material = tileColor[2];
    }


}

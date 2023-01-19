using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject[] tiles;
    public int id;
    public int[] input;
    public GameObject player;
    public int index1;
    public int index2;
    public int checknum = -1;
    public int[] checkPos;
    


    
    // Start is called before the first frame update
    void Start()
    {
        if (player.tag == "Player1")
        {
            index1 = 4; // ���߾ӿ� ���� �Ϲ�ȭ �� �� ���߿� �־��
            player.transform.position = tiles[4].transform.position;
            Debug.Log(player.transform.position);
        }
        if (player.tag == "Player2")
        {
            index2 = 13; // ���߾ӿ� ���� �Ϲ�ȭ �� �� ���߿� �־��
            player.transform.position = tiles[13].transform.position;
        }
        
        //tiles[0].GetComponent<Tile>().MakeBlue();

    }

    // Update is called once per frame
    void Update()
    {    // Player1 ���ؿ��� �ε����� 0�� ����� ��ġ�� õ��(����)
        if (player.tag == "Player1")
        {

            if (Input.GetKeyDown(KeyCode.W))
            {
                
                if (index1 - 3 >= 0) // Player1 ���� �ö�
                {
                    index1 -= 3;
                    CrossPaint();

                }
                else
                {
                    Debug.Log("���� ���� ����");
                }
                


            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (index1 % 3 == 2) // Player1 ���� �ǿ���
                {
                    Debug.Log("�������� �� �� ����");                  
                }
                else
                {
                    index1 += 1;
                    CrossPaint();
                }

            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (index1 + 3 <= 17) // Player1 ���� �� �Ʒ�
                {
                    index1 += 3;
                    CrossPaint();
                }
                else
                {
                    Debug.Log("�Ʒ��� �� �� ����");
                }

            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (index1 % 3 == 0) // Player1 ���� �� ������
                {
                    Debug.Log("���������� �� �� ����");
                }
                else
                {
                    index1 -= 1;
                    CrossPaint();
                }

            }

        }
        if (player.tag == "Player2")
        {

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {

                if (index2 - 3 >= 0) // Player2 ���� �ö�
                {
                    index2 -= 3;
                    CrossPaint();

                }
                else
                {
                    Debug.Log("���� ���� ����");
                }


            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (index2 % 3 == 0) // Player1 ���� �ǿ���
                {
                    Debug.Log("�������� �� �� ����");
                }
                else
                {
                    index2 -= 1;
                    CrossPaint();
                }

            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (index2 + 3 <= 17) // Player2 ���� �� �Ʒ�
                {
                    index2 += 3;
                    CrossPaint();
                }
                else
                {
                    Debug.Log("�Ʒ��� �� �� ����");
                }

            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {

                if (index2 % 3 == 2) // Player2 ���� �� ������
                {
                    Debug.Log("���������� �� �� ����");
                }
                else
                {
                    index2 += 1;
                    CrossPaint();
                }


            }

        }


    }
    

   
    void CrossPaint()
    {
       
            if (player.tag == "Player1")
            {

                if (index1 % 3 == 0) // ������ �� �ε��� �ް� Player1 ���� ���� ������
                {
                    Debug.Log("������ ĥ������ ����");
                }
                else
                {
                    tiles[index1 - 1].GetComponent<Tile>().MakeRed();
                }

                if (index1 % 3 == 2) // ������ �� �ε��� �ް� Player1 ���� ���� ����
                {
                    Debug.Log("������ ĥ������ ����");
                }
                else
                {
                    tiles[index1 + 1].GetComponent<Tile>().MakeRed();
                }

                if (index1 - 3 >= 0) // ������ �� �ε��� �ް� Player1 ���� ����
                {
                    tiles[index1 - 3].GetComponent<Tile>().MakeRed();
                }
                else
                {
                    Debug.Log("������ ĥ������ ����");
                }

                if (index1 + 3 <= 17) // ������ �� �ε��� �ް� Player1 �Ʒ��� ����
                {
                    tiles[index1 + 3].GetComponent<Tile>().MakeRed();
                }
                else
                {
                    Debug.Log("�Ʒ����� ĥ������ ����");
                }


               
                player.transform.position = tiles[index1].transform.position;
            

            }

            if (player.tag == "Player2")
            {

                if (index2 % 3 == 0) // ������ �� �ε��� �ް� Player2 ���� ���� ����
                {
                    Debug.Log("������ ĥ������ ����");
                }
                else
                {
                    tiles[index2 - 1].GetComponent<Tile>().MakeBlue();
                }

                if (index2 % 3 == 2) // ������ �� �ε��� �ް� Player2 ���� ���� ������
                {
                    Debug.Log("������ ĥ������ ����");
                }
                else
                {
                    tiles[index2 + 1].GetComponent<Tile>().MakeBlue();
                }

                if (index2 - 3 >= 0) // ������ �� �ε��� �ް� Player2 ���� ����
                {
                    tiles[index2 - 3].GetComponent<Tile>().MakeBlue();
                }
                else
                {
                    Debug.Log("������ ĥ������ ����");
                }

                if (index2 + 3 <= 17) // ������ �� �ε��� �ް� Player2 �Ʒ��� ����
                {
                    tiles[index2 + 3].GetComponent<Tile>().MakeBlue();
                }
                else
                {
                    Debug.Log("�Ʒ����� ĥ������ ����");
                }



                player.transform.position = tiles[index2].transform.position;
            }


        }
        /*
        if (player.tag == "Player2")
        {
            if (index2 % 3 == 0) // ������ �� �ε��� �ް� Player2 ���� ���� ����
            {
                Debug.Log("������ ĥ������ ����");
            }
            else
            {
                tiles[index2 - 1].GetComponent<Tile>().MakeBlue();
            }


            tiles[index2 - 1].GetComponent<Tile>().MakeBlue();
            tiles[index2 + 1].GetComponent<Tile>().MakeBlue();
            tiles[index2 - 3].GetComponent<Tile>().MakeBlue();
            tiles[index2 + 3].GetComponent<Tile>().MakeBlue();

            player.transform.position = tiles[index2].transform.position;


        }
        */

 

    
    /*
    void PlayerMove()
    {
        switch (checknum)
        {
            case 1:
                Debug.Log("S,D ������ ����")
                if (Input.GetKeyDown(KeyCode.S))
                {
                    index1 += 3;
                    Debug.Log("S ����");
                    break;

                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    index1 -= 1;
                    Debug.Log("D ����");
                    break;
                }

            case 2:

                Debug.Log("S,D ������ ����")
                if (Input.GetKeyDown(KeyCode.S))
                {
                    index1 += 3;
                    Debug.Log("S ����");
                    break;

                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    index1 -= 1;
                    Debug.Log("D ����");
                    break;
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    index1 += 1;
                    Debug.Log("A ����");
                    CrossPaint();

                }
            case 3:

                Debug.Log("S,D ������ ����")
                if (Input.GetKeyDown(KeyCode.D))
                {
                    index1 -= 1;
                    Debug.Log("D ����");
                    break;
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    index1 += 1;
                    Debug.Log("A ����");
                    CrossPaint();

                }
            case 4:

                Debug.Log("S,D ������ ����")
                if (Input.GetKeyDown(KeyCode.S))
                {
                    index1 += 3;
                    Debug.Log("S ����");
                    break;

                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    index1 -= 1;
                    Debug.Log("D ����");
                    break;
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    index1 += 1;
                    Debug.Log("A ����");
                    break

                }
                if (Input.GetKeyDown(KeyCode.W))
                {
                    index1 -= 3;
                    Debug.Log("W ����");
                    break


                }


        }
    }
    */
    void CheckPos(int idx)
    {
    
        
        if (idx % 3 == 0)
        {

            if (idx - 3 <= 0 )
            {
                checkPos = new int[] { idx + 1, idx + 3 };
                checknum = 1;
            }

            else if (idx + 3 >= 17)
            {
                checkPos = new int[] { idx + 1, idx - 3 };
                checknum = 7;
            }
            else
            {
                checkPos = new int[] { idx + 1, idx - 3, idx + 3 };
                checknum = 4;
            }


        }

        else if (idx % 3 == 2)
        {

            if (idx - 3 <= 0)
            {
                checkPos = new int[] { idx - 1, idx + 3 };
                checknum = 3;
            }
            else if (idx + 3 >= 17)
            {
                checkPos = new int[] { idx - 1, idx - 3 };
                checknum = 9;
            }
            else
            {
                checkPos = new int[] { idx - 1, idx - 3, idx + 3 };
                checknum = 6;
            }


        }

    
        else
        {
            if (idx - 3 <= 0)
            {
                checkPos = new int[] { idx - 1, idx + 1, idx + 3 };
                checknum = 2;
            }
            else if (idx + 3 >= 17)
            {
                checkPos = new int[] { idx - 1, idx + 1, idx - 3 };
                checknum = 8;
            }
            else
            {
                checkPos = new int[] { idx - 1, idx + 1, idx - 3, idx + 3 } ;
                checknum = 5;
            }
        }


    }
    
    
}

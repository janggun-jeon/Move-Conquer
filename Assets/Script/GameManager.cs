using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject Dice; // �ֻ��� ��ü
    public GameObject restartButton; // ����� ��ư
    public GameObject gameOverText;

    public GameObject[] tiles; // Ÿ�� list �ޱ�
    public bool isGameOver; // ���� ���� ����
    // public int diceNumber;
    int diceNumber; // ���� �ֻ��� ����
    int maxTurn; // �ִ� �ϼ� ����


    public GameObject playerPrefab;
    GameObject player1;
    GameObject player2;










    //Player p1 = player1.GetComponent<Player>(); 
    //Player p2 = player2.GetComponent<Player>(); 




    bool flag; // ���� ���ϱ� ���� �Ⱦ�
    bool turnEnd; // �� �� ����



    //�Ʒ��� ���ǵ� ������ �ؽ�Ʈ�� ǥ���� ����
    public static float time;// �ð�

    public static int turn; // ���� ����

    public static int redScore; // player1 ����
    public static int blueScore; // player2 ����

    public static string winner; // ����



  





    //public static enum playerColor = { RED =1, BLUE }  
    // Start is called before the first frame update
    void Start()
    {
        
        player1 = Instantiate(playerPrefab);
        player2 = Instantiate(playerPrefab);
        player1.GetComponent<Player>().PlayerRestart(4, 1, tiles);
        player2.GetComponent<Player>().PlayerRestart(13, 2, tiles);
        


        //player1.id = 1;
        //player2.id = 2;

        time = 30.0f;
        restartButton.SetActive(false);
        gameOverText.SetActive(false);
        turn = 1;
        turnEnd = false;
        
        maxTurn = 6;
        diceNumber = Dice.GetComponent<Dice>().diceNumber;
        Debug.Log("�ֻ��� ���ڴ�" + diceNumber);
        isGameOver = false;

        redScore = 0;
        blueScore = 0;


    }

    // Update is called once per frame
    void Update()
    {

           
        TurnChange();
        TileCounter();
        TurnTime();
        Win();
        //Reset();
        PlayerMove();
        if (isGameOver)
        {
            Debug.Log("���������: " + isGameOver);
            gameOverText.GetComponent<Text>().text = "<Winner>: " + winner;
            restartButton.SetActive(true);
            gameOverText.SetActive(true);
        }


    }

    

    void TurnTime()
    {
        time -= Time.deltaTime;
        if (turnEnd == true)
        {
            time = 30.0f;
            turnEnd = false;
        }

        if (time < 0)
        {
            //player1.SetActive(false);
            //player2.SetActive(false);
            time = 0;
        }


    }

    void TileCounter() // Ÿ�� ���� ���� �Լ�
    {
        if (turnEnd == true)
        {
            for (int i = 0; i < tiles.Length; i++)
            {
                if (tiles[i].GetComponent<Tile>().colorNumber == 1) // player1 ���� ���� �ݺ���
                {
                    redScore++;

                }
                else if (tiles[i].GetComponent<Tile>().colorNumber == 2) // player2 ���� ���� �ݺ���
                {
                    blueScore++;
                }

            }
        }

    } // argument�� ��� �õ�

    public void OnClickRestart()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }



    void TurnChange() // �� ��ȭ ��Ģ
    {
        if (turn <= maxTurn )
        {
            if (diceNumber == player1.GetComponent<Player>().moveCount)
            {
                player1.SetActive(false);
               /* player1.GetComponent<Player>().unPaint = false;
                player2.GetComponent<Player>().unPaint = true;*/
            }
            if (diceNumber == player2.GetComponent<Player>().moveCount)
            {
                player2.SetActive(false);
                /* player1.GetComponent<Player>().unPaint = true;
                 player2.GetComponent<Player>().unPaint = false;*/
            }



        }
        // turn 7�϶� ���� ����
        if (player1.activeSelf == false && player2.activeSelf == false) // if ���ǹ��� �����̽��ٸ� ������ �Ѿ�� Ű�� �߰�����
        {

            if (turn <= maxTurn)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    player1.SetActive(true);
                    player2.SetActive(true);
                    //int routineCount = player1.GetComponent<Player>().routine.Count;
                    //Debug.Log("��� �� Ƚ��:" + routineCount);



                    Debug.Log("�� " + turn + " ����");
                    int index1 = player1.GetComponent<Player>().routine[diceNumber]; // Routine�� �� ������ ù ��ġ ���� ������ ����
                    int index2 = player2.GetComponent<Player>().routine[diceNumber]; // Routine�� �� ������ ù ��ġ ���� ������ ����

                    Dice.GetComponent<Dice>().diceNumber = Random.Range(1, 7); // ex [0,0,0,0,0,0], dicenubmer = 5


                    diceNumber = Dice.GetComponent<Dice>().diceNumber; // 1~6���� ������              
                    Debug.Log("�ֻ��� ���ڴ� " + diceNumber);


                    // diceNumber + 1 �̹Ƿ� index�� diceNubmer�� ������
                    player1.GetComponent<Player>().routine = new List<int>();
                    player1.GetComponent<Player>().routine.Add(index1);
                    player2.GetComponent<Player>().routine = new List<int>();
                    player2.GetComponent<Player>().routine.Add(index2);
                    player1.GetComponent<Player>().moveCount = 0;
                    player2.GetComponent<Player>().moveCount = 0;
                    redScore = 0;
                    blueScore = 0;
                    // ���� ��ȭ�ϸ鼭 ��������� moveCount �ʱ�ȭ

                    for (int i = 0; i < tiles.Length; i++) // ���� �ٲ�鼭 Ÿ�� ���� ���� ����
                    {
                        tiles[i].GetComponent<Tile>().currentColorNumber
                        = tiles[i].GetComponent<Tile>().colorNumber;
                    }


                    turn++;
                    turnEnd = true;
                }
            }


        }
    }
    /*
    void TurnEnd()
    {
        if (diceNumber == player1.GetComponent<Player>().moveCount)
        {
            player1.SetActive(false);
        }
        if (diceNumber == player2.GetComponent<Player>().moveCount)
        {
            player2.SetActive(false);
        }
    }

    IEnumerator TurnNext(GameObject player)
    {
        yield return new WaitForSeconds(2.0f);

        if (player1.activeSelf == false && player2.activeSelf == false && maxTurn <= 6) // if ���ǹ��� �����̽��ٸ� ������ �Ѿ�� Ű�� �߰�����
        {

            if (turn <= maxTurn && Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("�� " + turn + " ����");
                player1.SetActive(true);
                player2.SetActive(true);
                Dice.GetComponent<Dice>().diceNumber = Random.Range(1, 7);
                diceNumber = Dice.GetComponent<Dice>().diceNumber; // 1~6���� ������              
                Debug.Log("�ֻ��� ���ڴ� " + diceNumber);
                int index = player.GetComponent<Player>().routine[diceNumber]; // Routine�� �� ������ ù ��ġ ���� ������ ���� 
                // diceNumber + 1 �̹Ƿ� index�� diceNubmer�� ������
                player.GetComponent<Player>().routine = new List<int>();
                player.GetComponent<Player>().routine.Add(index);               
                player.GetComponent<Player>().moveCount = 0;
                
                for (int i = 0; i < tiles.Length; i++)
                {
                    tiles[i].GetComponent<Tile>().currentColorNumber
                    = tiles[i].GetComponent<Tile>().colorNumber;
                }
                player.GetComponent<Player>().PlayerMove();

                turn++;
                turnEnd = true;

            }

        }
    }
    */




    void Win()
    {
        if (turn > maxTurn)
        {
            player1.SetActive(false);
            player2.SetActive(false);
            isGameOver = true;
        }

        if (isGameOver)
        {
            //Debug.Log("��������:" + isGameOver);
            TileCounter();

            if (redScore > blueScore)
            {
                winner = "player1";
            }
            else if (redScore < blueScore)
            {
                winner = "player2";
            }
            else
            {
                winner = "���ڰ� �������� ���߽��ϴ�.";
            }


        }



    }







    /*
    void Reset(GameObject player) // �÷��̾� ��ü�� ��ġ�� ����Ʈ�� �ְ� ��ȯ
    {


        if (Input.GetMouseButtonDown(0))
        {


            player.GetComponent<Player>().moveCount = 0;                      
            int index = player.GetComponent<Player>().routine[0];
            player.GetComponent<Player>().index = index;
            player.SetActive(true);
            player.transform.position = tiles[index].transform.position; // player�� ��ġ�� Ÿ�� �ε����� �����ϴ� ������ �迭
            player.GetComponent<Player>().routine = new List<int>();
            player.GetComponent<Player>().routine.Add(index);
            for (int i = 0; i < tiles.Length; i++)
            {
                int j = tiles[i].GetComponent<Tile>().currentColorNumber; // Ÿ���� �� ���� �� ����
                tiles[i].GetComponent<MeshRenderer>().material
                = tiles[i].GetComponent<Tile>().tileColor[j]; // �� �ʱ�ȭ
            }
            Debug.Log("�ʱ�ȭ");
        }

    }
    */
    public void OnClickReset()
    {

        player1.GetComponent<Player>().moveCount = 0;
        int index1 = player1.GetComponent<Player>().routine[0];
        player1.GetComponent<Player>().index = index1;
        player1.SetActive(true);
        player1.transform.position = tiles[index1].transform.position; // player�� ��ġ�� Ÿ�� �ε����� �����ϴ� ������ �迭
        player1.GetComponent<Player>().routine = new List<int>();
        player1.GetComponent<Player>().routine.Add(index1);

        player2.GetComponent<Player>().moveCount = 0;
        int index2 = player2.GetComponent<Player>().routine[0];
        player2.GetComponent<Player>().index = index2;
        player2.SetActive(true);
        player2.transform.position = tiles[index2].transform.position; // player�� ��ġ�� Ÿ�� �ε����� �����ϴ� ������ �迭
        player2.GetComponent<Player>().routine = new List<int>();
        player2.GetComponent<Player>().routine.Add(index2);

        for (int i = 0; i < tiles.Length; i++)
        {
            int j = tiles[i].GetComponent<Tile>().currentColorNumber; // Ÿ���� �� ���� �� ����
            tiles[i].GetComponent<MeshRenderer>().material
            = tiles[i].GetComponent<Tile>().tileColor[j]; // �� �ʱ�ȭ
        }
        Debug.Log("�ʱ�ȭ");

    }
    /*
    void Reset() // �÷��̾� ��ü�� ��ġ�� ����Ʈ�� �ְ� ��ȯ
    {


        if (Input.GetMouseButtonDown(0))
        {

            player1.GetComponent<Player>().moveCount = 0;
            int index1 = player1.GetComponent<Player>().routine[0];
            player1.GetComponent<Player>().index = index1;
            player1.SetActive(true);
            player1.transform.position = tiles[index1].transform.position; // player�� ��ġ�� Ÿ�� �ε����� �����ϴ� ������ �迭
            player1.GetComponent<Player>().routine = new List<int>();
            player1.GetComponent<Player>().routine.Add(index1);

            player2.GetComponent<Player>().moveCount = 0;
            int index2 = player2.GetComponent<Player>().routine[0];
            player2.GetComponent<Player>().index = index2;
            player2.SetActive(true);
            player2.transform.position = tiles[index2].transform.position; // player�� ��ġ�� Ÿ�� �ε����� �����ϴ� ������ �迭
            player2.GetComponent<Player>().routine = new List<int>();
            player2.GetComponent<Player>().routine.Add(index2);
            for (int i = 0; i < tiles.Length; i++)
            {
                int j = tiles[i].GetComponent<Tile>().currentColorNumber; // Ÿ���� �� ���� �� ����
                tiles[i].GetComponent<MeshRenderer>().material
                = tiles[i].GetComponent<Tile>().tileColor[j]; // �� �ʱ�ȭ
            }
            Debug.Log("�ʱ�ȭ");
        }

    }
    */

    void PlayerMove() // Player�� ���ϴ� ��� ���ÿ� ������
    {
        List<int> copyRoutine1 = player1.GetComponent<Player>().routine;
        List<int> copyRoutine2 = player2.GetComponent<Player>().routine;
        if (time == 0)
        {
            for (int i = 0; i <= diceNumber; i++)
            {

                //StartCoroutine(TurnMove(i, copyRoutine1, 1));
                //StartCoroutine(TurnMove(i, copyRoutine2, 2));
            }
            
        }

    }

    public void TurnMove(int i, List<int> copyRoutine, int id) // id�� �÷��̾� ��ȣ
    {
        player1.SetActive(true);
        player2.SetActive(true);
       
               
        int pos = copyRoutine[i];

        if (id == 1)
        {
            player1.transform.position = tiles[pos].transform.position;
        }
        else if (id == 2)
        {
            player2.transform.position = tiles[pos].transform.position;
        }
        
        // [ 123456 ] 
        /*
        int pos1 = player1.GetComponent<Player>().routine[i];
        player1.transform.position = tiles[pos1].transform.position;
        int pos2 = player2.GetComponent<Player>().routine[i];
        player2.transform.position = tiles[pos2].transform.position;
       */



    }



    public static void Rule()
    {
        int index1 = GameObject.Find("player1").GetComponent<Player>().index;
        int index2 = GameObject.Find("player2").GetComponent<Player>().index;
        if (index1 == index2)
        {

           GameObject.Find("player1").GetComponent<Player>().unPaint = true;
           GameObject.Find("player2").GetComponent<Player>().unPaint = true;


        }
        else
        {
            GameObject.Find("player1").GetComponent<Player>().unPaint = false;
            GameObject.Find("player2").GetComponent<Player>().unPaint = false;
        }
    }
}



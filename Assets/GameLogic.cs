using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private Text[] textInput = null;
    [SerializeField] private Text playerInput = null;
    [SerializeField] private Text _winnerText = null;
    [SerializeField] private int player = 1;
    [SerializeField] private int choice;
    [SerializeField] private GameObject _scene = null;
    private bool _isInput = false;
    private string winner;
    private int flag = 0;
    private int flags;

    // Start is called before the first frame update
    void Start()
    {
        
        playerInput.text = "Player1";
    }

    // Update is called once per frame
    void Update()
    {
        if (player % 2 == 0) { playerInput.text = "Player2"; } else playerInput.text = "Player1";
        choice = PlayerInput();
        if (choice <= textInput.Length - 1)
        {
            if (textInput[choice] != null)
            {
                Turn();
            }
        }
    }
    public void Turn()
    {
        if (flag == 0 && _isInput)
        {
            _OutPut();
        }
        else
        {
            _isInput = false;
        }
    }
    private void _OutPut()
    {
        if (textInput[choice].text != "X" && textInput[choice].text != "O")
        {
            if (player % 2 == 0)
            {
                winner = "Player 2";
                textInput[choice].text = "O";
                Win();
                player++;
            }
            else
            {
                winner = "Player 1";
                textInput[choice].text = "X";
                Win();
                player++;
            }
        }
    }
    private int Check()
    {
        // horizontal winning condition
        if (textInput[0].text == textInput[1].text && textInput[1].text == textInput[2].text)
        {
            flag = 1;
        }
        else if (textInput[3].text == textInput[4].text && textInput[4].text == textInput[5].text)
        {
            flag = 1;
        }
        else if (textInput[6].text == textInput[7].text && textInput[7].text == textInput[8].text)
        {
            flag = 1;
        }

        // Vertical winning condition
        else if (textInput[0].text == textInput[3].text && textInput[3].text == textInput[6].text)
        {
            flag = 1;
        }
        else if (textInput[1].text == textInput[4].text && textInput[4].text == textInput[7].text)
        {
            flag = 1;
        }
        else if (textInput[2].text == textInput[5].text && textInput[5].text == textInput[8].text)
        {
            flag = 1;
        }
        //Diagonal Winning cndition
        else if (textInput[0].text == textInput[4].text && textInput[4].text == textInput[8].text)
        {
            flag = 1;
        }
        else if (textInput[2].text == textInput[4].text && textInput[4].text == textInput[6].text)
        {
            flag = 1;
        }

        //For Draw Condition
        else if (textInput[0].text != "1" && textInput[1].text != "2" && textInput[2].text != "3" && textInput[3].text != "4" && textInput[4].text != "5" && textInput[5].text != "6"
            && textInput[6].text != "7" && textInput[7].text != "8" && textInput[8].text != "9")
        { flag = -1; }

        else flag = 0;
        return flag;
    }
    public void Win()
    {
        flags = Check();
        if (flags == 1)
        {
            _winnerText.text = winner + " has won!!!";
            Nextscene();
        }
        else if (flags == -1)
        {
            _winnerText.text = "Draw :(";
            Nextscene();
        }

    }
    public int PlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            choice = 0;
            _isInput = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            choice = 1;
            _isInput = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            choice = 2;
            _isInput = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            choice = 3;
            _isInput = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            choice = 4;
            _isInput = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            choice = 5;
            _isInput = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            choice = 6;
            _isInput = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            choice = 7;
            _isInput = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            choice = 8;
            _isInput = true;
        }
        return choice;
    }
    public void Nextscene()
    {
        if (_scene != null)
        {
            _scene.GetComponent<SceneManger>().LoadPlayAgain();
        }
    }
}

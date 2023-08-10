using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text[] scorePlayer;    
    [SerializeField] TMP_Text[] textArray;
    [SerializeField] TMP_Text moves;

    [SerializeField] Button[] buttonArray;

    [SerializeField] GameObject[] winPanel;

    [SerializeField] AudioSource ass;

    private int[,] board = new int[3, 3];
    private int moveCounter = 0;
    private int scoreOne = 0;
    private int scoreTwo = 0;

    [SerializeField] bool prvi = true;
    [SerializeField] bool[] fields = default;
    private bool once = false;
    //private bool onceDraw = false;
    private bool win = false;

    private void Start()
    {
        for(int i = 0; i < 9; i++)
        {
            fields[i] = true;
        }
    }

    private void Update()
    {
        Check(1);
        Check(2);
        moves.text = $"Moves: {moveCounter}";
    }

    public void ButtonClick1()
    {
        if (prvi)
        {
            textArray[0].text = "X";
            board[0, 0] = 1;
            moveCounter++;
        }
        else
        {
            textArray[0].text = "O";
            board[0, 0] = 2;
        }
        prvi = !prvi;
        buttonArray[0].interactable = false;
        fields[0] = false;
        ass.Play();
    }
    public void ButtonClick2()
    {
        if (prvi)
        {
            textArray[1].text = "X";
            board[0, 1] = 1;
            moveCounter++; 
        }
        else
        {
            textArray[1].text = "O";
            board[0, 1] = 2;
        }
        prvi = !prvi;
        fields[1] = false;
        buttonArray[1].interactable = false;
        ass.Play();
    }
    public void ButtonClick3()
    {
        if (prvi)
        {
            textArray[2].text = "X";
            board[0, 2] = 1;
            moveCounter++;
        }
        else
        {
            textArray[2].text = "O";
            board[0, 2] = 2;
        }
        prvi = !prvi;
        fields[2] = false;
        buttonArray[2].interactable = false;
        ass.Play();
    }
    public void ButtonClick4()
    {
        if (prvi)
        {
            textArray[3].text = "X";
            board[1, 0] = 1;
            moveCounter++;
        }
        else
        {
            textArray[3].text = "O";
            board[1, 0] = 2;
        }
        prvi = !prvi;
        fields[3] = false;
        buttonArray[3].interactable = false;
        ass.Play();
    }
    public void ButtonClick5()
    {
        if (prvi)
        {
            textArray[4].text = "X";
            board[1, 1] = 1;
            moveCounter++;
        }
        else
        {
            textArray[4].text = "O";
            board[1, 1] = 2;
        }
        prvi = !prvi;
        fields[4] = false;
        buttonArray[4].interactable = false;
        ass.Play();
    }
    public void ButtonClick6()
    {
        if (prvi)
        {
            textArray[5].text = "X";
            board[1, 2] = 1;
            moveCounter++;
        }
        else
        {
            textArray[5].text = "O";
            board[1, 2] = 2;
        }
        prvi = !prvi;
        fields[5] = false;
        buttonArray[5].interactable = false;
        ass.Play();
    }
    public void ButtonClick7()
    {
        if (prvi)
        {
            textArray[6].text = "X";
            board[2, 0] = 1;
            moveCounter++;
        }
        else
        {
            textArray[6].text = "O";
            board[2, 0] = 2;
        }
        prvi = !prvi;
        fields[6] = false;
        buttonArray[6].interactable = false;
        ass.Play();
    }
    public void ButtonClick8()
    {
        if (prvi)
        {
            textArray[7].text = "X";
            board[2, 1] = 1;
            moveCounter++;
        }
        else
        {
            textArray[7].text = "O";
            board[2, 1] = 2;
        }
        prvi = !prvi;
        fields[7] = false;
        buttonArray[7].interactable = false;
        ass.Play();
    }
    public void ButtonClick9()
    {
        if (prvi)
        {
            textArray[8].text = "X";
            board[2, 2] = 1;
            moveCounter++;
        }
        else
        {
            textArray[8].text = "O";
            board[2, 2] = 2;
        }
        prvi = !prvi;
        fields[8] = false;
        buttonArray[8].interactable = false;
        ass.Play();
    }

    private void Check(int player)
    {

        for(int i = 0; i < 3; i++)
        {
            if (board[i, 0] == player && board[i, 1] == player && board[i, 2] == player && !once)
            {
                win = true;
                StartCoroutine(YouWon(player));
                //return true;
            }

            if (board[0, i] == player && board[1, i] == player && board[2, i] == player && !once)
            {
                win = true;
                StartCoroutine(YouWon(player));
                //return true;
            }            
        }

        if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player && !once)
        {
            win = true;
            StartCoroutine(YouWon(player));
            //return true;
        }

        if (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player && !once)
        {
            win = true;
            StartCoroutine(YouWon(player));
            //return true;
        }
        if (player == 2 && buttonArray[0].interactable == false && buttonArray[1].interactable == false && buttonArray[2].interactable == false && buttonArray[3].interactable == false && buttonArray[4].interactable == false && buttonArray[5].interactable == false && buttonArray[6].interactable == false && buttonArray[7].interactable == false && buttonArray[8].interactable == false && !once && win == false)
        { 
            StartCoroutine(Draw());
            //return true;
        }
        
        //return false;
    }
    private IEnumerator YouWon(int player)
    {
        once = true;

        if (player == 1)
        {
            winPanel[0].SetActive(true);
            scoreOne++;
            scorePlayer[0].text = $"Score X: {scoreOne}";
        }
        else 
        {
            winPanel[1].SetActive(true);
            scoreTwo++;
            scorePlayer[1].text = $"Score O: {scoreTwo}";
        }

        for (int i = 0; i < 9; i++)
        {
            fields[i] = true;
        }

        yield return new WaitForSeconds(2);

        for(int i = 0; i < 3; i++)
        {
            board[0, i] = 0;
            board[1, i] = 0;
            board[2, i] = 0;
        }
        for(int i = 0; i < 9; i++)
        {
            buttonArray[i].interactable = true;
            textArray[i].text = null;
        }
        winPanel[0].SetActive(false);
        winPanel[1].SetActive(false);
        once = false;
        win = false;
    }
    private IEnumerator Draw()
    {
        once = true;
        winPanel[2].SetActive(true);

        for (int i = 0; i < 9; i++)
        {
            fields[i] = true;
        }

        yield return new WaitForSeconds(2);

        for (int i = 0; i < 3; i++)
        {
            board[0, i] = 0;
            board[1, i] = 0;
            board[2, i] = 0;
        }
        for (int i = 0; i < 9; i++)
        {
            buttonArray[i].interactable = true;
            textArray[i].text = null;
        }

        winPanel[2].SetActive(false);
        win = false;
        once = false;
    }
}

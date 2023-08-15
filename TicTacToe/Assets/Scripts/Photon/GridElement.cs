using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GridElement : MonoBehaviour
{
    public static GridElement Instance;

    [SerializeField] GameObject X;
    [SerializeField] GameObject O;

    public Button button;

    private MultiGameManager gameController;

    public int index;
    public bool isFinished = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    public void Clicked()
    {
        if (NetworkManager.Instance.IsMyTurn() == false)
            return;
        NetworkManager.Instance.isMyTurn = false;
        Player.Instance.Clicked(index);
        Fill(NetworkManager.Instance.isX);
        button.interactable = false;
    }

    public void Fill(bool isX)
    {
        MultiGameManager.Instance.moveCount++;
        if (isX)
        {
            X.SetActive(true);
        }
        else
        {
            O.SetActive(true);
        }

        int player = isX == true ? 1 : 2;
        Debug.Log($"I am {player}");

        if (index >= 0 && index <= 2)
        {
            NetworkManager.Instance.board[0, index] = player;
        }
        else if (index > 2 && index <= 5)
        {
            NetworkManager.Instance.board[1, index - 3] = player;
        }
        else
        {
            NetworkManager.Instance.board[2, index - 6] = player;
        }
        if (MultiGameManager.Instance.moveCount >= 9)
        {
            MultiGameManager.Instance.GameOver();
            MultiGameManager.Instance.SetGameOverText( "Draw!");
        }

        bool winnerResult = NetworkManager.Instance.checkWinner(player);
        if (winnerResult)
        {
            Debug.Log($"Winner is {player}");

            MultiGameManager.Instance.SetGameOverText( player +" " + "Wins!");
            //Shutter();
            //MultiGameManager.Instance.GameOver();
        }
    }
    
    public void Shutter()
    {
        SceneManager.LoadScene("MainMenu");
        NetworkManager._runner.Shutdown();
        //isFinished = true;
    }

    public void Restarter()
    {
        NetworkManager._runner.Shutdown();
        SceneManager.LoadScene("MultiPlay");
        //isFinished = true;
    }

    public void SetGameControllerReferance(MultiGameManager controller)
    {
        gameController = controller;
    }
}

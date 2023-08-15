using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
[System.Serializable]
public class Player
{
    public Image panel;
    public Text text;
}

[System.Serializable]
public class PlayerColor
{
    public Color panelColor;
    public Text textColor;
}
*/
public class GameController : MonoBehaviour
{
    public GridSpace[] buttonList;
    //public GridSpace[] buttonList2;
    private string playerSide;

    public GameObject gameOverPanel;
    public Text gameOverText;
    public GameObject RestartButton;
    //public NetworkRunner runner;

    private int moveCount;

    public Sprite xSprite;
    public Sprite oSprite;

    /*
        public Player playerX;
        public Player playerO;
        public PlayerColor activePlayerColor;
        public PlayerColor inactivePlayerColor;
    */

    private void Awake()
    {
        gameOverPanel.SetActive(false);
        RestartButton.SetActive(false);
        SetGameControllerReferanceOnButtons();
        playerSide = "X";
        moveCount = 0;
        // SetPlayerColor(playerX, playerO);
    }
    void SetGameControllerReferanceOnButtons()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReferance(this);
        }
    }

    /*public void SetStartingSide(string startingSide)
    {
        playerSide = startingSide;
        if (playerSide == "X")
        {
            SetPlayerColor(playerX, playerO);
        }
        else
        {
            SetPlayerColor(playerO, playerX);
        }
    }*/

    public string GetPlayerSide()
    {
        return playerSide;
    }

    public Sprite GetPlayerSideSprite()
    {
        return (playerSide == "X") ? xSprite : oSprite;
    }

    public void EndTurn()
    {
        Sprite currentSprite = (playerSide == "X") ? xSprite : oSprite;
        moveCount++;

        if (buttonList[0].buttonImage.sprite == currentSprite && buttonList[1].buttonImage.sprite == currentSprite && buttonList[2].buttonImage.sprite == currentSprite)
        {
            GameOver();
        }
        else if (buttonList[3].buttonImage.sprite == currentSprite && buttonList[4].buttonImage.sprite == currentSprite && buttonList[5].buttonImage.sprite == currentSprite)
        {
            GameOver();
        }
        else if (buttonList[6].buttonImage.sprite == currentSprite && buttonList[7].buttonImage.sprite == currentSprite && buttonList[8].buttonImage.sprite == currentSprite)
        {
            GameOver();
        }
        else if (buttonList[0].buttonImage.sprite == currentSprite && buttonList[3].buttonImage.sprite == currentSprite && buttonList[6].buttonImage.sprite == currentSprite)
        {
            GameOver();
        }
        else if (buttonList[1].buttonImage.sprite == currentSprite && buttonList[4].buttonImage.sprite == currentSprite && buttonList[7].buttonImage.sprite == currentSprite)
        {
            GameOver();
        }
        else if (buttonList[2].buttonImage.sprite == currentSprite && buttonList[5].buttonImage.sprite == currentSprite && buttonList[8].buttonImage.sprite == currentSprite)
        {
            GameOver();
        }
        else if (buttonList[0].buttonImage.sprite == currentSprite && buttonList[4].buttonImage.sprite == currentSprite && buttonList[8].buttonImage.sprite == currentSprite)
        {
            GameOver();
        }
        else if (buttonList[2].buttonImage.sprite == currentSprite && buttonList[4].buttonImage.sprite == currentSprite && buttonList[6].buttonImage.sprite == currentSprite)
        {
            GameOver();
        }
        else
        {
            if (moveCount >= 9)
            {
                SetGameOverText("DRAW!");
            }
        }

        ChangeSides();
    }
    /*
    void SetPlayerColor(Player newPlayer, Player oldPlayer)
    {
        newPlayer.panel.color = activePlayerColor.panelColor;
        oldPlayer.panel.color = inactivePlayerColor.panelColor;
    }*/

    void GameOver()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = false;
        }
        SetGameOverText(playerSide + " " + "Wins!");
    }
    void ChangeSides()
    {
        playerSide = (playerSide == "X") ? "O" : "X";

        /*  if(playerSide == "X")
          {
              SetPlayerColor(playerX, playerO);
          }
          else
          {
              SetPlayerColor(playerO, playerX);
          }*/
    }
    void SetGameOverText(string value)
    {
        gameOverPanel.SetActive(true);
        RestartButton.SetActive(true);
        gameOverText.text = value;
    }

    //public void Back()
    //{
    //    runner.Shutdown();
    //}

}

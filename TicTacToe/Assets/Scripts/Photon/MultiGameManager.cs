using UnityEngine;
using System;
using Fusion;
using UnityEngine.UI;

public class MultiGameManager : MonoBehaviour
{
    public static MultiGameManager Instance;

    public GameObject gameOverPanel;
    public Text gameOverText;
    public GameObject RestartButton;

    public int moveCount;

    public void Awake()
    {
        if(Instance == null)
            Instance = this;
        gameOverPanel.SetActive(false);
        RestartButton.SetActive(false);
        SetGameControllerReferanceOnButtons();
        moveCount = 0;
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        RestartButton.SetActive(true);
    }
    void SetGameControllerReferanceOnButtons()
    {
        for (int i = 0; i < 9; i++)
        {
            NetworkManager.Instance.gridElements[i].GetComponentInParent<GridElement>().SetGameControllerReferance(this);
        }
    }

    public void SetGameOverText(string value)
    {
        gameOverPanel.SetActive(true);
        RestartButton.SetActive(true);
        gameOverText.text = value;
    }
}
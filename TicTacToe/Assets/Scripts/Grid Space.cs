using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour
{
    public Button button;
    public Text buttonText;
    public Image buttonImage;

    private GameController gameController;

    public void SetSpace()
    {
        buttonImage.gameObject.SetActive(true);
        buttonImage.sprite  = gameController.GetPlayerSideSprite();
        buttonText.text = gameController.GetPlayerSide();
        button.interactable = false;
        gameController.EndTurn();
    }

    public void SetGameControllerReferance(GameController controller)
    {
        gameController = controller;
    }
}
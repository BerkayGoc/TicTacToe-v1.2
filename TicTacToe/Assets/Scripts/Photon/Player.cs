using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using UnityEngine.SceneManagement;

public class Player : NetworkBehaviour
{
    public static Player Instance;

    //bool isFinish = GridElement.Instance.isFinished;

    [Networked]
    public int Score { get; set; }
    public override void Spawned()
    {
        if (Object.HasStateAuthority)
        {
            Instance = this;
        }
    }


    public void Clicked(int index)
    {
        Rpc_Clicked(index, NetworkManager.Instance.isX);
    }

    [Rpc]
    public void Rpc_Clicked(int index, bool isX)
    {
        //Debug.Log("rpc");
        Debug.Log(index + " karesi tiklandi");
        if (/*Runner.LocalPlayer == */Object.HasStateAuthority)
            return;
        //Debug.Log("rpc2");
        Instance.ClickedTaked(index, isX);
        //if (isFinish)
        //{
        //    SceneManager.LoadScene("MainMenu");
        //    NetworkManager._runner.Shutdown();
        //}
    }

    public void ClickedTaked(int index, bool isX)
    {
        NetworkManager.Instance.gridElements[index].Fill(isX);
        NetworkManager.Instance.isMyTurn = true;
    }

}

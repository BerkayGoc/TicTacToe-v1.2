using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using Fusion.Sockets;
using System;
using UnityEngine.SceneManagement;
using System.Linq;

public class NetworkManager : MonoBehaviour, INetworkRunnerCallbacks
{
    public static NetworkManager Instance;
    public static NetworkRunner _runner;

    [SerializeField] private NetworkPrefabRef _playerPrefab;

    private Dictionary<PlayerRef, NetworkObject> _spawnedCharacters = new Dictionary<PlayerRef, NetworkObject>();


    public bool isX;

    public bool isMyTurn;
    public bool isMine;


    public GridElement[] gridElements;

    public int[,] board { get; set; } = {
        { 0, 0, 0 },
        { 0, 0, 0 },
        { 0, 0, 0 }
    };

    private void Awake()
    {
        Instance = this;
        _runner = GetComponent<NetworkRunner>();
    }

    private void Start()
    {
        StartGame();
    }

    public bool checkWinner(int player)
    {
        //Debug.Log("checkingwinner");
        // check rows
        if (board[0, 0] == player && board[0, 1] == player && board[0, 2] == player) { Debug.Log("checkingwinner row"); MultiGameManager.Instance.GameOver();  return true; }
        if (board[1, 0] == player && board[1, 1] == player && board[1, 2] == player) { Debug.Log("checkingwinner row"); MultiGameManager.Instance.GameOver(); return true; }
        if (board[2, 0] == player && board[2, 1] == player && board[2, 2] == player) { Debug.Log("checkingwinner row"); MultiGameManager.Instance.GameOver(); return true; }

        // check columns
        if (board[0, 0] == player && board[1, 0] == player && board[2, 0] == player) { Debug.Log("checkingwinner columns"); MultiGameManager.Instance.GameOver(); return true; }
        if (board[0, 1] == player && board[1, 1] == player && board[2, 1] == player) { Debug.Log("checkingwinner columns"); MultiGameManager.Instance.GameOver(); return true; }
        if (board[0, 2] == player && board[1, 2] == player && board[2, 2] == player) { Debug.Log("checkingwinner columns"); MultiGameManager.Instance.GameOver(); return true; }

        // check diags
        if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player) { Debug.Log("checkingwinner diags"); MultiGameManager.Instance.GameOver(); return true; }
        if (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player) { Debug.Log("checkingwinner diags"); MultiGameManager.Instance.GameOver(); return true; }

        return false;
    }

    async void StartGame()
    {
        // Create the Fusion runner and let it know that we will be providing user input
        _runner.ProvideInput = true;

        // Start or join (depends on gamemode) a session with a specific name
        await _runner.StartGame(new StartGameArgs()
        {
            GameMode = GameMode.Shared,
            SessionName = "TestRoom",
            Scene = SceneManager.GetActiveScene().buildIndex,
            SceneManager = gameObject.GetComponent<NetworkSceneManagerDefault>()
        });
    }



    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        Debug.Log("On Player Joined");

        if (!_spawnedCharacters.ContainsKey(player) && player == runner.LocalPlayer)
        {
            NetworkObject networkPlayerObject = runner.Spawn(_playerPrefab);
            _spawnedCharacters.Add(player, networkPlayerObject);
            isX = runner.ActivePlayers.Count() == 1;
            isMyTurn = isX;
            isMine = true;
        }


    }

    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
        if (_spawnedCharacters.TryGetValue(player, out NetworkObject networkObject))
        {
            runner.Despawn(networkObject);
            _spawnedCharacters.Remove(player);
        }
    }

    public bool IsMyTurn()
    {
        return isMyTurn;
    }



    #region



    public void OnConnectedToServer(NetworkRunner runner)
    {

    }

    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
    {

    }

    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
    {

    }

    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
    {

    }

    public void OnDisconnectedFromServer(NetworkRunner runner)
    {

    }

    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
    {

    }

    public void OnInput(NetworkRunner runner, NetworkInput input)
    {

    }

    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
    {

    }



    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data)
    {

    }

    public void OnSceneLoadDone(NetworkRunner runner)
    {

    }

    public void OnSceneLoadStart(NetworkRunner runner)
    {

    }

    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {

    }

    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {

    }

    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
    {

    }
    #endregion
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{
    private void Start()
    {
    }
    public void LoadScene(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
    }

    public void ExitFusion()
    {
        GridElement.Instance.Shutter();
    }

    public void RestartFusion()
    {
        GridElement.Instance.Restarter();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    public void ResetGameSettings()
    {
    }
}

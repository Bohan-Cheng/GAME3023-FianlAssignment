using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_Menu : MonoBehaviour
{
    [SerializeField]
    string StartMapName;

    public void OnStartButtonPressed()
    {
        SceneManager.LoadScene(StartMapName);
    }

    public void OnQuitButtonPressed()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class MainMenuScripts : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Game"));
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}

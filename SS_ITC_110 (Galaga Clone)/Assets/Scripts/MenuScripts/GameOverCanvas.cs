using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverCanvas : MonoBehaviour
{
    public Canvas canvas;

    public static GameOverCanvas gameOverCanvas;

    private void Start()
    {
        //this is a reference to this specific instance of the script. We need it for OOP reasons. 
        gameOverCanvas = this;
    }

    public static void ActivateGameOverCanvas()
    {
        foreach(GameObject element in gameOverCanvas.canvas.transform.GetComponentsInChildren<GameObject>())
        {
            //this is a bit opaque. Basically, to turn off the current score and turn on the other objects, we just reverse the states
            element.SetActive(!element.activeSelf);
        }
    }

    public void MainMenuButton()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("MenuScreen"));
    }

    public void NewGameButton()
    {
        SceneManager.SetActiveScene(SceneManager.GetActiveScene());
    }
}

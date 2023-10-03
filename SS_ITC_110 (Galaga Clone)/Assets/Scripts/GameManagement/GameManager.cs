using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]private int PlayerScore = 0;
    public int Score { 
        get { return PlayerScore; }
        set
        {
            PlayerScore += value;
            ScoreWatcher.BumpScore(PlayerScore);
        }
    }

    [SerializeField]private int Level = 1;
    public int Lvl
    {
        get { return Level; }
        set => LevelUp();
    }

    private GameOverCanvas gameOverCanvas;

    //Here are all the enemies for each wave
    public static List<GameObject> ActiveEnemies;
    public static GameManager gameManager;

    //GameOver screen elements
    public TextMeshProUGUI highScoreText, maxlevelText;

    void Start()
    {
        ActiveEnemies = new List<GameObject>();
        gameManager = this;
    }

    public static void FlushEnemy(GameObject enemy){
        ActiveEnemies.Remove(enemy);
        Destroy(enemy);
    }

    private void LevelUp()
    {
        Spawner.SetSpawnManagerVals(++Level);
        Spawner.Spawn();
    }

    public static void OnDeath()
    {
        ActiveEnemies.Clear();
        if(gameManager.Score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", gameManager.Score);
        }

        gameManager.highScoreText.text += PlayerPrefs.GetInt("HighScore").ToString();
        gameManager.maxlevelText.text += gameManager.Level.ToString();

        GameOverCanvas.ActivateGameOverCanvas();
    }
}
using System.Collections.Generic;
using System.Linq;
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

    private int currentScore = 0;

    public int CurrentScore
    {
        set { currentScore += value; }
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

    public bool OnLevel = true;
    
    void Start()
    {
        ActiveEnemies = new List<GameObject>();
        gameManager = this;
        
        Spawner.Spawn();
    }

    void Update()
    {
        int curPointVal = Spawner.spawner.entitiesToSpawn[Level-1].GetComponent<BadGuyBrain>().pointVal;
        if (currentScore >=  curPointVal * Spawner.spawner.currSpawnManagerValues.prefabsToSpawn[0])
        {
            currentScore = 0;
            LevelUp();  
        }
    }

    public static void FlushEnemy(GameObject enemy){
        ActiveEnemies.Remove(enemy);
        Destroy(enemy);
    }

    private void LevelUp()
    {
        Spawner.SetSpawnManagerVals(Level++);
        Spawner.Spawn();
    }

    public static void OnDeath()
    {
        Time.timeScale = 0.0f;
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
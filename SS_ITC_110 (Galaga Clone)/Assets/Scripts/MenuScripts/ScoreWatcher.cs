using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreWatcher : MonoBehaviour
{
    public static ScoreWatcher Instance;
    private TextMeshProUGUI scoreText;


    private void Start()
    {
        Instance = this;
        scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
    }

    public static void BumpScore(int pointVal)
    {
        Instance.scoreText.text = "Score: " + pointVal;
    }
}

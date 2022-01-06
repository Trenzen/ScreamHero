using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text scoreRef;
    private int score;
    private int highScore;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        highScore = PlayerPrefs.GetInt("HighScoreKeeper", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameConstants.spawnPosition == true)
        {
            if (GameConstants.scoreKeeper > 0)
            {
                score++;
                GameConstants.scoreKeeper--;
                scoreRef.text = score.ToString();
                if (score > highScore)
                {
                    highScore = score;
                }
            }
        }
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("HighScoreKeeper", highScore);
    }
}

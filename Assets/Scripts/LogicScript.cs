using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    private int highestScore;
    public Text scoreText;
    public Text highestScoreText;
    public GameObject gameOverScreen;
    public AudioSource pointSound;

    public void Start()
    {
        highestScore = LoadData();
        highestScoreText.text = ("Highest Score: " + LoadData().ToString());
    }
    public void Update()
    {
        
    }
    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        pointSound.Play();
        scoreText.text = playerScore.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        if (highestScore <= playerScore)
        {
            SaveData();
        }
        
    }

    private void SaveData()
    {
        highestScore = playerScore;
        PlayerPrefs.SetInt("HighestScore", highestScore);
    }
    private int LoadData()
    {
        return PlayerPrefs.GetInt("HighestScore");
    }
    public void DeleteData()
    {
        PlayerPrefs.DeleteKey("HighestScore");
    }
}

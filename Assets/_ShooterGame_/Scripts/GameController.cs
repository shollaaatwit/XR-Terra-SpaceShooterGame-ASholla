using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : Singleton<GameController>
{
    // Start is called before the first frame update

    public Canvas startCanvas;
    public Canvas pauseCanvas;
    public Canvas gameCanvas;
    public Canvas gameOverCanvas;
    public Canvas highscoreCanvas;
    public GameObject winGraphic;
    
    public Player player;
    public LevelController levelController;
    public Text scoreText;


    private int _currentScore;


    void Start()
    {
        ResetUI();
        disableEntities();

        LoadGameData();

        _currentScore = 0;
        UpdateScoreText();

    }

    public void StartGame()
    {

        startCanvas.gameObject.SetActive(false);
        gameCanvas.gameObject.SetActive(true);

        player.gameObject.SetActive(true);
        levelController.gameObject.SetActive(true);
    }

    public void PauseGame(bool pause)
    {
        pauseCanvas.gameObject.SetActive(pause);  
        Time.timeScale = (pause) ? 0 : 1f;
    }

    public void GameOver()
    {
        gameOverCanvas.gameObject.SetActive(true);
        Time.timeScale = 0;

        CheckAndDisplayWin();
        SaveGameData();

    }

    public void Replay()
    {
        Time.timeScale = 1f;
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }

    private void ResetUI()
    {
        startCanvas.gameObject.SetActive(true);
        pauseCanvas.gameObject.SetActive(false);
        gameCanvas.gameObject.SetActive(false);
        gameOverCanvas.gameObject.SetActive(false);
        winGraphic.SetActive(false);
        
    }

    public void highscoreMenu()
    {
        gameOverCanvas.gameObject.SetActive(false);
        highscoreCanvas.gameObject.SetActive(true);
        HighScoreController.Instance.UpdateHighScoreList();
    }

    private void disableEntities()
    {
        player.gameObject.SetActive(false);
        levelController.gameObject.SetActive(false);
    }

    public void IncrementScore(int points)
    {
        _currentScore += points;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + _currentScore;

    }

    private void CheckAndDisplayWin()
    {
        if (HighScoreController.Instance.AddHighScore(_currentScore))
        {
            winGraphic.SetActive(true);
        }
        else
        {
            winGraphic.SetActive(false);
        }
    }

    private void SaveGameData()
    {
        GameData data = new GameData()
        {
            savedHighScores = HighScoreController.Instance.highscores
        };

        GameDataIO.SaveGameData(data);

    }

    private void LoadGameData()
    {
        GameData data = GameDataIO.LoadGameData();
        if (data != null)
        {
            HighScoreController.Instance.highscores = data.savedHighScores;
        }

    }
}

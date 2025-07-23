using UnityEngine;

public class MainMenuState : IGameState
{
    private readonly GameManager _gameManager;

    public MainMenuState(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    public void Enter()
    {
        _gameManager.MainMenuCanvas.gameObject.SetActive(true);
        _gameManager.InGameCanvas.gameObject.SetActive(false);
        _gameManager.GameOverCanvas.gameObject.SetActive(false);
        _gameManager.GameEnvironment.SetActive(false);
        _gameManager.HighScoreText.Text.text = "HIGH SCORE: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        UnityEngine.Time.timeScale = 0;
    }

    public void Update()
    {

    }

    public void Exit()
    {
        _gameManager.MainMenuCanvas.gameObject.SetActive(false);
    }

}
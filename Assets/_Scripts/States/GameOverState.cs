using UnityEngine;

public class GameOverState : IGameState
{
    private readonly GameManager _gameManager;

    public GameOverState(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    public void Enter()
    {
        UnityEngine.Time.timeScale = 0;
        _gameManager.GameOverCanvas.gameObject.SetActive(true);
        _gameManager.GameEnvironment.SetActive(false);
        if (_gameManager.Score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", _gameManager.Score);
        }
        _gameManager.EndScoreText.Text.text = "SCORE: " + _gameManager.Score.ToString();
    }

    public void Update()
    {
        return;
    }

    public void Exit()
    {
        _gameManager.GameOverCanvas.gameObject.SetActive(false);
    }
}
using UnityEngine;

public class InGameState : IGameState
{
    private readonly GameManager _gameManager;

    public InGameState(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    public void Enter()
    {
        UnityEngine.Time.timeScale = 1;
        _gameManager.InGameCanvas.gameObject.SetActive(true);
        _gameManager.GameEnvironment.SetActive(true);
        _gameManager.NewGame();
    }

    public void Update()
    {
        _gameManager.Time -= UnityEngine.Time.deltaTime;
        _gameManager.TimeText.Text.text = "Time: " + Mathf.Round(_gameManager.Time).ToString();
        _gameManager.ScoreText.Text.text = "Score: " + _gameManager.Score.ToString();
        if (_gameManager.Time <= 0)
        {
            _gameManager.ChangeState(new GameOverState(_gameManager));
        }

    }

    public void Exit()
    {
        _gameManager.InGameCanvas.gameObject.SetActive(false);
    }
}
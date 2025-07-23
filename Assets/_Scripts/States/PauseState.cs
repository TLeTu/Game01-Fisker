using UnityEngine;

public class PauseState : IGameState
{
    private readonly GameManager _gameManager;

    public PauseState(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    public void Enter()
    {
        UnityEngine.Time.timeScale = 0;
        _gameManager.InGameCanvas.gameObject.SetActive(false);
        _gameManager.GameEnvironment.SetActive(false);
    }
    public void Update()
    {
        return;
    }

    public void Exit()
    {
        UnityEngine.Time.timeScale = 1;
    }
}
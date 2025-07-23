using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [field: SerializeField] public FishSpawner FishSpawner;
    [field: SerializeField] public BaseText TimeText {get; private set;}
    [field: SerializeField] public BaseText ScoreText {get; private set;}
    [field: SerializeField] public BaseText HighScoreText {get; private set;}
    [field: SerializeField] public BaseText EndScoreText {get; private set;}
    [field: SerializeField] public GameObject GameEnvironment {get; private set;}
    [field: SerializeField] public Canvas MainMenuCanvas {get; private set;}
    [field: SerializeField] public Canvas InGameCanvas {get; private set;}
    [field: SerializeField] public Canvas GameOverCanvas {get; private set;}
    
    public int Score { get ; set; }
    public float Time { get; set; }
    [SerializeField] private float _defaultTime = 100;

    private IGameState _currentState;

    private void Start()
    {
        // Initialize the game by transitioning to the MainMenuState.
        ChangeState(new MainMenuState(this));
    }

    private void Update()
    {
        _currentState?.Update();
        // Log out the current stae
        
    }

    public void ChangeState(IGameState newState)
    {
        if (_currentState != null) Debug.Log(GetCurrentState().ToString());
        Debug.Log(newState.ToString());
        _currentState?.Exit();
        _currentState = newState;
        _currentState?.Enter();
    }

    public void RestartGame()
    {
        Time = _defaultTime;
        Score = 0;
        FishSpawner.ReturnAllFishToPool();
        ChangeState(new InGameState(this));
    }

    public void NewGame()
    {
        Time = _defaultTime;
        Score = 0;
        FishSpawner.ReturnAllFishToPool();
    }

    public IGameState GetCurrentState()
    {
        return _currentState;
    }

}
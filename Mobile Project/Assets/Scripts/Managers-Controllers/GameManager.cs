using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;
using System;

public class GameManager : Singleton<GameManager>
{
    [Header("Player")]
    [SerializeField]
    private PlayerController _playerController;

    [Header("UI")]
    [SerializeField]
    private UIController _uiController;

    [Header("Level")]
    [SerializeField]
    private LevelManager _levelManager;

    [Header("Particle")]
    [SerializeField]
    private ParticleController _particleController;

    #region Events

    public event Action<bool> OnRunningGame;

    #endregion
    public bool IsRunning
    {
        get => _isRunning;
    }

    private bool _isRunning;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        _levelManager.Init();
        _uiController.SetScreenVisibility(UIController.ScreenType.START, true);
    }

    #region Game Flow

    public void StartGame()
    {
        _isRunning = true;

        OnRunningGame?.Invoke(_isRunning);

        _playerController.StartToRun();
    }

    public void EndGame()
    {
        _isRunning = false;

        _playerController.StopToRun();

        OnRunningGame?.Invoke(_isRunning);

        _uiController.SetScreenVisibility(UIController.ScreenType.END, true);   
    }

    public void CallVictory()
    {
        _playerController.PlayerVictory();

        _uiController.SetScreenVisibility(UIController.ScreenType.VICTORY, true);       
    }

    #endregion

    #region Particle System

    public void PlayParticle(ParticleType type, Vector3 position)
    {
        _particleController.PlayParticleByType(type, position);
    }

    #endregion
}

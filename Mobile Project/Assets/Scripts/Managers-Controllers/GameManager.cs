using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;
using System;
using Screen;

public class GameManager : Singleton<GameManager>
{
    [Header("Player")]
    [SerializeField]
    private PlayerController _playerController;

    [Header("Level")]
    [SerializeField]
    private LevelManager _levelManager;

    [SerializeField]
    private Transform _GroundCollider;

    [Header("Particle")]
    [SerializeField]
    private ParticleController _particleController;

    public Transform LevelGround
    {
        get => _GroundCollider;
    }

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

        ScreenManager.Instance.HideAll();
        ScreenManager.Instance.ShowByType(ScreenType.Start);
    }

    #region Game Flow

    public void StartGame()
    {
        _isRunning = true;

        OnRunningGame?.Invoke(_isRunning);

        _playerController.StartToRun();
    }

    public void StopGame()
    {
        _isRunning = false;

        _playerController.StopToRun();

        OnRunningGame?.Invoke(_isRunning);

        ScreenManager.Instance.ShowByType(ScreenType.Looser);
    }

    public void CallVictory()
    {
        _isRunning = false;

        _playerController.PlayerVictory();

        ScreenManager.Instance.ShowByType(ScreenType.Winner);
    }

    #endregion

    #region Particle System

    public void PlayParticle(ParticleType type, Vector3 position)
    {
        _particleController.PlayParticleByType(type, position);
    }

    #endregion
}

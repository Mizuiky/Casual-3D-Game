using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;

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
        _playerController.StartToRun();
    }

    public void EndGame()
    {
        _playerController.StopToRun();

        _uiController.SetScreenVisibility(UIController.ScreenType.END, true);   
    }

    public void CallVictory()
    {
        _playerController.PlayerVictory();

        _uiController.SetScreenVisibility(UIController.ScreenType.VICTORY, true);       
    }

    #endregion
}

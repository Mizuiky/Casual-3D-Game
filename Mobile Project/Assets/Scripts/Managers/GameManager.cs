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

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        _playerController.CanRun = true;
    }

    public void EndGame()
    {
        _playerController.CanRun = false;
        _uiController.SetScreenVisibility(UIController.ScreenType.END, true);
    }
}

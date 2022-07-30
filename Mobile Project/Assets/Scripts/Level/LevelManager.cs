using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _levels;

    [SerializeField]
    private int _numberOfPieces;

    private int _index = 0;

    private GameObject _currentLevel;

    private void Start()
    {
        InitializeNextLevel();
    }

    public void InitializeNextLevel()
    {
        if (_index >= _levels.Count)
            _index = 0;

        if (_currentLevel != null)
            Destroy(_currentLevel);

        _currentLevel = Instantiate(_levels[_index], transform);

        _index++;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            InitializeNextLevel();
        }
    }

}

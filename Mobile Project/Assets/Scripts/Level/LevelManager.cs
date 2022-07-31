using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    #region Serializable Fields

    [Header("Type")]
    [SerializeField]
    private LevelType _levelType;

    [Header("Container")]
    [SerializeField]
    private Transform _levelContainer;

    [SerializeField]
    private Transform _startPosition;

    [Header("Static Level")]
    [SerializeField]
    private List<GameObject> _levels;

    [Header("Dinamic Level")]
    [SerializeField]
    private List<LevelPiece> _levelPieces;

    [SerializeField]
    private int _numberOfPieces;

    #endregion

    #region Private Fields

    private int _index = 0;

    private GameObject _currentLevel;

    private List<LevelPiece> _spawnedPieces;

    #endregion

    public enum LevelType
    {
        NONE,
        STATIC,
        DINAMIC
    }

    public void Init()
    {
        InitCurrentLevelType();
    }

    public void InitCurrentLevelType()
    {
        switch (_levelType)
        {
            case LevelType.STATIC:

                InitializeNextStaticLevel();

                break;
            case LevelType.DINAMIC:

                InitiateDinamicLevel();

                break;
            default: return;
        }
    }

    #region Static Level

    public void InitializeNextStaticLevel()
    {
        if (_index >= _levels.Count)
            _index = 0;

        if (_currentLevel != null)
            Destroy(_currentLevel);

        _currentLevel = Instantiate(_levels[_index], _levelContainer);
        _currentLevel.transform.localPosition = Vector3.zero;

        _index++;
    }

    #endregion

    #region Dinamic Level

    public void InitiateDinamicLevel()
    {
        _spawnedPieces = new List<LevelPiece>();

        for (int i = 0; i < _numberOfPieces; i++)
        {
            CreateDinamicPiece();
        }           
    }

    public void CreateDinamicPiece()
    {
        //get the random piece from _levelPieces list and instantiate it
        var spawnedPiece = GetRandomPiece();

        if(spawnedPiece != null)
        {
            //set the current bounds.size to get the piece width
            spawnedPiece.Init();

            SetCurrentPiecePosition(spawnedPiece);
        }      
    }

    private LevelPiece GetRandomPiece()
    {
        var randomPiece = _levelPieces[Random.Range(0, _levelPieces.Count)];

        var spawnedPiece = Instantiate(randomPiece, _levelContainer);

        return spawnedPiece ? spawnedPiece : null;
    }

    private void SetCurrentPiecePosition(LevelPiece spawnedPiece)
    {
        //reset the piece position to avoid position problems
        var newPosition = Vector3.zero;

        if (_spawnedPieces.Count > 0)
        {
            //get the last piece
            var lastPiece = _spawnedPieces.Last();

            //The new piece will receive the previous piece position
            newPosition = lastPiece.transform.position;

            //get the current piece width
            var currentPieceSize = spawnedPiece.Size;

            /*Data
              get the previous size divided by 2
              get the current piece size divided by 2 
            */

            //the sum of this Data plus the newposition.z will be the newPosition to the current piece

            newPosition.z += (lastPiece.Size.z / 2) + (currentPieceSize.z / 2);

            //set the newPosition to the currentPiece
            spawnedPiece.SetPosition(newPosition);
        }
        else
        {
            //the first piece will receive the setted startPosition
            spawnedPiece.SetPosition(_startPosition.position);
        }

        //add the piece to the _spawnedPieces list
        _spawnedPieces.Add(spawnedPiece);
    }

    #endregion

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A) && _levelType == LevelType.STATIC)
        {
            InitializeNextStaticLevel();
        }
    }
}

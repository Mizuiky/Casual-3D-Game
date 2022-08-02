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
    private SO_Level _levelSetup;

    [SerializeField]
    private ArtManager _artManager;

    #endregion

    #region Private Fields

    private int _index = 0;

    private GameObject _currentStaticLevel;

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
        _spawnedPieces = new List<LevelPiece>();

        InitLevelByType();
    }

    public void InitLevelByType()
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

        if (_currentStaticLevel != null)
            Destroy(_currentStaticLevel);

        _currentStaticLevel = Instantiate(_levels[_index], _levelContainer);
        _currentStaticLevel.transform.localPosition = Vector3.zero;

        _index++;
    }

    #endregion

    #region Dinamic Level

    public void InitiateDinamicLevel()
    {
        CleanSpawnedList();

        StartCoroutine("CreatePiece");
    }

    private IEnumerator CreatePiece()
    {
        for (int i = 0; i < _levelSetup._numberOfPieces; i++)
        {
            CreateDinamicPiece(i);

            yield return new WaitForSeconds(_levelSetup._timeBetweenPieces);
        }
    }

    private void CreateDinamicPiece(int index)
    {
        //get level piece from _levelPieces list
        var spawnedPiece = GetPiece(index);

        if (spawnedPiece != null)
        {
            //set the current bounds.size to get the piece width
            spawnedPiece.Init();

            if(spawnedPiece.ArtPiecesSize > 0)
            {
                spawnedPiece.SetArtPieces(_artManager.GetArtByType(_levelSetup._artType));
                //_artManager.SetArtColor(_levelSetup._artType);
            }
                

            SetCurrentPiecePosition(spawnedPiece);
        }
    }

    private LevelPiece GetPiece(int index)
    {
        LevelPiece randomPiece = null;

        if (index == 0)
        {
            randomPiece = _levelSetup._startLevelPiece;
        }
        else if (index == _levelSetup._numberOfPieces - 1)
        {
            randomPiece = _levelSetup._endLevelPiece;
        }
        else
        {
            //get the random piece from _levelPieces list and instantiate it
            randomPiece = _levelSetup._levelPieces[Random.Range(0, _levelSetup._levelPieces.Count)];
        }

        if (randomPiece != null)
        {
            var spawnedPiece = Instantiate(randomPiece, _levelContainer);

            return spawnedPiece ? spawnedPiece : null;
        }

        return null;
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

    private void CleanSpawnedList()
    {
        for (int i = _spawnedPieces.Count - 1; i >= 0; i--)
        {
            Destroy(_spawnedPieces[i].gameObject);
        }

        _spawnedPieces.Clear();
    }
    #endregion

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && _levelType == LevelType.STATIC)
        {
            InitializeNextStaticLevel();
        }
        if (Input.GetKeyDown(KeyCode.Z) && _levelType == LevelType.DINAMIC)
        {
            InitiateDinamicLevel();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement Setup")]

    [SerializeField]
    private List<Transform> _positionsToGo;

    [SerializeField]
    private float _duration;

    #region private Fileds

    private Vector3 _currentPosition;

    private int _index;

    private bool _canMove;

    private Coroutine _currentCoroutine;

    #endregion

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        _index = 0;

        transform.position = _positionsToGo[0].position;

        NextIndex();

        GameManager.Instance.OnRunningGame += StartToMove;    
    }

    private void NextIndex()
    {
        _index++;

        if (_index >= _positionsToGo.Count)
            _index = 0;       
    }

    private void StartToMove(bool isRunning)
    {
        Debug.Log("Start to move 1");
        _canMove = isRunning;

        if (isRunning)
            _currentCoroutine = StartCoroutine(Move());
        else
            StopCoroutine(_currentCoroutine);
    }

    private IEnumerator Move()
    {
        Debug.Log("Start to move 2");
        float time = 0;

        while (_canMove)
        {
            Debug.Log("Start to move 3");
            while (time < _duration)
            {
                Debug.Log("Start to move 4");
                _currentPosition = transform.position;

                transform.position = Vector3.Lerp(_currentPosition, _positionsToGo[_index].position, (time / _duration));

                time += Time.deltaTime;

                yield return null;
            }

            NextIndex();

            time = 0;

            yield return null;
        }      
    }

    private void OnDisable()
    {
        GameManager.Instance.OnRunningGame -= StartToMove;
    }
}

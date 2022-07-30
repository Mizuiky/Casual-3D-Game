using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelPiece : MonoBehaviour, ILevelPiece
{
    [SerializeField]
    private Transform _start;

    [SerializeField]
    private Transform _end;

    public Transform StartPoint 
    {
        get => _start;
    }

    public Transform EndPoint 
    {
        get => _end;
    }

    public void InitPiece(Transform point)
    {
        transform.position = _start.position;
    }
}

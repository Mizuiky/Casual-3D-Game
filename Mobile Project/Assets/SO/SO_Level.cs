using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SO_Level : ScriptableObject
{
    [Header("Dinamic Level Setup ")]

    public ArtType _artType;

    [Header("Pieces")]

    public LevelPiece _startLevelPiece;

    public List<LevelPiece> _levelPieces;

    public LevelPiece _endLevelPiece;

    public float _timeBetweenPieces;

    public int _numberOfPieces;
}

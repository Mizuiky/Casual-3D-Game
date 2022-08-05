using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu]
public class SO_LevelAnimation : ScriptableObject
{
    [Header("Scale Level Pieces")]

    public float _pieceScaleDuration;

    public float _timeBetweenPieces;

    public Ease _pieceEase;

    [Header("Scale Coins")]

    public float _coinScaleDuration;

    public float _timeBetweenCoins;

    public Ease _coinEase;
}

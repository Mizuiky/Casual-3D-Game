using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILevelPiece
{
    public Transform StartPoint { get; }
    public Transform EndPoint { get; }

    public void InitPiece(Transform point);
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtPiece : MonoBehaviour
{
    [SerializeField]
    private GameObject _currentArt;

    public void ChangeArt(GameObject newArt)
    {
        if (_currentArt != null)
            Destroy(_currentArt);

        _currentArt = Instantiate(newArt, transform);
    }
}

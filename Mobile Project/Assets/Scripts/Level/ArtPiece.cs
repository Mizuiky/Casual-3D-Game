using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtPiece : MonoBehaviour
{
    [SerializeField]
    public GameObject _currentArt;

    private Vector3 _artPosition;

    public void ChangeArt(GameObject newArt)
    {
        _artPosition = _currentArt.transform.position;

        if (_currentArt != null)
            Destroy(_currentArt);

        _currentArt = Instantiate(newArt, transform);
        _currentArt.transform.position = _artPosition;
    }
}

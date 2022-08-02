using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelPiece : MonoBehaviour
{
    [Header("Level Piece Setup")]

    [SerializeField]
    private GameObject _plane;

    #region Private Fields

    private float _height = -0.5f;

    private List<ArtPiece> _artPieces = new List<ArtPiece>();

    private Vector3 _size;

    #endregion

    public Vector3 Size
    {
        get => _size;
    } 

    public int ArtPiecesSize
    {
        get => _artPieces.Count;
    }

    public void Init()
    {
        _size = _plane.GetComponent<Renderer>().bounds.size;

        GetArtPieces();
    }

    public void SetPosition(Vector3 pieceTransform)
    {
        pieceTransform.y = _height;

        //use Math.Floor to round down the z position to avoid breaks into the level when using retangular pieces
        var roundedZ = Mathf.Floor(pieceTransform.z);

        pieceTransform.z = roundedZ;

        transform.position = pieceTransform;
    }

    private void GetArtPieces()
    {
        foreach (var art in transform.GetComponentsInChildren<ArtPiece>())
        {
            _artPieces.Add(art);
        }
    }

    public void SetArtPieces(GameObject newArt = null)
    {
        if(newArt != null)
        {
            foreach (var art in _artPieces)
            {
                art.ChangeArt(newArt);
            }
        }     
    }
}


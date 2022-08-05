using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelAnimationController : MonoBehaviour
{
    [SerializeField]
    private SO_LevelAnimation _animationSetup;

    #region Private Fields

    private float _currentScaleDuration;

    private float _currentTimeBetweenObjects;

    private Ease _objectEase;

    private List<CoinCollectable> _coinList = new List<CoinCollectable>();

    private List<LevelPiece> _pieceList = new List<LevelPiece>();

    #endregion

    public enum LevelObjectType
    {
        Piece,
        Coin
    }

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        _currentScaleDuration = 0f;
        _currentTimeBetweenObjects = 0f;
        _objectEase = Ease.OutBack;
    }

    public void ScaleLevel(List<LevelPiece> _pieces, List<CoinCollectable> _coins)
    {
        _coinList = _coins;
        _pieceList = _pieces;

        ResetScale(_pieces);
        ResetScale(_coins);

        StartCoroutine(ScaleLevelObjects());
    }

    private IEnumerator ScaleLevelObjects()
    {
        SetCurrentAnimationSetup(LevelObjectType.Piece);
        yield return StartCoroutine(Scale(_pieceList));

        SetCurrentAnimationSetup(LevelObjectType.Coin);
        yield return StartCoroutine(Scale(_coinList));
    }

    public IEnumerator Scale<T>(List<T> levelObject) where T : MonoBehaviour
    {
        if (levelObject.Count > 0)
        {
            for (int i = 0; i < levelObject.Count; i++)
            {
                levelObject[i].transform.DOScale(1, _currentScaleDuration).SetEase(_objectEase);

                yield return new WaitForSeconds(_currentTimeBetweenObjects);
            }
        }
    }

    public void ResetScale<T>(List<T> levelObject) where T : MonoBehaviour
    {
        levelObject.ForEach(x => x.transform.localScale = Vector3.zero);
    }

    public void SetCurrentAnimationSetup(LevelObjectType type)
    {
        if (type == LevelObjectType.Piece)
        {
            _currentScaleDuration = _animationSetup._pieceScaleDuration;
            _currentTimeBetweenObjects = _animationSetup._timeBetweenPieces;
            _objectEase = _animationSetup._pieceEase;
        }
        else if (type == LevelObjectType.Coin)
        {
            _currentScaleDuration = _animationSetup._coinScaleDuration;
            _currentTimeBetweenObjects = _animationSetup._timeBetweenCoins;
            _objectEase = _animationSetup._coinEase;
        }
    }
}

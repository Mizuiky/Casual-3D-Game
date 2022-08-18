using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ButtonScaler : ClickHelper
{
    [Header("Animation")]

    [SerializeField]
    private float _animationDuration;

    [SerializeField]
    private float _scale;

    private Tween _currentTween;

    private Vector3 _originalScale;

    private void Awake()
    {
        _originalScale = transform.localScale;
    }

    protected override void Enter()
    {
        _currentTween = transform.DOScale(_originalScale * _scale, _animationDuration);
    }

    protected override void Exit()
    {
        _currentTween.Kill();
        transform.localScale = _originalScale;
    }
}

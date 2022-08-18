using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(MeshRenderer))]
public class ChangeColor : MonoBehaviour
{
    [SerializeField]
    private float _transitionDuration = 1.5f;

    public MeshRenderer _mesh;
    public Color _startColor = Color.white;

    private Color _originalColor;

    private void OnValidate()
    {
        _mesh = GetComponent<MeshRenderer>();

    }

    private void Start()
    {
        _originalColor = _mesh.materials[0].GetColor("_Color");
        ColorLerp();
    }

    private void ColorLerp()
    {
        _mesh.materials[0].SetColor("_Color", _startColor);
        _mesh.materials[0].DOColor(_originalColor, _transitionDuration).SetDelay(.3f);
    }
}


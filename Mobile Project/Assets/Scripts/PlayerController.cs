using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player fields")]

    [SerializeField]
    private float _speed;

    [Header("Lerp fields")]

    [SerializeField]
    private Transform _target;

    [SerializeField]
    private float _lerpDelay;

    private bool _canRun;

    private Vector3 _position;

    public bool CanRun
    {
        get => _canRun;
        set => _canRun = value;
    }

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        if (!_canRun)
            return;

        Move();
    }

    public void Init()
    {
        _canRun = true;
    }

    public void Move()
    {
        _position = _target.position;
        _position.y = transform.position.y;
        _position.z = transform.position.z;

        transform.position += Vector3.forward * Time.deltaTime * _speed;

        transform.position = Vector3.Lerp(transform.position, _position, Time.deltaTime * _lerpDelay);
    }
}

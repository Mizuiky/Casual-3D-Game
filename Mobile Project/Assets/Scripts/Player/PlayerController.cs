using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Serializable Fields

    [Header("Player fields")]

    [SerializeField]
    private float _fowardSpeed;

    [Header("Lerp fields")]

    [SerializeField]
    private Transform _target;

    [SerializeField]
    private float _lerpDelay;

    [Header("Model Fields")]

    [SerializeField]
    private MeshRenderer _mesh;

    [SerializeField]
    private Color _invencibleColor;

    [SerializeField]
    private Color _playerColor;

    #endregion

    #region Private Fields

    private bool _canRun;

    private Vector3 _position;

    private float _currentSpeed;

    private bool _invencible;

    public bool Invencible
    {
        get => _invencible;
    }

    #endregion

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
        _canRun = false;
        _invencible = false;
        _currentSpeed = _fowardSpeed;

        _playerColor = _mesh.material.color = _playerColor;
    }

    public void Move()
    {
        //Update y and z positions to avoid problems when touching the screen
        _position = _target.position;
        _position.y = transform.position.y;
        _position.z = transform.position.z;

        //Player moves foward when is running
        transform.position += Vector3.forward * Time.deltaTime * _currentSpeed;

        //this make the player move to the right and left smooth with the reference of the PlayerPosition
        transform.position = Vector3.Lerp(transform.position, _position, Time.deltaTime * _lerpDelay);
    }

    #region PowerUp

    //Speed PowerUp
    public void ChangeSpeed(float newSpeed)
    {
        _currentSpeed = newSpeed;
    }

    //Invencible PowerUp
    public void MakeInvencible(bool isInvencible)
    {
        if (isInvencible)
            _mesh.material.color = _invencibleColor;
        else
            _mesh.material.color = _playerColor;

        _invencible = isInvencible;
    }

    #endregion
}

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

    #endregion

    #region Private Fields

    [SerializeField]
    private float _lerpDelay;

    private bool _canRun;

    private Vector3 _position;

    private float _currentSpeed;

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
        _currentSpeed = _fowardSpeed;
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

    #endregion
}

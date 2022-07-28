using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
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

    [Header("PowerUp Fields")]

    [SerializeField]
    private Color _playerColor;

    [SerializeField]
    private MeshRenderer _mesh;

    [SerializeField]
    private float _animationDuration;

    #endregion

    #region Private Fields

    private bool _canRun;
    private bool _invencible;


    private Vector3 _position;

    private float _currentSpeed;

    private Transform _startPosition;

    public bool Invencible
    {
        get => _invencible;
        set => _invencible = value;
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
    public void ChangeSpeed(float newSpeed, Color powerUpColor)
    {
        ChangeColor(powerUpColor);
        _currentSpeed = newSpeed;
    }

    //Invencible PowerUp
    public void MakeInvencible(bool isInvencible, Color powerUpColor)
    {
        ChangeColor(powerUpColor);
        _invencible = isInvencible;
    }

    public void MakeFly(Color powerUpColor, float flyHeight, float duration)
    {
        ChangeColor(powerUpColor);

        _startPosition = transform;
     
        transform.DOMoveY(_startPosition.position.y + flyHeight, _animationDuration);
        Invoke("ResetHeight", duration);

        //transform.DOMoveY(_startPosition.position.y + flyHeight, _animationDuration).OnComplete(() => ChangeHeight(flyHeight)); 
    }

    private void ChangeColor(Color color)
    {
         _mesh.material.color = color;
    }

    public void ResetColor()
    {
        _mesh.material.color = _playerColor;
    }

    //public void ChangeHeight(float newHeight)
    //{
    //    Debug.Log("CHANGE HEIGHT: " + newHeight);
    //    var newPosition = _startPosition.position;
    //    newPosition.y = newHeight;

    //    transform.position = newPosition;
    //}

    public void ResetHeight()
    {
        Debug.Log(" RESET HEGHT");
        //transform.DOMoveY(_startPosition.position.y, _animationDuration);
    }

    public void ResetSpeed()
    {
        _currentSpeed = _fowardSpeed;
    }

    #endregion
}

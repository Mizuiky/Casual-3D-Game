using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerController : MonoBehaviour
{
    #region Serializable Fields

    [Header("Player Setup")]

    [SerializeField]
    private float _fowardSpeed;

    [SerializeField]
    private Rigidbody _rb;

    [Header("Lerp Setup")]

    [SerializeField]
    private Transform _target;

    [SerializeField]
    private float _lerpDelay;

    [Header("PowerUp Setup")]

    [SerializeField]
    private Color _playerColor;

    [SerializeField]
    private MeshRenderer _mesh;

    [SerializeField]
    private float _flyAnimationDuration;

    [SerializeField]
    private SphereCollider _coinCollider;

    [Header("Animation Setup")]

    public AnimationController _animationController;

    [SerializeField]
    private float _speedPowerUpAnimation;

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
    }

    #endregion

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
        _rb.useGravity = true;

        ChangeCoinColliderSize(1.5f);

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

    public void StartToRun()
    {
        _canRun = true;
        _animationController.Play(AnimationType.RUN);
    }

    public void StopToRun()
    {
        _canRun = false;
        MoveBack();

        _animationController.Play(AnimationType.DEAD);
    }

    public void PlayerVictory()
    {
        _canRun = false;
        _animationController.Play(AnimationType.IDLE);
    }

    #region PowerUp

    //Speed PowerUp
    public void ChangeSpeed(float newSpeed)
    {
        _currentSpeed = newSpeed;
        _animationController.SetAnimationSpeed(newSpeed / _speedPowerUpAnimation);
    }

    //Invencible PowerUp
    public void MakeInvencible(bool isInvencible)
    {
        _invencible = isInvencible;
    }

    public void MakeFly(float flyHeight, float duration)
    {
        _startPosition = transform;

        _rb.useGravity = false;
        transform.DOMoveY(_startPosition.position.y + flyHeight, _flyAnimationDuration);
        Invoke("ResetHeight", duration);
    }

    public void MoveBack()
    {
        //the same as trasnform.position.z - 1
        transform.DOMoveZ(-1f, 2f).SetRelative();
    }

    public void ResetHeight()
    {
        transform.DOMoveY(_startPosition.position.y, _flyAnimationDuration);
        _rb.useGravity = true;
    }

    public void ChangeCoinColliderSize(float amount)
    {
        _coinCollider.radius = amount;
    }

    public void ChangeColor(Color color)
    {
         _mesh.material.color = color;
    }

    public void ResetColor()
    {
        _mesh.material.color = _playerColor;
    }

    public void ResetSpeed()
    {
        _currentSpeed = _fowardSpeed;
        _animationController.SetAnimationSpeed(1f);
    }

    #endregion
}

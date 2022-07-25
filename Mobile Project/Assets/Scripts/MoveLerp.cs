using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLerp : MonoBehaviour
{
    [SerializeField]
    private Transform _target;

    [SerializeField]
    private float _lerpDelay;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.Lerp(transform.position, _target.position, Time.deltaTime * _lerpDelay);
    }
}

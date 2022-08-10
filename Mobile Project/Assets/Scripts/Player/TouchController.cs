using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    [SerializeField]
    private float _speedModifier;

    private Vector3 _previousPosition;
    private float _speed;

    private void Update()
    {
        if(GameManager.Instance.IsRunning)
        {
            if (Input.GetMouseButton(0))
            {
                _speed = Input.mousePosition.x - _previousPosition.x;
                Move();
            }

            _previousPosition = Input.mousePosition;
        }   
    }

    private void Move()
    {
        //this moves the controller to the 2D distance(_speed) between mouse position and the previous position in the x axis
        transform.position += Vector3.right * _speed * Time.deltaTime * _speedModifier;
    }
}

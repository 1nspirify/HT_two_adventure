using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Vector3 = System.Numerics.Vector3;

public class MazeController : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;

    private string _horizontalAxis = "Horizontal";
    private string _verticalAxis = "Vertical";

    private float _xDirection;
    private float _zDirection;

    private float _deadZone = 0.05f;
    private bool _canMove;

    private void Update()
    {
        GetDirection();

        if (DeadZone())
            _canMove = true;
    }

    private void FixedUpdate()
    {
        Rotate();
    }

    private void GetDirection()
    {
        _xDirection = Input.GetAxis(_horizontalAxis);
        _zDirection = Input.GetAxis(_verticalAxis);
    }

    private bool DeadZone() => _xDirection >= _deadZone || _zDirection >= _deadZone;

    private void Rotate()
    {
        if (_canMove)
        {
            gameObject.transform.Rotate(_zDirection * _rotationSpeed, 0, _xDirection * _rotationSpeed);
        }
    }
}
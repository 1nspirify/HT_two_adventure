using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private float _xForce;
    private float _zForce;

    [SerializeField] float _jumpForce;
    [SerializeField] float _speed;

    private string _horizontalAxis = "Horizontal";
    private string _verticalAxis = "Vertical";

    private KeyCode _jumpKey = KeyCode.Space;

    private bool _isPush;
    
    private bool _isGrounded;
    private bool _isJumped;
    
    private float _deadZone = 0.05f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        GetInput();
        
        if (DeadZone())
        {
            _isPush = true;
        }

        if (Input.GetKey(_jumpKey))
        {
            _isJumped = true;
        }
    }

    private void FixedUpdate()
    {
        if (_isPush)
        {
            Move();
        }

        if (JumpClause())
        {
            Jump();
        }
    }

    private void GetInput()
    {
        _xForce = Input.GetAxis(_horizontalAxis);
        _zForce = Input.GetAxis(_verticalAxis);
    }

    private bool DeadZone() => Mathf.Abs(_xForce) > _deadZone || Mathf.Abs(_zForce) > _deadZone;
    private bool JumpClause() => _isJumped && _isGrounded;

    private void Jump()
    {
        _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);

        _isJumped = false;
        _isGrounded = false;
    }

    private void Move()
    {
        _rigidbody.AddForce(Vector3.right * (_xForce * _speed));
        _rigidbody.AddForce(Vector3.forward * (_zForce * _speed));
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.GetComponent<Ground>())
        {
            _isGrounded = true;
        }
    }
}
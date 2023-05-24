using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 _input;

    [SerializeField]
    private float _playerSpeed;
    [SerializeField]
    private float _jumpHeight;
    [SerializeField]
    private float _acceleration;

    private Transform[] _groundCheck = new Transform[2];
  

    private Collider2D _collider;
    private Rigidbody2D _rigidbody;

    [SerializeField]
    private LayerMask _groundMask;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();

        _groundCheck[0] = transform.GetChild(0);
        _groundCheck[1] = transform.GetChild(1);

    }

    void Update()
    {

        if (GameManager.IsPaused)
            return;

        _input.x = Input.GetAxisRaw("Horizontal");

        if(Input.GetKeyDown(KeyCode.W) && IsGrounded())
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpHeight);
        }
           
        
    }

    private void FixedUpdate()
    {
        if (_rigidbody.velocity.y < 0f)
            _rigidbody.velocity = new Vector2(_input.x * _playerSpeed, _rigidbody.velocity.y - _acceleration);
        else
            _rigidbody.velocity = new Vector2(_input.x * _playerSpeed, _rigidbody.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapArea(_groundCheck[0].position, _groundCheck[1].position, _groundMask);
    }



}
